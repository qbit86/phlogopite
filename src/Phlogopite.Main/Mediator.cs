using System;
using System.Collections.Generic;

namespace Phlogopite
{
    public sealed class Mediator : IMediator<NamedProperty>
    {
        private readonly Level _minimumLevel;
        private readonly List<ISink<NamedProperty>> _sinks = new List<ISink<NamedProperty>>();
        private readonly ISink<NamedProperty> _errorSink = SilentSink.Default;

        public Mediator(Level minimumLevel)
        {
            _minimumLevel = minimumLevel;
        }

        public void Add(ISink<NamedProperty> sink)
        {
            if (sink is null)
                throw new ArgumentNullException(nameof(sink));

            _sinks.Add(sink);
        }

        public bool IsEnabled(Level level)
        {
            return _minimumLevel <= level;
        }

        public void Write(Level level, string text, ReadOnlySpan<NamedProperty> userProperties, ReadOnlySpan<NamedProperty> writerProperties)
        {
            if (!IsEnabled(level))
                return;

            Span<NamedProperty> mediatorProperties = new NamedProperty[]
            {
                new NamedProperty("timestamp", DateTime.Now),
                default
            };

            foreach (ISink<NamedProperty> sink in _sinks)
            {
                try
                {
                    sink.Write(level, text, userProperties, writerProperties, mediatorProperties.Slice(0, 1));
                }
#pragma warning disable CA1031 // Do not catch general exception types
                catch (Exception ex)
                {
                    mediatorProperties[1] = new NamedProperty("exception", ex);
                    _errorSink.Write(Level.Error, ex.Message, ReadOnlySpan<NamedProperty>.Empty,
                        ReadOnlySpan<NamedProperty>.Empty, mediatorProperties);
                }
#pragma warning restore CA1031 // Do not catch general exception types
            }
        }
    }
}
