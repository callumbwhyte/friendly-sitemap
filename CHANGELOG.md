# Change Log

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/) and this project adheres to [Semantic Versioning](https://semver.org/).

## [1.1.0] - 2020-08-17
### Added
* Default output can now be overwritten with `ISitemapBuilder` 

### Changed
* Including nodes with `umbracoNaviHide` in the sitemap
* Combined `SitemapConfigComposer` and `SitemapRouteComposer` into `SitemapComposer`

### Fixed
* Sitemap is UTF-8 encoded
* Empty `xmlns` attribute on `urlset` in the sitemap

## [1.0.0] - 2019-10-27
### Added
* Initial release of Friendly Sitemap for Umbraco 8.1

[Unreleased]: https://github.com/callumbwhyte/friendly-sitemap/compare/release-1.1.0...HEAD
[1.1.0]: https://github.com/callumbwhyte/friendly-sitemap/compare/release-1.1.0
[1.0.0]: https://github.com/callumbwhyte/friendly-sitemap/compare/release-1.0.0