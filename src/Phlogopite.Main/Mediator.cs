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
        private readonly ISink<NamedProperty> _errorSink = SilentSink.Default;

        public Mediator() : this(Level.Verbose) { }

        public Mediator(Level minimumLevel)
        {
            _minimumLevel = minimumLevel;
        }

        public Mediator(Func<Level> minimumLevelProvider)
        {
            _minimumLevelProvider = minimumLevelProvider;
        }

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

        public void Write(Level level, string text, ReadOnlySpan<NamedProperty> userProperties, ReadOnlySpan<NamedProperty> writerProperties)
        {
            if (!IsEnabled(level))
                return;

            NamedProperty[] mediatorProperties = ArrayPool<NamedProperty>.Shared.Rent(2);
            try
            {
                mediatorProperties[0] = new NamedProperty("timestamp", DateTime.Now);
                foreach (ISink<NamedProperty> sink in _sinks)
                {
                    try
                    {
                        sink.Write(level, text, userProperties, writerProperties, mediatorProperties.AsSpan(0, 1));
                    }
#pragma warning disable CA1031 // Do not catch general exception types
                    catch (Exception ex)
                    {
                        mediatorProperties[1] = new NamedProperty("exception", ex);
                        _errorSink.Write(Level.Error, ex.Message, ReadOnlySpan<NamedProperty>.Empty,
                            ReadOnlySpan<NamedProperty>.Empty, mediatorProperties.AsSpan(0, 2));
                    }
#pragma warning restore CA1031 // Do not catch general exception types
                }
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(mediatorProperties, true);
            }
        }
    }
}
