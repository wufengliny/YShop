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
            this.btnColse = new System.Windows.Forms.Button();
            this.btnConn = new System.Windows.Forms.Button();
            this.txtConn = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnColse);
            this.groupBox1.Controls.Add(this.btnConn);
            this.groupBox1.Controls.Add(this.txtConn);
            this.groupBox1.Location = new System.Drawing.Point(31, 46);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(848, 225);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库连接：";
            // 
            // btnColse
            // 
            this.btnColse.Location = new System.Drawing.Point(497, 112);
            this.btnColse.Margin = new System.Windows.Forms.Padding(4);
            this.btnColse.Name = "btnColse";
            this.btnColse.Size = new System.Drawing.Size(112, 44);
            this.btnColse.TabIndex = 11;
            this.btnColse.Text = "关闭";
            this.btnColse.UseVisualStyleBackColor = true;
            this.btnColse.Click += new System.EventHandler(this.btnColse_Click);
            // 
            // btnConn
            // 
            this.btnConn.Location = new System.Drawing.Point(188, 112);
            this.btnConn.Margin = new System.Windows.Forms.Padding(4);
            this.btnConn.Name = "btnConn";
            this.btnConn.Size = new System.Drawing.Size(112, 44);
            this.btnConn.TabIndex = 10;
            this.btnConn.Text = "确定";
            this.btnConn.UseVisualStyleBackColor = true;
            // 
            // txtConn
            // 
            this.txtConn.Location = new System.Drawing.Point(31, 29);
            this.txtConn.Margin = new System.Windows.Forms.Padding(4);
            this.txtConn.Multiline = true;
            this.txtConn.Name = "txtConn";
            this.txtConn.Size = new System.Drawing.Size(793, 60);
            this.txtConn.TabIndex = 9;
            // 
            // Maker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 333);
            this.Controls.Add(this.groupBox1);
            this.Name = "Maker";
            this.Text = "Maker";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnColse;
        private System.Windows.Forms.Button btnConn;
        private System.Windows.Forms.TextBox txtConn;
    }
}