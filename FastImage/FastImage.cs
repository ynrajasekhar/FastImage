using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace FastImage
{
    public class FastImage
    {
        private Stream _stream;
        public ImageInfo GetImageInfo(string url)
        {

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            _stream = response.GetResponseStream();
            var imageInfo = new ImageInfo {ImageFormat = ImageFormat.NOTRECOGNISED};
            try
            {
                var c = GetBytes(2);
                if (c[0] == 0xff && c[1] == 0xd8)
                {
                    imageInfo.ImageFormat = ImageFormat.JPEG;
                    ParseSizeForJpeg(imageInfo);
                }
                else if (c[0] == 'B' && c[1] == 'M')
                {
                    imageInfo.ImageFormat = ImageFormat.BMP;
                    ParseSizeForBmp(imageInfo);
                }
                else if (c[0] == 'G' && c[1] == 'I')
                {
                    imageInfo.ImageFormat = ImageFormat.GIF;
                    ParseSizeForGif(imageInfo);
                }
                else if (c[0] == 0x89 && c[1] == 'P')
                {
                    imageInfo.ImageFormat = ImageFormat.PNG;
                    ParseSizeForPng(imageInfo);
                }
                else if (c[0] == 'I' && c[1] == 'I')
                {
                    imageInfo.ImageFormat = ImageFormat.TIFF;
                    ParseSizeForTiff(imageInfo,false);
                }
                else if (c[0] == 'M' && c[1] == 'M')
                {
                    imageInfo.ImageFormat = ImageFormat.TIFF;
                    ParseSizeForTiff(imageInfo, true);
                }
            }
            finally
            {
                if (_stream != null) _stream.Dispose();
            }
            return imageInfo;
        }

        private void ParseSizeForTiff(ImageInfo imageInfo, bool isBigEndian)
        {
            byte[] chars;
            GetBytes(2);
            chars = GetBytes(4);
            uint offset = BitConverter.ToUInt32(chars, 0);
            if(isBigEndian)
            {
                offset = EndianConverter.SwapUInt32(offset);
            }
            Skip((int)offset-8);
            chars = GetBytes(2);
            ushort tagCount = BitConverter.ToUInt16(chars,0);
            if(isBigEndian)
            {
                tagCount = EndianConverter.SwapUInt16(tagCount);
            }
            int width = -1;
            int height = -1;
            for (uint i = tagCount; i >= 1; i--)
            {
                chars = GetBytes(2);
                ushort type = BitConverter.ToUInt16(chars, 0);
                if(isBigEndian)
                {
                    type = EndianConverter.SwapUInt16(type);
                }
                chars =GetBytes(6);
                chars = GetBytes(2);
                ushort data = BitConverter.ToUInt16(chars, 0);
                if(isBigEndian)
                {
                    data = EndianConverter.SwapUInt16(data);
                }
                if (type == 256) //Width
                {
                    width = data;
                }
                else if (type == 257) //Height
                {
                    height = data;
                }
                if (width > 0 && height > 0)
                {
                    imageInfo.Width = width;
                    imageInfo.Height = height;
                    return;
                }
                GetBytes(2);
            }
        }
        
        private void ParseSizeForPng(ImageInfo imageInfo)
        {
            var c = GetBytes(25);
            imageInfo.Width = c[17];
            imageInfo.Height = c[21];
        }

        private void ParseSizeForGif(ImageInfo imageInfo)
        {
            var c = GetBytes(11);
            imageInfo.Width = c[4];
            imageInfo.Height = c[6];
        }

        private void ParseSizeForBmp(ImageInfo imageInfo)
        {
            var c = GetBytes(29);
            imageInfo.Width = c[16];
            imageInfo.Height = c[20];
        }

        private void ParseSizeForJpeg(ImageInfo imageInfo)
        {
            string state = "started";
            while (true)
            {
                byte[] c;
                if (state == "started")
                {
                    c = GetBytes(1);
                    state = (c[0] == 0xFF) ? "sof" : "started";
                }
                else if(state == "sof")
                {
                    c = GetBytes(1);
                    if(c[0] >= 0xe0 && c[0] <= 0xef)
                    {
                        state = "skipframe";
                    }
                    else if((c[0] >= 0xC0 && c[0] <= 0xC3) || (c[0] >= 0xC5 && c[0] <= 0xC7) || (c[0] >= 0xC9 && c[0] <= 0xCB) || (c[0] >= 0xCD && c[0] <= 0xCF))
                    {
                        state = "readsize";
                    }
                    else if(c[0] == 0xFF)
                    {
                        state = "sof";
                    }
                    else
                    {
                        state = "skipframe";
                    }
                }
                else if(state == "skipframe")
                {
                    c = GetBytes(2);
                    int skip = ReadInt(c)-2;
                    GetBytes(skip);
                    state = "started";
                }
                else if(state == "readsize")
                {
                    c = GetBytes(7);
                    imageInfo.Width = ReadInt(new[] { c[5], c[6] });
                    imageInfo.Height = ReadInt(new[] { c[3], c[4] });
                    return;
                }
            }
        }

        private byte[] GetBytes(int length)
        {
            var c = new byte[length];
            _stream.Read(c, 0, c.Length);
            return c;
        }

        private void Skip(int length)
        {
            int i = 0;
            while (i < length)
            {
                _stream.ReadByte();
                i++;
            }
        }

        private int ReadInt(byte[] chars)
        {
            return (chars[0] << 8) + chars[1];
        }
    }
}
