using System;
using System.Collections.Generic;
using System.Threading;

namespace Phlogopite
{
    public sealed class MediatorBuilder
    {
        private Level? _minimumLevel;
        private IReadOnlyList<ISink<NamedProperty>> _sinks;

        public MediatorBuilder() : this(null) { }

        public MediatorBuilder(IReadOnlyList<ISink<NamedProperty>> sinks)
        {
            _sinks = sinks;
        }

        public Func<Exception, bool> ExceptionHandler { get; set; }

        public Level MinimumLevel
        {
            get => _minimumLevel ?? Mediator.DefaultMinimumLevel;
            set => _minimumLevel = value;
        }

        public Func<Level> MinimumLevelProvider { get; set; }

        public IReadOnlyList<ISink<NamedProperty>> Sinks
        {
            get => _sinks ?? Array.Empty<ISink<NamedProperty>>();
            set => _sinks = value;
        }

        public Mediator Build()
        {
            IReadOnlyList<ISink<NamedProperty>> sinks = Interlocked.Exchange(ref _sinks, null);
            return new Mediator(sinks, MinimumLevel, MinimumLevelProvider, ExceptionHandler);
        }

        public MediatorBuilder AddSink(ISink<NamedProperty> sink)
        {
            if (sink is null)
                return this;

            if (_sinks is null)
            {
                _sinks = new List<ISink<NamedProperty>>(1) { sink };
                return this;
            }

            if (_sinks is ICollection<ISink<NamedProperty>> collection)
            {
                collection.Add(sink);
                return this;
            }

            throw new NotSupportedException("Collection is read-only.");
        }

        public MediatorBuilder AddSinks(ISink<NamedProperty> sink0, ISink<NamedProperty> sink1)
        {
            if (sink0 is null)
                return AddSink(sink1);

            if (sink1 is null)
                return AddSink(sink0);

            if (_sinks is null)
            {
                _sinks = new List<ISink<NamedProperty>>(2) { sink0, sink1 };
                return this;
            }

            if (_sinks is ICollection<ISink<NamedProperty>> collection)
            {
                collection.Add(sink0);
                collection.Add(sink1);
                return this;
            }

            throw new NotSupportedException("Collection is read-only.");
        }
    }
}
