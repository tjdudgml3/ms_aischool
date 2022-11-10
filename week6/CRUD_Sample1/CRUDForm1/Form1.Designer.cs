namespace CRUDForm1
{
    partial class frmMain
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
            this.bntConnet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bntConnent
            // 
            this.bntConnent.Location = new System.Drawing.Point(307, 350);
            this.bntConnent.Name = "bntConnent";
            this.bntConnent.Size = new System.Drawing.Size(136, 25);
            this.bntConnent.TabIndex = 0;
            this.bntConnent.Text = "Database Connect";
            this.bntConnent.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bntConnent);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
    }
}