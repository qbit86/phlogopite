# Changelog

## [Unreleased] - 2020-04-05
### Fixed
- Bug in `SpanBuilder<T>` resulting in properties being not attached.

### Removed
- `SpanBuilder<T>` constructor overload taking three arguments.

## [0.6.0] - 2020-03-31
### Changed
- Replace `MaxAttachedPropertyCount` property with `GetMaxAttachedPropertyCount()` method.
- `SpanBuilder<T>` now operates on available span instead of array.

## [0.5.0] - 2019-10-08
### Added
- New target framework `netstandard2.1` which simplifies dependency graph.

## [0.4.0] - 2019-07-29
### Added
- `ILogger<TProperty>`

### Removed
- `IMediator<TProperty>`
- `IWriter<TProperty>`
- `ISink<TProperty>`

## [0.3.0] - 2019-05-31
### Added
- `int GetAttachedPropertyCount(Level level)` method to `IWriter<TProperty>` and `IMediator<TProperty>` interfaces.

## [0.2.0] - 2019-05-24
### Added
- `attachedProperties` parameter to `UncheckedWrite()` method in `IWriter<TProperty>` and `IMediator<TProperty>` interfaces.

### Changed
- Update [System.Memory](https://www.nuget.org/packages/System.Memory) to 4.5.3.

## [0.1.0] - 2019-05-23
### Added
- Basic building blocks for logging pipeline: `IMediator<TProperty>`, `ISink<TProperty>`, `IWriter<TProperty>`.

[Unreleased]: https://github.com/qbit86/phlogopite/compare/abstractions-0.6.0...HEAD
[0.6.0]: https://github.com/qbit86/phlogopite/compare/abstractions-0.5.0...abstractions-0.6.0
[0.5.0]: https://github.com/qbit86/phlogopite/compare/abstractions-0.4.0...abstractions-0.5.0
[0.4.0]: https://github.com/qbit86/phlogopite/compare/abstractions-0.3.0...abstractions-0.4.0
[0.3.0]: https://github.com/qbit86/phlogopite/compare/abstractions-0.2.0...abstractions-0.3.0
[0.2.0]: https://github.com/qbit86/phlogopite/compare/abstractions-0.1.0...abstractions-0.2.0
[0.1.0]: https://github.com/qbit86/phlogopite/releases/tag/abstractions-0.1.0
