namespace PageDisplay
{
    partial class PageDisplayComponent
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.customPictureBox = new PageDisplay.CustomPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.customPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // customPictureBox
            // 
            this.customPictureBox.BackColor = System.Drawing.Color.GreenYellow;
            this.customPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.customPictureBox.Location = new System.Drawing.Point(0, 0);
            this.customPictureBox.Name = "customPictureBox";
            this.customPictureBox.Size = new System.Drawing.Size(1000, 1000);
            this.customPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.customPictureBox.TabIndex = 0;
            this.customPictureBox.TabStop = false;
            this.customPictureBox.scaleChanged += new PageDisplay.CustomPictureBox.ScaleChanged(this.ScaleChangedWheel);
            this.customPictureBox.horisontalScroll += new PageDisplay.CustomPictureBox.HorisontalScroll(this.HorizontalScrollChanged);
            this.customPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.customPictureBoxPaint);
            // 
            // PageDisplayComponent
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.customPictureBox);
            this.Name = "PageDisplayComponent";
            this.Size = new System.Drawing.Size(539, 58);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.PageDisplayComponentScroll);
            ((System.ComponentModel.ISupportInitialize)(this.customPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomPictureBox customPictureBox;
    }
}
