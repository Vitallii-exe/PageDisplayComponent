namespace PageDisplay
{
    public partial class PageDisplayComponent : UserControl
    {
        Image original = Image.FromFile("ImageTemplates\\templateImage3.jpg");
        float currentScale = 1F;
        float scaleStep = 0.1F;
        int scrollStep = 20;
        int currentHScroll = 0;
        bool isScrollEditing = false;

        Point customPictureBoxCursorPos = new Point(0, 0);
        Point componentCursorPos = new Point(0, 0);
        public PageDisplayComponent()
        {
            InitializeComponent();
            customPictureBox.Image = original;
            customPictureBox.Size = new Size(customPictureBox.Image.Width, customPictureBox.Image.Height);
            scrollStep = HorizontalScroll.Maximum - HorizontalScroll.LargeChange;
        }

        public void RedrawToNewScaleСustomPictureBox()
        {
            int newWidth = (int)(original.Width * currentScale);
            int newHeight = (int)(original.Height * currentScale);
            Size newScaledSize = new Size(newWidth, newHeight);
            if (newScaledSize != customPictureBox.Size)
            {
                CustomPictureBox buffer = customPictureBox;
                buffer.Size = new Size(newWidth, newHeight);
                //buffer.Location = ImageScaling.SetCenterElement(customPictureBoxCursorPos, componentCursorPos);
                customPictureBox = buffer;
            }
            return;
        }

        private void ScaleChangedByWheel(bool up)
        {
            if (up)
            {
                if (currentScale < 5F)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        currentScale += 0.02F;
                        RedrawToNewScaleСustomPictureBox();
                        Refresh();
                    }
                }
            }
            else if (currentScale - scaleStep > 0.2F)
            {
                for (int i = 0; i < 5; i++)
                {
                    currentScale -= 0.02F;
                    RedrawToNewScaleСustomPictureBox();
                    Refresh();
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

        public void Draw(int st, int fin, int stY, int finY)
        {
            //Temporary function to draw rect by coord
            Graphics g = Graphics.FromImage(customPictureBox.Image);
            Rectangle rect = new Rectangle(st, stY, fin-st, finY-stY);
            g.DrawRectangle(new Pen(Color.Red, .5f), rect);
            Refresh();
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

        private void PageDisplayComponentMouseMove(object sender, MouseEventArgs e)
        {
            componentCursorPos = e.Location;

        }

        private void customPictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            customPictureBoxCursorPos = e.Location;
        }
    }
}
