# Phlogopite

Logging with less allocations.

```cs
public interface IWriter<TProperty>
{
    void Write(Level level, string text, ReadOnlySpan<TProperty> properties);
}

public interface IMediator<TProperty>
{
    void Write(Level level, string text, ReadOnlySpan<TProperty> userProperties,
        ReadOnlySpan<TProperty> writerProperties);
}

public interface ISink<TProperty>
{
    void Write(Level level, string text, ReadOnlySpan<TProperty> userProperties,
        ReadOnlySpan<TProperty> writerProperties, ReadOnlySpan<TProperty> mediatorProperties);
}
```

```cs
var sink = new ConsoleSink();
var mediator = new Mediator();
mediator.Add(sink);
...
var log = new Writer(mediator, tag: "SomeClass.SomeMethod");
log.I("Plain text, no dynamic formatting", ("tau", 2.0 * Math.PI), ("today", DateTime.Today));
```

```
I 02:05:49.241 [SomeClass.SomeMethod] Plain text, no dynamic formatting. tau: 6.28318530717959, today: 2019-05-02 00:00:00
```
