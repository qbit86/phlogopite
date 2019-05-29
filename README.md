# Phlogopite

Logging with lower memory footprint.

## Usage

```cs
internal static class Program
{
    private const string Tag = nameof(Program);

    private static void Main()
    {
        var sink = new ConsoleSink();
        var mediator = new Mediator(sink);

        var log = new Writer(mediator, Tag);
        log.V("Hello, world!");
        log.I("Logged in", ("username", Environment.UserName), ("ipaddress", IPAddress.Loopback));
    }
}
```

```
[Program.Main] Hello, world!
[Program.Main] Logged in. username: Viktor, ipaddress: 127.0.0.1
```

`Writer` is basically a facade for `IMediator<NamedProperty>`.  All it does is binding tag and mediator together to simplify subsequent writes to mediator.  It is value type and doesn't allocate on creating, so feel free to instantiate it in every method that needs logging.

`Writer` implements `IWriter<NamedProperty>`, but you should avoid casting (with consequent boxing) to this interface.  `IWriter<NamedProperty>` is supposed to be generic constraint, not for OOP-style polymorphism.

`Writer` itself doesn't have a lot of public methods, it is `WriterExtensions` class who provides API for actual writing to mediator.  To use extension methods just import `Phlogopite.Extensions` namespace:

```cs
using Phlogopite.Extensions;
```

## API

```cs
public interface IWriter<TProperty>
{
    bool IsEnabled(Level level);
    void UncheckedWrite(Level level, string text, ReadOnlySpan<TProperty> userProperties,
        Span<TProperty> attachedProperties);
}

public interface IMediator<TProperty>
{
    bool IsEnabled(Level level);
    void UncheckedWrite(Level level, string text, ReadOnlySpan<TProperty> userProperties,
        ReadOnlySpan<TProperty> writerProperties, Span<TProperty> attachedProperties);
}

public interface ISink<TProperty>
{
    bool IsEnabled(Level level);
    void UncheckedWrite(Level level, string text, ReadOnlySpan<TProperty> userProperties,
        ReadOnlySpan<TProperty> writerProperties, ReadOnlySpan<TProperty> mediatorProperties);
}
```
