namespace Phlogopite
{
    public interface ILogger<TProperty> : ILogger<TProperty, SpanBuilder<TProperty>> { }
}
