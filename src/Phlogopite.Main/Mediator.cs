using System;
using System.Buffers;
using System.Collections.Generic;

namespace Phlogopite
{
    public sealed class Mediator : IMediator<NamedProperty>, IWriter<NamedProperty>
    {
        private static readonly Mediator s_silent = new Mediator(Array.Empty<ISink<NamedProperty>>(), Level.Silent);
        private static Mediator s_shared;

        private readonly IReadOnlyList<ISink<NamedProperty>> _sinks;
        private readonly Level _minimumLevel;
        private readonly Func<Level> _minimumLevelProvider;

        public Mediator(IReadOnlyList<ISink<NamedProperty>> sinks)
            : this(sinks, Level.Verbose) { }

        public Mediator(IReadOnlyList<ISink<NamedProperty>> sinks, Level minimumLevel)
            : this(sinks, minimumLevel, default) { }

        public Mediator(IReadOnlyList<ISink<NamedProperty>> sinks, Func<Level> minimumLevelProvider)
            : this(sinks, Level.Verbose, minimumLevelProvider) { }

        private Mediator(IReadOnlyList<ISink<NamedProperty>> sinks,
            Level minimumLevel, Func<Level> minimumLevelProvider)
        {
            _sinks = sinks ?? Array.Empty<ISink<NamedProperty>>();
            _minimumLevel = minimumLevel;
            _minimumLevelProvider = minimumLevelProvider;
        }

        public static Mediator Silent => s_silent;

        public static Mediator Shared => s_shared ?? s_silent;

        public Func<Exception, bool> ExceptionHandler { get; set; }

        public static bool TrySetShared(Mediator shared)
        {
            if (s_shared != null)
                return false;

            s_shared = shared ?? throw new ArgumentNullException(nameof(shared));
            return true;
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
            mediatorProperties[0] = new NamedProperty("time", DateTime.Now);

            List<Exception> exceptions = null;
            for (int i = 0; i < _sinks.Count; ++i)
            {
                try
                {
                    ISink<NamedProperty> sink = _sinks[i];
                    sink?.Write(level, text, userProperties, writerProperties, mediatorProperties.AsSpan(0, 1));
                }
#pragma warning disable CA1031 // Do not catch general exception types
                catch (Exception ex)
                {
                    if (exceptions is null)
                        exceptions = new List<Exception>(1);

                    exceptions.Add(ex);
                }
#pragma warning restore CA1031 // Do not catch general exception types
            }

            ArrayPool<NamedProperty>.Shared.Return(mediatorProperties, false);

            if (exceptions is null)
                return;

            var aggregateException = new AggregateException(exceptions);
            if (ExceptionHandler is null)
                throw aggregateException;

            aggregateException.Handle(ExceptionHandler);
        }

        public void Write(Level level, string text, ReadOnlySpan<NamedProperty> properties)
        {
            Write(level, text, properties, default);
        }
    }
}
