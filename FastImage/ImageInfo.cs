using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastImage
{
    public class ImageInfo
    {
        public ImageFormat ImageFormat { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public override string ToString()
        {
            return "{ImageFormat:" + ImageFormat + ", Width:" + Width + ", Height:" + Height + "}";
        }
    }
}
