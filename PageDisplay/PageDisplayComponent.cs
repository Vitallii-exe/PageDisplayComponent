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
                if (currentScale < 5F)
                {
                    //currentScale += scaleStep;
                    for (int i = 0; i < 5; i++)
                    {
                        currentScale += 0.02F;
                        customPictureBox.Refresh();
                    }
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
            var i = Width;
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

        public void Draw(int st, int fin, int stY, int finY)
        {
            //Temporary function to draw rect by coord
            Graphics g = Graphics.FromImage(customPictureBox.Image);
            Rectangle rect = new Rectangle(st, stY, fin-st, finY-stY);
            g.DrawRectangle(new Pen(Color.Red, .5f), rect);
            return;
        }

        private void PageDisplayComponentScroll(object sender, ScrollEventArgs e)
        {
            if (!isScrollEditing)
            {
                currentHScroll = HorizontalScroll.Value;
            }
            // Code for test calculating position of the visible area of ​​the image
            ImageScaling.ImageDisplayProperties horisontalImgDispProp = new ImageScaling.ImageDisplayProperties
                                                                            (customPictureBox.Image, 
                                                                            HorizontalScroll, currentScale, true);
            ImageScaling.ImageDisplayProperties verticalImgDispProp = new ImageScaling.ImageDisplayProperties
                                                                            (customPictureBox.Image,
                                                                            VerticalScroll, currentScale, false);
            (int st, int fin) Visible = ImageScaling.GetPointVisibleArea(horisontalImgDispProp);
            (int st, int fin) Visible2 = ImageScaling.GetPointVisibleArea(verticalImgDispProp);
            Draw(Visible.st, Visible.fin, Visible2.st, Visible2.fin);
            // -----
            return;
        }

        private void customPictureBoxPaint(object sender, PaintEventArgs e)
        {
            int newWidth = (int)(original.Width * currentScale);
            int newHeight = (int)(original.Height * currentScale);
            Size newScaledSize = new Size(newWidth, newHeight);
            if (newScaledSize != customPictureBox.Size)
            {
                customPictureBox.Size = new Size(newWidth, newHeight);
            }
            customPictureBox.Image = customPictureBox.Image;
            return;
        }
    }
}
