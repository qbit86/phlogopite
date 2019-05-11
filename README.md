# Phlogopite

Logging with lower memory footprint.

```cs
internal static class Program
{
    private const string Tag = nameof(Program);

    private static void Main()
    {
        var sinks = new[] { new ConsoleSink() };
        var mediator = new Mediator(sinks);
        var log = new Writer(mediator, Tag);
        log.V("Hello, world!");
        log.I("Logged in", ("username", Environment.UserName), ("ipaddress", IPAddress.Loopback));
    }
}
```

```
V 11:58:16.732 [Program.Main] Hello, world!
I 11:58:16.742 [Program.Main] Logged in. username: Viktor, ipaddress: 127.0.0.1
```

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
