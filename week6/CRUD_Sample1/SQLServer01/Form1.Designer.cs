namespace SQLServer01
{
    partial class frmMain
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
            this.bntConnect = new System.Windows.Forms.Button();
            this.bntGetData = new System.Windows.Forms.Button();
            this.lstbrands = new System.Windows.Forms.ListBox();
            this.grdGridVew = new System.Windows.Forms.DataGridView();
            this.bntVIP = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdGridVew)).BeginInit();
            this.SuspendLayout();
            // 
            // bntConnect
            // 
            this.bntConnect.Location = new System.Drawing.Point(30, 47);
            this.bntConnect.Name = "bntConnect";
            this.bntConnect.Size = new System.Drawing.Size(166, 30);
            this.bntConnect.TabIndex = 0;
            this.bntConnect.Text = "Database Connect";
            this.bntConnect.UseVisualStyleBackColor = true;
            this.bntConnect.Click += new System.EventHandler(this.bntConnect_Click);
            // 
            // bntGetData
            // 
            this.bntGetData.Location = new System.Drawing.Point(30, 82);
            this.bntGetData.Name = "bntGetData";
            this.bntGetData.Size = new System.Drawing.Size(166, 30);
            this.bntGetData.TabIndex = 1;
            this.bntGetData.Text = "Get Data";
            this.bntGetData.UseVisualStyleBackColor = true;
            this.bntGetData.Click += new System.EventHandler(this.bntGetData_Click);
            // 
            // lstbrands
            // 
            this.lstbrands.FormattingEnabled = true;
            this.lstbrands.Location = new System.Drawing.Point(230, 33);
            this.lstbrands.Name = "lstbrands";
            this.lstbrands.Size = new System.Drawing.Size(143, 225);
            this.lstbrands.TabIndex = 2;
            this.lstbrands.SelectedIndexChanged += new System.EventHandler(this.lstbrands_SelectedIndexChanged);
            // 
            // grdGridVew
            // 
            this.grdGridVew.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdGridVew.Location = new System.Drawing.Point(397, 33);
            this.grdGridVew.Name = "grdGridVew";
            this.grdGridVew.Size = new System.Drawing.Size(364, 365);
            this.grdGridVew.TabIndex = 3;
            // 
            // bntVIP
            // 
            this.bntVIP.Location = new System.Drawing.Point(30, 226);
            this.bntVIP.Name = "bntVIP";
            this.bntVIP.Size = new System.Drawing.Size(166, 42);
            this.bntVIP.TabIndex = 4;
            this.bntVIP.Text = "VIP Management";
            this.bntVIP.UseVisualStyleBackColor = true;
            this.bntVIP.Click += new System.EventHandler(this.bntVIP_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 499);
            this.Controls.Add(this.bntVIP);
            this.Controls.Add(this.grdGridVew);
            this.Controls.Add(this.lstbrands);
            this.Controls.Add(this.bntGetData);
            this.Controls.Add(this.bntConnect);
            this.Name = "frmMain";
            this.Text = "Database";
            ((System.ComponentModel.ISupportInitialize)(this.grdGridVew)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bntConnect;
        private System.Windows.Forms.Button bntGetData;
        private System.Windows.Forms.ListBox lstbrands;
        private System.Windows.Forms.DataGridView grdGridVew;
        private System.Windows.Forms.Button bntVIP;
    }
}

