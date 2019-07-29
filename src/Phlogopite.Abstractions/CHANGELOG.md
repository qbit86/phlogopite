# Changelog

## [Unreleased]
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

[Unreleased]: https://github.com/qbit86/phlogopite/compare/abstractions-0.3.0...feature/redesign
[0.3.0]: https://github.com/qbit86/phlogopite/compare/abstractions-0.2.0...abstractions-0.3.0
[0.2.0]: https://github.com/qbit86/phlogopite/compare/abstractions-0.1.0...abstractions-0.2.0
[0.1.0]: https://github.com/qbit86/phlogopite/releases/tag/abstractions-0.1.0
