namespace PageDisplay
{
    public partial class PageDisplayComponent : UserControl
    {
        Image original = Properties.Resources.templateImage3;
        float currentScale = 1F;
        float[] scaleSteps = {0.1F, 0.1F, 0.1F, 0.2F, 0.2F, 0.5F, 0.5F, 1F};
        uint currentScaleStepIndex = 0;
        bool isScaleUp = false;
        int scrollStep = 20;
        int currentHScroll = 0;
        bool isScrollEditing = false;

        Point customPictureBoxCursorPos = new Point(0, 0);
        bool lockCursors = false;
        public PageDisplayComponent()
        {
            InitializeComponent();
            customPictureBox.Image = original;
            customPictureBox.Size = new Size(customPictureBox.Image.Width, customPictureBox.Image.Height);
            scrollStep = HorizontalScroll.Maximum - HorizontalScroll.LargeChange;
            customPictureBox.Location = ImageScaling.GetCoordToCenterElement(customPictureBox.Size, Size);
        }

        public void RedrawToNewScaleСustomPictureBox()
        {
            int newWidth = (int)(original.Width * currentScale);
            int newHeight = (int)(original.Height * currentScale);
            Size newScaledSize = new Size(newWidth, newHeight);
            if (newScaledSize != customPictureBox.Size)
            {
                Size oldSize = customPictureBox.Size;
                lockCursors = true;
                customPictureBox.Size = new Size(newWidth, newHeight);
                if (newWidth < Width & newHeight < Height)
                {
                    customPictureBox.Location = ImageScaling.GetCoordToCenterElement(customPictureBox.Size, Size);
                }
                else
                {
                    customPictureBox.Location = ImageScaling.GetCoordToScaleWithCursorBinding(customPictureBoxCursorPos, customPictureBox.Size, oldSize, customPictureBox.Location);
                }
                lockCursors = false;
            }
            return;
        }

        private void ScaleChangedByWheel(bool up)
        {
            if (up)
            {
                if (!isScaleUp)
                {
                    currentScaleStepIndex = 0;
                }
                if (currentScaleStepIndex < scaleSteps.Length - 1)
                {
                    currentScaleStepIndex += 1;
                }
                isScaleUp = true;
            }
            else
            {
                if (isScaleUp)
                {
                    currentScaleStepIndex = 0;
                }
                if (currentScaleStepIndex < scaleSteps.Length - 1)
                {
                    currentScaleStepIndex += 1;
                }
                isScaleUp = false;
            }
            if (isScaleUp)
            {
                currentScale += scaleSteps[currentScaleStepIndex];
            }
            else
            {
                currentScale -= scaleSteps[currentScaleStepIndex];
            }
            if (currentScale > 5F)
            {
                currentScale = 5F;
            }
            else if (currentScale < 0.2F)
            {
                currentScale = 0.2F;
            }
            RedrawToNewScaleСustomPictureBox();
            Refresh();
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

        public void TmpDrawRect(int st, int fin, int stY, int finY)
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
            (int st, int fin) Visible = ImageScaling.GetPointVisibleArea(horisontalImgDispProp, customPictureBox.Location.X);
            (int st, int fin) Visible2 = ImageScaling.GetPointVisibleArea(verticalImgDispProp, customPictureBox.Location.Y);
            TmpDrawRect(Visible.st, Visible.fin, Visible2.st, Visible2.fin);
            // -----
            return;
        }

        private void customPictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            if (!lockCursors)
            {
                customPictureBoxCursorPos = e.Location;
            }
            //System.Diagnostics.Debug.WriteLine("X - " + e.Location.X + " Y - " + e.Location.Y);
        }
    }
}
