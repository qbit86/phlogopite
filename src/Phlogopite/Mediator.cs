using System;
using System.Buffers;
using System.Collections.Generic;

namespace Phlogopite
{
    public sealed class Mediator : IMediator<NamedProperty>
    {
        internal const Level DefaultMinimumLevel = Level.Verbose;
        private const int MediatorPropertyCount = 1;

        private readonly Func<Exception, bool> _exceptionHandler;
        private readonly Level _minimumLevel;
        private readonly Func<Level> _minimumLevelProvider;
        private readonly IReadOnlyList<ISink<NamedProperty>> _sinks;

        public Mediator(ISink<NamedProperty> sink) :
            this(GetArrayOrEmpty(sink), DefaultMinimumLevel, default, default) { }

        public Mediator(ISink<NamedProperty> sink, Level minimumLevel) :
            this(GetArrayOrEmpty(sink), minimumLevel, default, default) { }

        public Mediator(IReadOnlyList<ISink<NamedProperty>> sinks) :
            this(sinks, DefaultMinimumLevel, default, default) { }

        public Mediator(IReadOnlyList<ISink<NamedProperty>> sinks, Level minimumLevel) :
            this(sinks, minimumLevel, default, default) { }

        internal Mediator(IReadOnlyList<ISink<NamedProperty>> sinks,
            Level minimumLevel, Func<Level> minimumLevelProvider, Func<Exception, bool> exceptionHandler)
        {
            _sinks = sinks ?? Array.Empty<ISink<NamedProperty>>();
            _minimumLevel = minimumLevel;
            _minimumLevelProvider = minimumLevelProvider;
            _exceptionHandler = exceptionHandler;
        }

        public static Mediator Silent { get; } = new Mediator(Array.Empty<ISink<NamedProperty>>(), Level.Silent);

        public int GetAttachedPropertyCount(Level level)
        {
            return MediatorPropertyCount;
        }

        public bool IsEnabled(Level level)
        {
            Level minimumLevel = _minimumLevelProvider?.Invoke() ?? _minimumLevel;
            if (minimumLevel > level)
                return false;

            return _sinks.Count != 0;
        }

        public void UncheckedWrite(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> writerProperties, Span<NamedProperty> attachedProperties)
        {
            int length = Math.Min(attachedProperties.Length, MediatorPropertyCount);
            Span<NamedProperty> mediatorProperties = attachedProperties.Slice(0, length);
            if (mediatorProperties.Length > 0)
                mediatorProperties[0] = new NamedProperty("time", DateTime.Now);

            List<Exception> exceptions = null;
            for (int i = 0; i < _sinks.Count; ++i)
            {
                try
                {
                    ISink<NamedProperty> sink = _sinks[i];
                    if (sink is null || !sink.IsEnabled(level))
                        continue;

                    sink.UncheckedWrite(level, text, userProperties, writerProperties, mediatorProperties);
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

            if (exceptions is null)
                return;

            var aggregateException = new AggregateException(exceptions);
            if (_exceptionHandler is null)
                throw aggregateException;

            aggregateException.Handle(_exceptionHandler);
        }

        public void Write(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> writerProperties)
        {
            if (!IsEnabled(level))
                return;

            UncheckedWrite(level, text, userProperties, writerProperties, default);
        }

        private static ISink<NamedProperty>[] GetArrayOrEmpty(ISink<NamedProperty> sink)
        {
            if (sink is null)
                return Array.Empty<ISink<NamedProperty>>();

            return new[] { sink };
        }
    }
}
