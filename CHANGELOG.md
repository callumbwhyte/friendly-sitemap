# Change Log

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/) and this project adheres to [Semantic Versioning](https://semver.org/).

## [1.2.0] - 2021-06-24
### Added
* Alternate (culture variant) URLs appear in sitemap with `hreflang`
* Google Images Sitemap for Umbraco 8.6
* Google News Sitemap for Umbraco 8.1
* Custom sitemaps and routes are registerable at startup
* `SitemapBuilderBase` for overriding specific elements of sitemaps

### Changed
* `ISitemapBuilder` takes a culture for multi-lingual content
* Sitemaps are cached for 15 minutes
* Default configuration is more easily extensible
* Default property aliases are configurable

### Fixed
* Corrected `sitemap.xml` schema.org namespace

## [1.1.1] - 2020-08-17
### Fixed
* Excluding content without templates from the sitemap

## [1.1.0] - 2020-08-17
### Added
* Default output can now be overwritten with `ISitemapBuilder`

### Changed
* Including content where `umbracoNaviHide` is set in the sitemap
* Combined `SitemapConfigComposer` and `SitemapRouteComposer` into `SitemapComposer`

### Fixed
* Sitemap is UTF-8 encoded
* Empty `xmlns` attribute on `urlset` in the sitemap

## [1.0.0] - 2019-10-27
### Added
* Initial release of Friendly Sitemap for Umbraco 8.1

[Unreleased]: https://github.com/callumbwhyte/friendly-sitemap/compare/release-1.2.1...HEAD
[1.2.0]: https://github.com/callumbwhyte/friendly-sitemap/compare/release-1.1.0...release-1.2.0
[1.1.1]: https://github.com/callumbwhyte/friendly-sitemap/compare/release-1.1.0...release-1.1.1
[1.1.0]: https://github.com/callumbwhyte/friendly-sitemap/compare/release-1.0.0...release-1.1.0
[1.0.0]: https://github.com/callumbwhyte/friendly-sitemap/tree/release-1.0.0