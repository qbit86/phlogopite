# Phlogopite

Logging with lower memory footprint.

## Usage

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

## API

```cs
public interface IWriter<TProperty>
{
    bool IsEnabled(Level level);
    void UncheckedWrite(Level level, string text, ReadOnlySpan<TProperty> properties);
}

public interface IMediator<TProperty>
{
    bool IsEnabled(Level level);
    void UncheckedWrite(Level level, string text, ReadOnlySpan<TProperty> userProperties,
        ReadOnlySpan<TProperty> writerProperties);
}

public interface ISink<TProperty>
{
    bool IsEnabled(Level level);
    void UncheckedWrite(Level level, string text, ReadOnlySpan<TProperty> userProperties,
        ReadOnlySpan<TProperty> writerProperties, ReadOnlySpan<TProperty> mediatorProperties);
}
```
