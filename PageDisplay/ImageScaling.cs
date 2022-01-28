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
    }
}
