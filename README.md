# Phlogopite

[![Phlogopite version](https://img.shields.io/nuget/v/Phlogopite.svg)](https://www.nuget.org/packages/Phlogopite/)

Logging with lower memory footprint.

## Usage

```cs
internal static class Program
{
    private static void Main()
    {
        var backLogger = new ConsoleLogger();
        var frontLogger = new CategoryLogger(backLogger, nameof(Program));

        frontLogger.I("Hello!", ("user", Environment.UserName));
    }
}
```

```
[Program.Main] Hello! user: Viktor
```

`CategoryLogger` is basically a facade for another `ILogger<NamedProperty>`.  All it does is binding log category and backing sink together, and attaches string tag at subsequent writes to the underlying logger.  `CategoryLogger` is value type and doesn't allocate on creating, so feel free to instantiate it as member of your types.

`CategoryLogger` implements `ILogger<NamedProperty>`, but you should avoid casting (hence boxing) to this interface.  `ILogger<NamedProperty>` is supposed to be generic constraint, not to be supertype in OOP-style polymorphism.

`ILogger<TProperty>` itself doesn't have a lot of public methods, it is `*LoggerExtensions` classes who provide API for actual writing to the logger.  To use extension methods just import appropriate `Phlogopite.Extensions.*` namespace:

```cs
using Phlogopite.Extensions.Source;
```

## API

```cs
public interface ILogger<TProperty>
{
    int MaxAttachedPropertyCount { get; }
    bool IsEnabled(Level level);
    void UncheckedWrite(Level level, string text, ReadOnlySpan<TProperty> userProperties,
        SpanBuilder<TProperty> attachedProperties);
}
```
