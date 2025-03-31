namespace FrmFractal01
{
    partial class FrmFractal01
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
            pictureBoxMandelBrot = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMandelBrot).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxMandelBrot
            // 
            pictureBoxMandelBrot.Location = new Point(12, 12);
            pictureBoxMandelBrot.Name = "pictureBoxMandelBrot";
            pictureBoxMandelBrot.Size = new Size(550, 550);
            pictureBoxMandelBrot.TabIndex = 0;
            pictureBoxMandelBrot.TabStop = false;
           // pictureBoxMandelBrot.Click += pictureBoxMandelBrot_Click;
            // 
            // FrmFractal01
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(579, 560);
            Controls.Add(pictureBoxMandelBrot);
            Name = "FrmFractal01";
            Text = "FractalMandelbrot";
            Load += FrmFractal01_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxMandelBrot).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxMandelBrot;
    }
}
