namespace SQLServer01
{
    partial class frmVIP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridMemberLsit = new System.Windows.Forms.DataGridView();
            this.bntInsert = new System.Windows.Forms.Button();
            this.bntExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridMemberLsit)).BeginInit();
            this.SuspendLayout();
            // 
            // gridMemberLsit
            // 
            this.gridMemberLsit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMemberLsit.Location = new System.Drawing.Point(264, 43);
            this.gridMemberLsit.Name = "gridMemberLsit";
            this.gridMemberLsit.Size = new System.Drawing.Size(453, 352);
            this.gridMemberLsit.TabIndex = 0;
            // 
            // bntInsert
            // 
            this.bntInsert.Location = new System.Drawing.Point(59, 43);
            this.bntInsert.Name = "bntInsert";
            this.bntInsert.Size = new System.Drawing.Size(75, 23);
            this.bntInsert.TabIndex = 1;
            this.bntInsert.Text = "Insert Items";
            this.bntInsert.UseVisualStyleBackColor = true;
            this.bntInsert.Click += new System.EventHandler(this.bntInsert_Click);
            // 
            // bntExit
            // 
            this.bntExit.Location = new System.Drawing.Point(50, 361);
            this.bntExit.Name = "bntExit";
            this.bntExit.Size = new System.Drawing.Size(75, 23);
            this.bntExit.TabIndex = 2;
            this.bntExit.Text = "Exit";
            this.bntExit.UseVisualStyleBackColor = true;
            this.bntExit.Click += new System.EventHandler(this.bntExit_Click);
            // 
            // frmVIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bntExit);
            this.Controls.Add(this.bntInsert);
            this.Controls.Add(this.gridMemberLsit);
            this.Name = "frmVIP";
            this.Text = "VIP management";
            this.Load += new System.EventHandler(this.frmVIP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridMemberLsit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridMemberLsit;
        private System.Windows.Forms.Button bntInsert;
        private System.Windows.Forms.Button bntExit;
    }
}