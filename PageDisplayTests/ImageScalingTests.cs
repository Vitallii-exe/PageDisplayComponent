using Microsoft.VisualStudio.TestTools.UnitTesting;
using static PageDisplay.ImageScaling;

namespace PageDisplayTests
{
    [TestClass]
    public class ImageScalingTests
    {
        [TestMethod]
        public void GetPointVisibleArea_120Scale_220Scroll_Returns_183_1003()
        {
            ImageDisplayProperties imgDispProp = new ImageDisplayProperties();
            imgDispProp.currentScale = 1.2F;
            imgDispProp.horisontal = true;

            imgDispProp.imageHeight = 1152;
            imgDispProp.imageWidth = 2056;

            imgDispProp.scrollLargeChange = 987;
            imgDispProp.scrollMaximum = 2466;
            imgDispProp.scrollValue = 220;

            (int, int) result = GetPointVisibleArea(imgDispProp);
            Assert.AreEqual((183, 1003), result);
        }
        [TestMethod]
        public void GetPointVisibleArea_120Scale_480Scroll_Returns_400_833()
        {
            ImageDisplayProperties imgDispProp = new ImageDisplayProperties();
            imgDispProp.currentScale = 1.2F;
            imgDispProp.horisontal = false;

            imgDispProp.imageHeight = 1152;
            imgDispProp.imageWidth = 2056;

            imgDispProp.scrollLargeChange = 523;
            imgDispProp.scrollMaximum = 1381;
            imgDispProp.scrollValue = 480;

            (int, int) result = GetPointVisibleArea(imgDispProp);
            Assert.AreEqual((400, 833), result);
        }
        [TestMethod]
        public void GetPointVisibleArea_200Scale_0Scroll_Returns_0_491()
        {
            ImageDisplayProperties imgDispProp = new ImageDisplayProperties();
            imgDispProp.currentScale = 2F;
            imgDispProp.horisontal = true;

            imgDispProp.imageHeight = 1152;
            imgDispProp.imageWidth = 2056;

            imgDispProp.scrollLargeChange = 987;
            imgDispProp.scrollMaximum = 4110;
            imgDispProp.scrollValue = 0;

            (int, int) result = GetPointVisibleArea(imgDispProp);
            Assert.AreEqual((0, 491), result);
        }
        [TestMethod]
        public void GetPointVisibleArea_200Scale_480Scroll_Returns_240_499()
        {
            ImageDisplayProperties imgDispProp = new ImageDisplayProperties();
            imgDispProp.currentScale = 2F;
            imgDispProp.horisontal = false;

            imgDispProp.imageHeight = 1152;
            imgDispProp.imageWidth = 2056;

            imgDispProp.scrollLargeChange = 523;
            imgDispProp.scrollMaximum = 2302;
            imgDispProp.scrollValue = 480;

            (int, int) result = GetPointVisibleArea(imgDispProp);
            Assert.AreEqual((240, 499), result);
        }
        [TestMethod]
        public void GetPointVisibleArea_200Scale_3123Scroll_Returns_1562_2053()
        {
            ImageDisplayProperties imgDispProp = new ImageDisplayProperties();
            imgDispProp.currentScale = 2F;
            imgDispProp.horisontal = true;

            imgDispProp.imageHeight = 1152;
            imgDispProp.imageWidth = 2056;

            imgDispProp.scrollLargeChange = 987;
            imgDispProp.scrollMaximum = 4110;
            imgDispProp.scrollValue = 3123;

            (int, int) result = GetPointVisibleArea(imgDispProp);
            Assert.AreEqual((1562, 2053), result);
        }
        [TestMethod]
        public void GetPointVisibleArea_200Scale_1780Scroll_Returns_891_1150()
        {
            ImageDisplayProperties imgDispProp = new ImageDisplayProperties();
            imgDispProp.currentScale = 2F;
            imgDispProp.horisontal = false;

            imgDispProp.imageHeight = 1152;
            imgDispProp.imageWidth = 2056;

            imgDispProp.scrollLargeChange = 523;
            imgDispProp.scrollMaximum = 2302;
            imgDispProp.scrollValue = 1780;

            (int, int) result = GetPointVisibleArea(imgDispProp);
            Assert.AreEqual((891, 1150), result);
        }
    }
}