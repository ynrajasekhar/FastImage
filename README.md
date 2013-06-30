# FastImage

* FastImage finds the size or type of an image given its uri by fetching as little as needed
* Written in C#
* Inspired by https://github.com/sdsykes/fastimage

### Installation

PM> Install-Package FastImage

### Example

FastImage fastImage = new FastImage(); 
const string url = "http://localhost/FastImage/fastimage_csharp.png";
ImageInfo result = fastImage.GetImageInfo(url);

## References

* https://github.com/sdsykes/fastimage

## Licence

MIT, see file "MIT-LICENSE":MIT-LICENSE