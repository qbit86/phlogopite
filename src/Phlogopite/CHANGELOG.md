# Changelog

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

[0.4.0]: https://github.com/qbit86/phlogopite/compare/main-0.2.1...main-0.4.0
[0.2.1]: https://github.com/qbit86/phlogopite/compare/main-0.2.0...main-0.2.1
[0.2.0]: https://github.com/qbit86/phlogopite/compare/main-0.1.0...main-0.2.0 
[0.1.0]: https://github.com/qbit86/phlogopite/releases/tag/main-0.1.0
