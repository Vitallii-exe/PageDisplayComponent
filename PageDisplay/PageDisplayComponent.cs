namespace PageDisplay
{
    public partial class PageDisplayComponent : UserControl
    {
        Image original = Image.FromFile("templateImage.jpg");
        float currentScale = 1F;
        float scaleStep = 0.1F;
        int scrollStep = 10;
        int currentHScroll = 0;
        bool isScrollEditing = false;
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
            int newWidth = (int)(original.Width * currentScale);
            int newHeight = (int)(original.Height * currentScale);
            customPictureBox.Image = ImageScaling.ResizeBitmap((Bitmap)original, newWidth, newHeight, newWidth, newHeight);
            customPictureBox.Size = new Size(newWidth, newHeight);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            return;
        }

        private void HorizontalScrollChanged(bool up)
        {
            int newScrollValue;
            if (up)
            {
                newScrollValue = currentHScroll + scrollStep;

                if (newScrollValue > HorizontalScroll.Maximum - HorizontalScroll.LargeChange)
                {
                    newScrollValue = HorizontalScroll.Maximum - HorizontalScroll.LargeChange;
                }
            }
            else
            {
                newScrollValue = currentHScroll - scrollStep;

                if (newScrollValue < HorizontalScroll.Minimum)
                {
                    newScrollValue = HorizontalScroll.Minimum;
                }
            }
            isScrollEditing = true;
            currentHScroll = newScrollValue;
            if (HorizontalScroll.Value != newScrollValue)
            {
                HorizontalScroll.Value = currentHScroll;
                HorizontalScroll.Value = currentHScroll;
            }
            isScrollEditing = false;
            return;
        }

        private void PageDisplayComponentScroll(object sender, ScrollEventArgs e)
        {
            if (!isScrollEditing)
            {
                currentHScroll = HorizontalScroll.Value;
            }
            return;
        }
    }
}
