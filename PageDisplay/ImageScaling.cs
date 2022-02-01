namespace PageDisplay
{
    internal class ImageScaling
    {
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

        public static (int, int) GetPointVisibleArea(Image image, ScrollProperties scrollProp, float currScale, bool horisontal = false)
        {
            //Gets the start and end position of the visible area of ​​the image
            int scrollMaxValue = scrollProp.Maximum - scrollProp.LargeChange;
            float currentImageSize;
            if (horisontal)
            {
                currentImageSize = image.Width * currScale;
            }
            else
            {
                currentImageSize = image.Height * currScale;
            }
            float scrollStep = (currentImageSize - scrollProp.LargeChange) / scrollMaxValue;

            int leftBorder = (int)(scrollStep * scrollProp.Value / currScale);
            int rightBorder = leftBorder + (int)(scrollProp.LargeChange / currScale);

            return (leftBorder, rightBorder);
        }
    }
}
