# FastImage

* FastImage finds the size and type of an image given its uri by fetching as little as needed
* Written in C#
* Inspired by https://github.com/sdsykes/fastimage

### Installation

* Download source code and build or
* Download FastImage.dll from [lib](lib) or
* Install using NuGet

### Installation NuGet

    PM> Install-Package FastImage

### Example

    FastImage fastImage = new FastImage(); 
    const string url = "http://localhost/FastImage/fastimage_csharp.png";
    ImageInfo result = fastImage.GetImageInfo(url);

## References

* https://github.com/sdsykes/fastimage

## Licence

MIT, see file ["MIT-LICENSE"](MIT-LICENSE)

[![githalytics.com alpha](https://cruel-carlota.pagodabox.com/c975b8428b97cd060336e6306124d910 "githalytics.com")](http://githalytics.com/ynrajasekhar/FastImage)
[![Bitdeli Badge](https://d2weczhvl823v0.cloudfront.net/ynrajasekhar/FastImage/trend.png)](https://bitdeli.com/free "Bitdeli Badge")
