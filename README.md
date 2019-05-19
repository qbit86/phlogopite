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

`Writer` is basically a facade for `IMediator<NamedProperty>`.  All it does is binding tag and mediator together to simplify subsequent writes to mediator.  It is value type and doesn't allocate on creating, so feel free to instantiate it in every method that needs logging.

`Writer` implements `IWriter<NamedProperty>`, but you should avoid casting (with consequent boxing) to this interface.  `IWriter<NamedProperty>` is supposed to be generic constraint, not for OOP-style polymorphism.

`Writer` itself doesn't have a lot of public methods, it's `WriterExtensions` class who provides API for actual writing to mediator.  To use extension methods just import `Phlogopite.Extensions` namespace:

```cs
using Phlogopite.Extensions;
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
