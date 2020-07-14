namespace CodeMaker
{
    partial class Maker
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbb_conns = new System.Windows.Forms.ComboBox();
            this.btnColse = new System.Windows.Forms.Button();
            this.btnConn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbb_conns);
            this.groupBox1.Controls.Add(this.btnColse);
            this.groupBox1.Controls.Add(this.btnConn);
            this.groupBox1.Location = new System.Drawing.Point(32, 46);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(471, 226);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库连接：";
            // 
            // cbb_conns
            // 
            this.cbb_conns.FormattingEnabled = true;
            this.cbb_conns.Location = new System.Drawing.Point(138, 67);
            this.cbb_conns.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbb_conns.Name = "cbb_conns";
            this.cbb_conns.Size = new System.Drawing.Size(180, 26);
            this.cbb_conns.TabIndex = 12;
            // 
            // btnColse
            // 
            this.btnColse.Location = new System.Drawing.Point(306, 154);
            this.btnColse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnColse.Name = "btnColse";
            this.btnColse.Size = new System.Drawing.Size(112, 44);
            this.btnColse.TabIndex = 11;
            this.btnColse.Text = "关闭";
            this.btnColse.UseVisualStyleBackColor = true;
            this.btnColse.Click += new System.EventHandler(this.btnColse_Click);
            // 
            // btnConn
            // 
            this.btnConn.Location = new System.Drawing.Point(20, 154);
            this.btnConn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConn.Name = "btnConn";
            this.btnConn.Size = new System.Drawing.Size(112, 44);
            this.btnConn.TabIndex = 10;
            this.btnConn.Text = "确定";
            this.btnConn.UseVisualStyleBackColor = true;
            this.btnConn.Click += new System.EventHandler(this.btnConn_Click);
            // 
            // Maker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 333);
            this.Controls.Add(this.groupBox1);
            this.Name = "Maker";
            this.Text = "Maker";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnColse;
        private System.Windows.Forms.Button btnConn;
        private System.Windows.Forms.ComboBox cbb_conns;
    }
}