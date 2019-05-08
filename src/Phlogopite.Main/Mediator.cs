using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;

namespace Phlogopite
{
#pragma warning disable CA1710 // Identifiers should have correct suffix
    public sealed class Mediator : IMediator<NamedProperty>, IWriter<NamedProperty>, IEnumerable<ISink<NamedProperty>>
#pragma warning restore CA1710 // Identifiers should have correct suffix
    {
        private static IMediator<NamedProperty> s_shared;

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

        public static IMediator<NamedProperty> Shared => s_shared ?? SilentSink.Default;

        public Func<Exception, bool> ExceptionHandler { get; set; }

        public static bool TrySetShared(IMediator<NamedProperty> shared)
        {
            if (s_shared != null)
                return false;

            s_shared = shared ?? throw new ArgumentNullException(nameof(shared));
            return true;
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

        public void Write(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> writerProperties)
        {
            if (!IsEnabled(level))
                return;

            NamedProperty[] mediatorProperties = ArrayPool<NamedProperty>.Shared.Rent(1);
            mediatorProperties[0] = new NamedProperty("time", DateTime.Now);

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

        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers#collection-initializers

        IEnumerator<ISink<NamedProperty>> IEnumerable<ISink<NamedProperty>>.GetEnumerator()
        {
            throw new NotSupportedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotSupportedException();
        }
    }
}
