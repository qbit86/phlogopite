# Phlogopite

Logging with lower memory footprint.

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
var sinks = new ISink<NamedProperty>[] { new ConsoleSink() };
var mediator = new Mediator(sinks);
...
var log = new Writer(mediator, tag: "SomeClass");
log.I("Plain text, no string formatting", ("tau", 2.0 * Math.PI), ("today", DateTime.Today));
```

```
I 03:42:22.642 [SomeClass.SomeMethod] Plain text, no string formatting. tau: 6.28318530717959, today: 2019-05-08 00:00:00
```
