namespace PageDisplay
{
    partial class DisplayForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pageDisplayComponent1 = new PageDisplay.PageDisplayComponent();
            this.SuspendLayout();
            // 
            // pageDisplayComponent1
            // 
            this.pageDisplayComponent1.AutoScroll = true;
            this.pageDisplayComponent1.Location = new System.Drawing.Point(12, 2);
            this.pageDisplayComponent1.Name = "pageDisplayComponent1";
            this.pageDisplayComponent1.Size = new System.Drawing.Size(1012, 548);
            this.pageDisplayComponent1.TabIndex = 0;
            this.pageDisplayComponent1.scaleChanged += new PageDisplayComponent.ScaleChanged (this.ProcessScaleChanging);
            // 
            // DisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1108, 550);
            this.Controls.Add(this.pageDisplayComponent1);
            this.Name = "DisplayForm";
            this.Text = "PageDisplayForm";
            this.ResumeLayout(false);

        }

        #endregion

        private PageDisplayComponent pageDisplayComponent1;
    }
}