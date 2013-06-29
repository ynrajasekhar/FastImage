using System.IO;
using System.Net;
using FastImage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FastImage.Tests
{
    
    
    /// <summary>
    ///This is a test class for FastImageTest and is intended
    ///to contain all FastImageTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FastImageTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetImageDetail
        ///</summary>
        [TestMethod()]
        public void GetImageDetailTest_Gif()
        {
            FastImage target = new FastImage(); 
            const string url = "http://localhost/FastImage/fastimage_csharp.gif";
            var expected = new ImageInfo { ImageFormat = ImageFormat.GIF, Width = 200, Height = 150 };
            ImageInfo actual = target.GetImageDetail(url);
            Assert.AreEqual(expected.ImageFormat, actual.ImageFormat);
            Assert.AreEqual(expected.Width, actual.Width);
            Assert.AreEqual(expected.Height, actual.Height);
        }
        [TestMethod()]
        public void GetImageDetailTest_Png()
        {
            FastImage target = new FastImage(); 
            const string url = "http://localhost/FastImage/fastimage_csharp.png";
            var expected = new ImageInfo { ImageFormat = ImageFormat.PNG, Width = 200, Height = 150 };
            ImageInfo actual = target.GetImageDetail(url);
            Assert.AreEqual(expected.ImageFormat, actual.ImageFormat);
            Assert.AreEqual(expected.Width, actual.Width);
            Assert.AreEqual(expected.Height, actual.Height);
        }
        [TestMethod()]
        public void GetImageDetailTest_Bmp()
        {
            FastImage target = new FastImage(); 
            const string url = "http://localhost/FastImage/fastimage_csharp.bmp";
            var expected = new ImageInfo {ImageFormat = ImageFormat.BMP, Width = 200, Height = 150};
            ImageInfo actual = target.GetImageDetail(url);
            Assert.AreEqual(expected.ImageFormat, actual.ImageFormat);
            Assert.AreEqual(expected.Width, actual.Width);
            Assert.AreEqual(expected.Height, actual.Height);
        }
        [TestMethod()]
        public void GetImageDetailTest_Jpg()
        {
            FastImage target = new FastImage();
            const string url = "http://localhost/FastImage/fastimage_csharp.jpg";
            var expected = new ImageInfo {ImageFormat = ImageFormat.JPEG, Width = 200, Height = 150};
            ImageInfo actual = target.GetImageDetail(url);
            Assert.AreEqual(expected.ImageFormat, actual.ImageFormat);
            Assert.AreEqual(expected.Width, actual.Width);
            Assert.AreEqual(expected.Height, actual.Height);
        }
        [TestMethod()]
        public void GetImageDetailTest_Tiff()
        {
            var target = new FastImage(); 
            const string url = "http://localhost/FastImage/fastimage_csharp.tif";
            var expected = new ImageInfo { ImageFormat = ImageFormat.TIFF, Width = 200, Height = 150 };
            ImageInfo actual = target.GetImageDetail(url);
            Assert.AreEqual(expected.ImageFormat, actual.ImageFormat);
            Assert.AreEqual(expected.Width, actual.Width);
            Assert.AreEqual(expected.Height, actual.Height);
        }
        [TestMethod()]
        public void GetImageDetailTest_Tiff1()
        {
            var target = new FastImage();
            for (int i = 1; i < 9; i++)
            {
                string url = "http://localhost/FastImage/tif/CCITT_" + i.ToString() + ".TIF";
                var expected = new ImageInfo { ImageFormat = ImageFormat.TIFF, Width = 1728, Height = 2376 };
                ImageInfo actual = target.GetImageDetail(url);
                Assert.AreEqual(expected.ImageFormat, actual.ImageFormat);
                Assert.AreEqual(expected.Width, actual.Width);
                Assert.AreEqual(expected.Height, actual.Height);
            }
        }
        [TestMethod()]
        public void GetImageDetailTest_Tiff_MM1()
        {
            var target = new FastImage();
            const string url = "http://localhost/FastImage/tif/GMARBLES.TIF";
            var expected = new ImageInfo { ImageFormat = ImageFormat.TIFF, Width = 1419, Height = 1001 };
            ImageInfo actual = target.GetImageDetail(url);
            Assert.AreEqual(expected.ImageFormat, actual.ImageFormat);
            Assert.AreEqual(expected.Width, actual.Width);
            Assert.AreEqual(expected.Height, actual.Height);
        }
        [TestMethod()]
        public void GetImageDetailTest_Tiff_MM2()
        {
            var target = new FastImage();
            const string url = "http://localhost/FastImage/tif/MARBLES.TIF";
            var expected = new ImageInfo { ImageFormat = ImageFormat.TIFF, Width = 1419, Height = 1001 };
            ImageInfo actual = target.GetImageDetail(url);
            Assert.AreEqual(expected.ImageFormat, actual.ImageFormat);
            Assert.AreEqual(expected.Width, actual.Width);
            Assert.AreEqual(expected.Height, actual.Height);
        }
        [TestMethod()]
        public void GetImageDetailTest_BenchMark()
        {
            string url = "http://upload.wikimedia.org/wikipedia/commons/b/b4/Mardin_1350660_1350692_33_images.jpg";
            var sw = new StreamWriter(@"d:\benchmark.txt");
            WebClient webClient = new WebClient();
            sw.WriteLine("DownloadStart:" + DateTime.Now.ToString());
            webClient.DownloadData(url);
            sw.WriteLine("DownloadEnd:" + DateTime.Now.ToString());
            sw.Flush();
            var target = new FastImage();
            var expected = new ImageInfo { ImageFormat = ImageFormat.JPEG, Width = 9545, Height = 6623 };
            sw.WriteLine("GetImageDetailStart:" + DateTime.Now.ToString());
            ImageInfo actual = target.GetImageDetail(url);
            sw.WriteLine("GetImageDetailEnd:" + DateTime.Now.ToString());
            Assert.AreEqual(expected.ImageFormat, actual.ImageFormat);
            Assert.AreEqual(expected.Width, actual.Width);
            Assert.AreEqual(expected.Height, actual.Height);
            sw.Flush();
            sw.Close();
        }
    }
}
