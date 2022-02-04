namespace PageDisplay
{
    public class ImageScaling
    {
        public struct ImageDisplayProperties
        {
            public int imageWidth;
            public int imageHeight;

            public int scrollMaximum;
            public int scrollLargeChange;
            public int scrollValue;

            public float currentScale;

            public bool horisontal;

            public ImageDisplayProperties(Image image, ScrollProperties scrollProperties, float currScale, bool isHorisonatal)
            {
                imageWidth = image.Width;
                imageHeight = image.Height;

                scrollMaximum = scrollProperties.Maximum;
                scrollLargeChange = scrollProperties.LargeChange;
                scrollValue = scrollProperties.Value;

                currentScale = currScale;
                horisontal = isHorisonatal;
            }

        };
        public static Bitmap ResizeBitmap(Bitmap sourceBitmap, int picBoxWidth, int PicBoxHeight, int width, int height)
        {
            // Resizes the Bitmap and also shifts it by the given number of pixels.
            Bitmap result = new Bitmap(picBoxWidth, PicBoxHeight);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(sourceBitmap, 0, 0, width, height);
            }
            return result;
        }

        public static (int, int) GetPointVisibleArea(ImageDisplayProperties imgDispProp)
        {
            //Gets the start and end position of the visible area of ​​the image
            if (imgDispProp.imageHeight == 0 | imgDispProp.imageWidth == 0)
            {
                return (0, 0);
            }

            int scrollMaxValue = imgDispProp.scrollMaximum - imgDispProp.scrollLargeChange;

            float currentImageSize;
            if (imgDispProp.horisontal)
            {
                currentImageSize = imgDispProp.imageWidth * imgDispProp.currentScale;
            }
            else
            {
                currentImageSize = imgDispProp.imageHeight * imgDispProp.currentScale;
            }

            if (scrollMaxValue == 0)
            {
                //The maximum scroll value cannot be zero, visible area = all image
                return (0, (int)currentImageSize);
            }

            float scrollStep = (currentImageSize - imgDispProp.scrollLargeChange) / scrollMaxValue;

            int leftBorder = (int)(scrollStep * imgDispProp.scrollValue / imgDispProp.currentScale);
            int rightBorder = leftBorder + (int)(imgDispProp.scrollLargeChange / imgDispProp.currentScale) - 2;

            return (leftBorder, rightBorder);
        }

        public static Point GetCoordToCenterElement(Size elementSize, Size areaSize)
        {
            //Now it doesn't working correctly
            int xCoord = areaSize.Width / 2 - elementSize.Width / 2;
            int yCoord = areaSize.Height / 2 - elementSize.Height / 2;
            
            Point result = new Point(xCoord, yCoord);
            return result;
        }

        public static Point GetCoordToScaleWithCursorBinding(Point elementCursor, Size newSize, Size oldSize, Point currentLocation)
        {
            float diff = (float)newSize.Width / oldSize.Width;

            int xCoord = currentLocation.X + elementCursor.X - (int)(elementCursor.X * diff);
            int yCoord = currentLocation.Y + elementCursor.Y - (int)(elementCursor.Y * diff);
            Point result = new Point(xCoord, yCoord);
            return result;
        }
    }
}
