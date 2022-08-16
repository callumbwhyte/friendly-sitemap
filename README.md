# Umbraco Friendly Sitemap

<img src="docs/img/logo.png?raw=true" alt="Umbraco Friendly Sitemap" width="250" align="right" />

Friendly Sitemap makes adding dynamic `sitemap.xml` files to your Umbraco website easy!

Friendly Sitemap creates a fully compliant XML sitemap for Google search, Google Images, or Google News, for your content with no code necessary.

| Package          | NuGet            | Our Umbraco      |
|------------------|------------------|------------------|
| Friendly Sitemap | [![NuGet](https://img.shields.io/nuget/v/Our.Umbraco.FriendlySitemap.svg)](https://www.nuget.org/packages/Our.Umbraco.FriendlySitemap/) | [![Our Umbraco](https://img.shields.io/badge/our-umbraco-orange.svg)](https://our.umbraco.com/projects/website-utilities/friendly-sitemap/) |
| Image Sitemap    | [![NuGet](https://img.shields.io/nuget/v/Our.Umbraco.FriendlySitemap.Images.svg)](https://www.nuget.org/packages/Our.Umbraco.FriendlySitemap.Images/) |
| News Sitemap     | [![NuGet](https://img.shields.io/nuget/v/Our.Umbraco.FriendlySitemap.News.svg)](https://www.nuget.org/packages/Our.Umbraco.FriendlySitemap.News/) |

## Getting started

Friendly Sitemap and the [News Sitemap](https://www.nuget.org/packages/Our.Umbraco.FriendlySitemap.News/) are supported on Umbraco 8.1+.

The [Image Sitemap](https://www.nuget.org/packages/Our.Umbraco.FriendlySitemap.Images/) requires Umbraco 8.6+.

### Installation

Friendly Sitemap is available from Our Umbraco, NuGet, or as a manual download directly from GitHub.

#### Our Umbraco repository

You can find a downloadable package on the [Our Umbraco](https://our.umbraco.com/projects/website-utilities/friendly-sitemap/) site.

#### NuGet package repository

To [install from NuGet](https://www.nuget.org/packages/Our.Umbraco.FriendlySitemap/), run the following command in your instance of Visual Studio.

    PM> Install-Package Our.Umbraco.FriendlySitemap

## Usage

Once installed the sitemap must be enabled via an app setting in the `web.config` file:

```
<add key="Umbraco.Sitemap.Enable" value="true" />
```

To exclude certain document types from the sitemap 
```
<add key="Umbraco.Sitemap.Exclude" value="docType1,doctype2" />
```


The sitemap will be visible on the URL `/sitemap.xml`, such as `https://www.yoursite.com/sitemap.xml`. If installed, the [Image Sitemap](https://www.nuget.org/packages/Our.Umbraco.FriendlySitemap.Images/) will be visible on the URL `/sitemap_images.xml` while the [News Sitemap](https://www.nuget.org/packages/Our.Umbraco.FriendlySitemap.News/) will be visible on the URL `/sitemap_news.xml`.

All links displayed in a sitemap are specific to the current domain and culture.

If a physical `sitemap.xml` file exists in your website, the dynamically generated sitemap will be disabled.

The [project wiki](https://github.com/callumbwhyte/friendly-sitemap/wiki) contains further details about the advanced configuration options available, including creating custom sitemaps.

## Contribution guidelines

To raise a new bug, create an issue on the GitHub repository. To fix a bug or add new features, fork the repository and send a pull request with your changes. Feel free to add ideas to the repository's issues list if you would to discuss anything related to the library.

### Who do I talk to?

This project is maintained by [Callum Whyte](https://callumwhyte.com/) and contributors. If you have any questions about the project please get in touch on [Twitter](https://twitter.com/callumbwhyte), or by raising an issue on GitHub.

## Credits

The Friendly Sitemap logo uses the [Sitemap](https://thenounproject.com/term/sitemap/2711731/) icon from the [Noun Project](https://thenounproject.com) by [Adrien Coquet](https://thenounproject.com/coquet_adrien/), licensed under [CC BY 3.0 US](https://creativecommons.org/licenses/by/3.0/us/).

The [Image Sitemap](https://www.nuget.org/packages/Our.Umbraco.FriendlySitemap.Images/) logo uses the [Images](https://thenounproject.com/term/images/225394/) icon from the [Noun Project](https://thenounproject.com) by [Javi Ayala](https://thenounproject.com/javi_al/), licensed under [CC BY 3.0 US](https://creativecommons.org/licenses/by/3.0/us/).

The [News Sitemap](https://www.nuget.org/packages/Our.Umbraco.FriendlySitemap.News/) logo uses the [News](https://thenounproject.com/term/news/1901962/) icon from the [Noun Project](https://thenounproject.com) by [Shashank Singh](https://thenounproject.com/rshashank19/), licensed under [CC BY 3.0 US](https://creativecommons.org/licenses/by/3.0/us/).

### A special #h5yr to our contributors

* [Karl Tynan](https://github.com/karltynan)
* [Imran Haider](https://github.com/imranhaidercogworks)
* [Aaron Sadler](https://github.com/AaronSadlerUK)
* [Nik Rimington](https://github.com/NikRimington)
* [Jason Elkin](https://github.com/JasonElkin)

## License

Copyright &copy; 2021 [Callum Whyte](https://callumwhyte.com/), and other contributors

Licensed under the [MIT License](LICENSE.md).