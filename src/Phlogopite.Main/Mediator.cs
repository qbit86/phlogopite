using System;
using System.Buffers;
using System.Collections.Generic;

namespace Phlogopite
{
    public sealed class Mediator : IMediator<NamedProperty>
    {
        private readonly Level _minimumLevel;
        private readonly Func<Level> _minimumLevelProvider;
        private readonly List<ISink<NamedProperty>> _sinks = new List<ISink<NamedProperty>>();

        public Mediator() : this(Level.Verbose) { }

        public Mediator(Level minimumLevel)
        {
            _minimumLevel = minimumLevel;
        }

        public Mediator(Func<Level> minimumLevelProvider)
        {
            _minimumLevelProvider = minimumLevelProvider;
        }

        public Func<Exception, bool> SinkExceptionHandler { get; set; }

        public void Add(ISink<NamedProperty> sink)
        {
            if (sink is null)
                throw new ArgumentNullException(nameof(sink));

            _sinks.Add(sink);
        }

        public bool IsEnabled(Level level)
        {
            Level minimumLevel = _minimumLevelProvider is null ? _minimumLevel : _minimumLevelProvider();
            return minimumLevel <= level;
        }

        public void Write(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> writerProperties)
        {
            if (!IsEnabled(level))
                return;

            NamedProperty[] mediatorProperties = ArrayPool<NamedProperty>.Shared.Rent(1);
            mediatorProperties[0] = new NamedProperty("timestamp", DateTime.Now);

            List<Exception> exceptions = null;
            foreach (ISink<NamedProperty> sink in _sinks)
            {
                try
                {
                    sink.Write(level, text, userProperties, writerProperties, mediatorProperties.AsSpan(0, 1));
                }
#pragma warning disable CA1031 // Do not catch general exception types
                catch (Exception ex)
                {
                    if (exceptions == null)
                        exceptions = new List<Exception>(1);

                    exceptions.Add(ex);
                }
#pragma warning restore CA1031 // Do not catch general exception types
            }

            ArrayPool<NamedProperty>.Shared.Return(mediatorProperties, false);

            if (exceptions != null)
            {
                var ex = new AggregateException(exceptions);
                if (SinkExceptionHandler is null)
                    throw ex;

                ex.Handle(SinkExceptionHandler);
            }
        }
    }
}
