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
            this.pictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // customPictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.GreenYellow;
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox.Image = global::PageDisplay.Properties.Resources.templateImage3;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "customPictureBox";
            this.pictureBox.Size = new System.Drawing.Size(833, 309);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.WaitOnLoad = true;
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.customPictureBoxMouseMove);
            // 
            // PageDisplayComponent
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.pictureBox);
            this.Name = "PageDisplayComponent";
            this.Size = new System.Drawing.Size(1012, 548);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.PageDisplayComponentScroll);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pictureBox;
    }
}
