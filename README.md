# Umbraco Friendly Sitemap

<img src="docs/img/logo.png?raw=true" alt="Umbraco Friendly Sitemap" width="250" align="right" />

[![NuGet release](https://img.shields.io/nuget/v/Our.Umbraco.FriendlySitemap.svg)](https://www.nuget.org/packages/Our.Umbraco.FriendlySitemap/)
[![Our Umbraco project page](https://img.shields.io/badge/our-umbraco-orange.svg)](https://our.umbraco.com/projects/website-utilities/friendly-sitemap/)

Friendly Sitemap makes adding a dynamic `sitemap.xml` file to your Umbraco 8 website easy!

## Getting started

This package is supported on Umbraco 8.1+.

### Installation

Friendly Sitemap is available from Our Umbraco, NuGet, or as a manual download directly from GitHub.

#### Our Umbraco repository

You can find a downloadable package on the [Our Umbraco](https://our.umbraco.com/projects/website-utilities/friendly-sitemap/) site.

#### NuGet package repository

To [install from NuGet](https://www.nuget.org/packages/Our.Umbraco.FriendlySitemap/), run the following command in your instance of Visual Studio.

    PM> Install-Package Our.Umbraco.FriendlySitemap

## Usage

Once installed, the sitemap will be visible on the URL `/sitemap.xml`, such as `https://www.yoursite.com/sitemap.xml`. The items displayed in the sitemap will be specific to the current domain.

If a physical `sitemap.xml` file exists in your website, the dynamically generated sitemap will be disabled.

It is possible to disable the sitemap via an app setting in `web.config` file:

```
<add key="Umbraco.Sitemap.EnableSitemap" value="false" />
```

### Controlling output

By default the sitemap will include all content items within the current site with a template assigned.

Adding a true / false (boolean) property to any doctype with the alias `sitemapExclude` makes it possible to hide specific items from the sitemap.

All of the XML Sitemap v0.9 [tag definitions](https://www.sitemaps.org/protocol.html#xmlTagDefinitions) can be modified by adding properties with specific aliases to any doctype:

| Attribute  | Property alias    |
|------------|-------------------|
| url        | url               |
| lastmod    | updateDate        |
| changefreq | sitemapChangeFreq | 
| priority   | sitemapPriority   |

### Advanced configuration

It is possible to override the default configuration of the package using dependency injection, by registering a new instance of `SitemapConfiguration` within an `IUserComposer` class.

This is helpful for advanced configuration needs, such as defining unique settings per site in a multi-site Umbraco installation.

Here's an example:

```
using Our.Umbraco.FriendlySitemap.Startup;

[ComposeAfter(typeof(SitemapComposer))]
public class CustomSitemapComposer : IUserComposer
{
    public void Compose(Composition composition)
    {
        composition.Register(factory => GetConfiguration(), Lifetime.Request);
    }

    private SitemapConfiguration GetConfiguration()
    {
        var configuration = new SitemapConfiguration
        {
            EnableSitemap = true
        };

        return configuration;
    }
}
```

## Contribution guidelines

To raise a new bug, create an issue on the GitHub repository. To fix a bug or add new features, fork the repository and send a pull request with your changes. Feel free to add ideas to the repository's issues list if you would to discuss anything related to the library.

### Who do I talk to?

This project is maintained by [Callum Whyte](https://callumwhyte.com/) and contributors. If you have any questions about the project please get in touch on [Twitter](https://twitter.com/callumbwhyte), or by raising an issue on GitHub.

## Credits

The package logo uses the [Sitemap](https://thenounproject.com/term/search/2711731/) icon from the [Noun Project](https://thenounproject.com) by [Adrien Coquet](https://thenounproject.com/coquet_adrien/), licensed under [CC BY 3.0 US](https://creativecommons.org/licenses/by/3.0/us/).

### A special #h5yr to our contributors

* [Karl Tynan](https://github.com/karltynan)
* [Imran Haider](https://github.com/imranhaidercogworks)
* [Aaron Sadler](https://github.com/AaronSadlerUK)
* [Nik Rimington](https://github.com/NikRimington)
* [Jason Elkin](https://github.com/JasonElkin)

## License

Copyright &copy; 2019 [Callum Whyte](https://callumwhyte.com/), and other contributors

Licensed under the [MIT License](LICENSE.md).
