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
- `IPropertyFormatter<TProperty>`
- `PropertyFormatter`

### Removed
- `IFormatter<TProperty>`
- `Formatter`

## [0.2.0] - 2019-07-29
### Removed
- `IFormattedSink<TProperty>`
- `FormattingSink`

## [0.1.0] - 2019-06-01
### Added
- `IFormattedSink<TProperty>` as abstraction for text-based sinks.
- `FormattingSink` as default implementation of proxy between mediator and text-based sinks.

[Unreleased]: https://github.com/qbit86/phlogopite/compare/formatting-0.6.0...HEAD
[0.6.0]: https://github.com/qbit86/phlogopite/compare/formatting-0.5.0...formatting-0.6.0
[0.5.0]: https://github.com/qbit86/phlogopite/compare/formatting-0.2.0...formatting-0.5.0
[0.2.0]: https://github.com/qbit86/phlogopite/compare/formatting-0.1.0...formatting-0.2.0
[0.1.0]: https://github.com/qbit86/phlogopite/releases/tag/formatting-0.1.0
