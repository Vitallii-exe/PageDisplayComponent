namespace PageDisplay
{
    public partial class PageDisplayComponent : UserControl
    {
        public delegate void ScaleChanged(float scale);
        public event ScaleChanged scaleChanged;

        Image original = Properties.Resources.templateImage3;
        float currentScale = 1F;
        float[] scaleSteps = {0.25F, 0.5F, 1F, 1.5F, 2F, 3F, 4F, 5F};
        float scaleFixedStep = 0.5F;
        uint currentScaleStepIndex = 2;
        bool isScaleUp = false;
        int scrollStep = 20;
        int currentHScroll = 0;
        bool isScrollEditing = false;

        bool isBlockRedraw = false;

        public PageDisplayComponent()
        {
            InitializeComponent();
            pictureBox.Image = original;
            pictureBox.Size = new Size(pictureBox.Image.Width, pictureBox.Image.Height);
            scrollStep = HorizontalScroll.Maximum - HorizontalScroll.LargeChange;
            pictureBox.Location = ImageScaling.GetCoordToCenterElement(pictureBox.Size, Size);
        }

        public void RedrawToNewScaleСustomPictureBox()
        {
            isBlockRedraw = true;
            int newWidth = (int)(original.Width * currentScale);
            int newHeight = (int)(original.Height * currentScale);
            Size newScaledSize = new Size(newWidth, newHeight);
            if (newScaledSize != pictureBox.Size)
            {
                Size oldSize = pictureBox.Size;
                pictureBox.Size = new Size(newWidth, newHeight);
                if (newWidth < Width & newHeight < Height)
                {
                    pictureBox.Location = ImageScaling.GetCoordToCenterElement(pictureBox.Size, Size);
                }
                else
                {
                    Point relativeCursorPos = pictureBox.PointToClient(Cursor.Position);

                    pictureBox.Location = ImageScaling.GetCoordToScaleWithCursorBinding(relativeCursorPos,
                                                                                        pictureBox.Size, oldSize, 
                                                                                        pictureBox.Location);
                }
                scaleChanged?.Invoke(currentScale);
            }
            isBlockRedraw = false;
            //pictureBox.Refresh();
            return;
        }

        private void ScaleChangedByWheel(bool up)
        {
            bool isOutOfRange = false;
            if (up)
            {
                if (currentScaleStepIndex < scaleSteps.Length - 1)
                {
                    currentScaleStepIndex += 1;
                }
                else
                {
                    isOutOfRange = true;
                }
            }
            else
            {
                if (currentScaleStepIndex > 0)
                {
                    currentScaleStepIndex -= 1;
                }
                else
                {
                    isOutOfRange = true;
                }
            }
            if (!isOutOfRange)
            {
                currentScale = scaleSteps[currentScaleStepIndex];
            }
            else
            {
                if (up)
                {
                    currentScale += scaleFixedStep;
                }
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
            Graphics g = Graphics.FromImage(pictureBox.Image);
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
            //ImageScaling.ImageDisplayProperties horisontalImgDispProp = new ImageScaling.ImageDisplayProperties
            //                                                                (pictureBox.Image.Size, Size,
            //                                                                HorizontalScroll, currentScale, true);
            //ImageScaling.ImageDisplayProperties verticalImgDispProp = new ImageScaling.ImageDisplayProperties
            //                                                                (pictureBox.Image.Size, Size,
            //                                                                VerticalScroll, currentScale, false);
            //(int st, int fin) Visible = ImageScaling.GetPointVisibleArea(horisontalImgDispProp, pictureBox.Location.X);
            //(int st, int fin) Visible2 = ImageScaling.GetPointVisibleArea(verticalImgDispProp, pictureBox.Location.Y);
            //TmpDrawRect(Visible.st, Visible.fin, Visible2.st, Visible2.fin);
            // -----
            return;
        }
    }
}
