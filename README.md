# FastImage

* FastImage finds the size or type of an image given its uri by fetching as little as needed
* Written in C#
* Inspired by https://github.com/sdsykes/fastimage

### Installation

* Download source code and build or
* Download dll from lib [FastImage.dll](lib/FastImage.dll) or
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
