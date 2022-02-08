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
            this.customPictureBox.Image = global::PageDisplay.Properties.Resources.templateImage3;
            this.customPictureBox.Location = new System.Drawing.Point(0, 0);
            this.customPictureBox.Name = "customPictureBox";
            this.customPictureBox.Size = new System.Drawing.Size(833, 309);
            this.customPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.customPictureBox.TabIndex = 0;
            this.customPictureBox.TabStop = false;
            this.customPictureBox.WaitOnLoad = true;
            this.customPictureBox.scaleChanged += new PageDisplay.CustomPictureBox.ScaleChanged(this.ScaleChangedByWheel);
            this.customPictureBox.horisontalScroll += new PageDisplay.CustomPictureBox.HorisontalScroll(this.HorizontalScrollChanged);
            this.customPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.customPictureBoxMouseMove);
            // 
            // PageDisplayComponent
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.customPictureBox);
            this.Name = "PageDisplayComponent";
            this.Size = new System.Drawing.Size(1012, 548);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.PageDisplayComponentScroll);
            ((System.ComponentModel.ISupportInitialize)(this.customPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomPictureBox customPictureBox;
    }
}
