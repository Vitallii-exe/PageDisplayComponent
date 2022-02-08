namespace PageDisplay
{
    public class ImageScaling
    {
        const int scrollLineWidth = 25;
        public struct ImageDisplayProperties
        {
            public int imageWidth;
            public int imageHeight;

            public int scrollMaximum;
            public int scrollLargeChange;
            public int scrollValue;

            public float currentScale;

            public bool horisontal;

            public Size displaySize;

            public ImageDisplayProperties(Size image, Size dispSize, ScrollProperties scrollProperties, float currScale, bool isHorisonatal)
            {
                imageWidth = image.Width;
                imageHeight = image.Height;

                scrollMaximum = scrollProperties.Maximum;
                scrollLargeChange = scrollProperties.LargeChange;
                scrollValue = scrollProperties.Value;

                currentScale = currScale;
                horisontal = isHorisonatal;

                displaySize = dispSize;
            }

        };

        public static (int, int) GetPointVisibleArea(ImageDisplayProperties imgDispProp, int shift)
        {
            //Gets the start and end position of the visible area of ​​the image
            if (imgDispProp.imageHeight == 0 | imgDispProp.imageWidth == 0)
            {
                return (0, 0);
            }

            int scrollMaxValue = imgDispProp.scrollMaximum - imgDispProp.scrollLargeChange;

            float currentImageSize;
            int displaySize;
            if (imgDispProp.horisontal)
            {
                currentImageSize = imgDispProp.imageWidth * imgDispProp.currentScale;
                displaySize = imgDispProp.displaySize.Width - scrollLineWidth;
            }
            else
            {
                currentImageSize = imgDispProp.imageHeight * imgDispProp.currentScale;
                displaySize = imgDispProp.displaySize.Height - scrollLineWidth;
            }

            if (scrollMaxValue == 0)
            {
                //The maximum scroll value cannot be zero, visible area = all image
                return (0, (int)currentImageSize);
            }

            float scrollStep = (currentImageSize - displaySize) / scrollMaxValue;

            float correctionShift = -shift / imgDispProp.currentScale - scrollStep * imgDispProp.scrollValue / imgDispProp.currentScale;

            int leftBorder = (int)(correctionShift + scrollStep * imgDispProp.scrollValue / imgDispProp.currentScale);
            int rightBorder = leftBorder + (int)(displaySize / imgDispProp.currentScale) - 2;

            return (leftBorder, rightBorder);
        }

        public static Point GetCoordToCenterElement(Size elementSize, Size areaSize)
        {
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
