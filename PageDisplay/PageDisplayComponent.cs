namespace PageDisplay
{
    public partial class PageDisplayComponent : UserControl
    {
        Image original = Image.FromFile("templateImage.jpg");
        float currentScale = 1F;
        float scaleStep = 0.1F;
        public PageDisplayComponent()
        {
            InitializeComponent();
            customPictureBox.Image = original;
        }

        private void ScaleChangedWheel(bool up)
        {
            if (up)
            {
                currentScale += scaleStep;
            }
            else if (currentScale >= scaleStep)
            {
                currentScale -= scaleStep;
            }
            customPictureBox.Image = ImageScaling.ResizeBitmap((Bitmap)original, original.Width, original.Height, (int)(Width * currentScale), (int)(Height * currentScale));
            customPictureBox.Size = new Size((int)(Width * currentScale), (int)(Height * currentScale));
            GC.Collect();
            GC.WaitForPendingFinalizers();
            return;
        }
    }
}
