# Changelog

## [Unreleased] - 2020-04-05
### Changed
- Update Phlogopite.Abstractions to 0.7.0.

## [0.6.0] - 2020-03-31
### Changed
- Update Phlogopite.Abstractions to 0.6.0.

## [0.5.0] - 2019-10-09
### Added
- New target framework `netstandard2.1` which simplifies dependency graph.

### Changed
- Default parameters of constructors.
- Refactored `MediatorLoggerBuilder`.

## [0.4.0] - 2019-07-29
### Changed
- API and logging implementation.

### Removed
- `Mediator`, `MediatorBuilder`, `MediatorExtensions`
- `Writer`, `WriterBuilder`, `WriterExtensions`
- `SilentSink`

## [0.2.1] - 2019-07-12
### Added
- `WriterBuilder` type that binds mediator and tag.

## [0.2.0] - 2019-05-31
### Changed
- Removed fallback allocations in `UncheckedWrite()` methods of `Mediator` and `Writer` types.

## [0.1.0] - 2019-05-24
### Added
- Default implementation for logging abstractions: `Mediator`, `Writer`.

[Unreleased]: https://github.com/qbit86/phlogopite/compare/main-0.6.0...HEAD
[0.6.0]: https://github.com/qbit86/phlogopite/compare/main-0.5.0...main-0.6.0
[0.5.0]: https://github.com/qbit86/phlogopite/compare/main-0.4.0...main-0.5.0
[0.4.0]: https://github.com/qbit86/phlogopite/compare/main-0.2.1...main-0.4.0
[0.2.1]: https://github.com/qbit86/phlogopite/compare/main-0.2.0...main-0.2.1
[0.2.0]: https://github.com/qbit86/phlogopite/compare/main-0.1.0...main-0.2.0 
[0.1.0]: https://github.com/qbit86/phlogopite/releases/tag/main-0.1.0
