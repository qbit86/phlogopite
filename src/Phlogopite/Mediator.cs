using System;
using System.Buffers;
using System.Collections.Generic;

namespace Phlogopite
{
    public sealed class Mediator : IMediator<NamedProperty>, IWriter<NamedProperty>
    {
        private static Mediator s_shared;

        private readonly Func<Exception, bool> _exceptionHandler;
        private readonly Level _minimumLevel;
        private readonly Func<Level> _minimumLevelProvider;
        private readonly IReadOnlyList<ISink<NamedProperty>> _sinks;

        public Mediator(IReadOnlyList<ISink<NamedProperty>> sinks) :
            this(sinks, Level.Verbose, default, default) { }

        public Mediator(IReadOnlyList<ISink<NamedProperty>> sinks, Level minimumLevel) :
            this(sinks, minimumLevel, default, default) { }

        public Mediator(IReadOnlyList<ISink<NamedProperty>> sinks, Func<Level> minimumLevelProvider) :
            this(sinks, Level.Verbose, minimumLevelProvider, default) { }

        public Mediator(IReadOnlyList<ISink<NamedProperty>> sinks, Level minimumLevel,
            Func<Exception, bool> exceptionHandler) :
            this(sinks, minimumLevel, default, exceptionHandler) { }

        public Mediator(IReadOnlyList<ISink<NamedProperty>> sinks, Func<Level> minimumLevelProvider,
            Func<Exception, bool> exceptionHandler) :
            this(sinks, Level.Verbose, minimumLevelProvider, exceptionHandler) { }

        private Mediator(IReadOnlyList<ISink<NamedProperty>> sinks,
            Level minimumLevel, Func<Level> minimumLevelProvider, Func<Exception, bool> exceptionHandler)
        {
            _sinks = sinks ?? Array.Empty<ISink<NamedProperty>>();
            _minimumLevel = minimumLevel;
            _minimumLevelProvider = minimumLevelProvider;
            _exceptionHandler = exceptionHandler;
        }

        public static Mediator Silent { get; } = new Mediator(Array.Empty<ISink<NamedProperty>>(), Level.Silent);

        public static Mediator Shared => s_shared ?? Silent;

        public bool IsEnabled(Level level)
        {
            if (_sinks.Count == 0)
                return false;

            Level minimumLevel = _minimumLevelProvider?.Invoke() ?? _minimumLevel;
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
                        exceptions = new List<Exception>();

                    exceptions.Add(ex);
                }
#pragma warning restore CA1031 // Do not catch general exception types
            }

            ArrayPool<NamedProperty>.Shared.Return(mediatorProperties);

            if (exceptions is null)
                return;

            var aggregateException = new AggregateException(exceptions);
            if (_exceptionHandler is null)
                throw aggregateException;

            aggregateException.Handle(_exceptionHandler);
        }

        public void Write(Level level, string text, ReadOnlySpan<NamedProperty> properties)
        {
            Write(level, text, properties, default);
        }

        public static bool TrySetShared(Mediator shared)
        {
            if (s_shared != null)
                return false;

            s_shared = shared ?? throw new ArgumentNullException(nameof(shared));
            return true;
        }
    }
}
