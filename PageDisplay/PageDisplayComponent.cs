namespace PageDisplay
{
    public partial class PageDisplayComponent : UserControl
    {
        Image original = Image.FromFile("templateImage.jpg");
        float currentScale = 1F;
        float scaleStep = 0.1F;
        int scrollStep = 20;
        int currentHScroll = 0;
        bool isScrollEditing = false;
        public PageDisplayComponent()
        {
            InitializeComponent();
            customPictureBox.Image = original;
            customPictureBox.Size = new Size(customPictureBox.Image.Width, customPictureBox.Image.Height);
        }

        private void ScaleChangedWheel(bool up)
        {
            if (up)
            {
                //currentScale += scaleStep;
                for (int i = 0; i < 5; i++)
                {
                    currentScale += 0.02F;
                    customPictureBox.Refresh();
                }
            }
            else if (currentScale - scaleStep > 0.2F)
            {
                for (int i = 0; i < 5; i++)
                {
                    currentScale -= 0.02F;
                    customPictureBox.Refresh();
                }
            }
            customPictureBox.Refresh();
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

        private void customPictureBoxPaint(object sender, PaintEventArgs e)
        {
            int newWidth = (int)(original.Width * currentScale);
            int newHeight = (int)(original.Height * currentScale);
            customPictureBox.Size = new Size(newWidth, newHeight);
            return;
        }
    }
}
