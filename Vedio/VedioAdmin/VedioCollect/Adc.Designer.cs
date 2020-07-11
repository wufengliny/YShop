namespace VedioCollect
{
    partial class Adc
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
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnzipai = new System.Windows.Forms.Button();
            this.txtbeginpage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtendpage = new System.Windows.Forms.TextBox();
            this.txterr = new System.Windows.Forms.TextBox();
            this.btnAsia = new System.Windows.Forms.Button();
            this.btnjuqing = new System.Windows.Forms.Button();
            this.btnwest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(34, 67);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(1467, 334);
            this.txtLog.TabIndex = 0;
            // 
            // btnzipai
            // 
            this.btnzipai.Location = new System.Drawing.Point(34, 800);
            this.btnzipai.Name = "btnzipai";
            this.btnzipai.Size = new System.Drawing.Size(109, 41);
            this.btnzipai.TabIndex = 1;
            this.btnzipai.Text = "采集自拍";
            this.btnzipai.UseVisualStyleBackColor = true;
            this.btnzipai.Click += new System.EventHandler(this.btnzipai_Click);
            // 
            // txtbeginpage
            // 
            this.txtbeginpage.Location = new System.Drawing.Point(76, 19);
            this.txtbeginpage.Name = "txtbeginpage";
            this.txtbeginpage.Size = new System.Drawing.Size(100, 28);
            this.txtbeginpage.TabIndex = 2;
            this.txtbeginpage.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "第";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "页";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "页";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "到第";
            // 
            // txtendpage
            // 
            this.txtendpage.Location = new System.Drawing.Point(264, 19);
            this.txtendpage.Name = "txtendpage";
            this.txtendpage.Size = new System.Drawing.Size(100, 28);
            this.txtendpage.TabIndex = 5;
            this.txtendpage.Text = "10";
            // 
            // txterr
            // 
            this.txterr.Location = new System.Drawing.Point(34, 429);
            this.txterr.Multiline = true;
            this.txterr.Name = "txterr";
            this.txterr.Size = new System.Drawing.Size(1467, 334);
            this.txterr.TabIndex = 8;
            // 
            // btnAsia
            // 
            this.btnAsia.Location = new System.Drawing.Point(169, 800);
            this.btnAsia.Name = "btnAsia";
            this.btnAsia.Size = new System.Drawing.Size(109, 41);
            this.btnAsia.TabIndex = 9;
            this.btnAsia.Text = "采集亚洲";
            this.btnAsia.UseVisualStyleBackColor = true;
            this.btnAsia.Click += new System.EventHandler(this.btnAsia_Click);
            // 
            // btnjuqing
            // 
            this.btnjuqing.Location = new System.Drawing.Point(297, 800);
            this.btnjuqing.Name = "btnjuqing";
            this.btnjuqing.Size = new System.Drawing.Size(109, 41);
            this.btnjuqing.TabIndex = 10;
            this.btnjuqing.Text = "采集剧情";
            this.btnjuqing.UseVisualStyleBackColor = true;
            this.btnjuqing.Click += new System.EventHandler(this.btnjuqing_Click);
            // 
            // btnwest
            // 
            this.btnwest.Location = new System.Drawing.Point(435, 800);
            this.btnwest.Name = "btnwest";
            this.btnwest.Size = new System.Drawing.Size(109, 41);
            this.btnwest.TabIndex = 11;
            this.btnwest.Text = "采集欧美";
            this.btnwest.UseVisualStyleBackColor = true;
            this.btnwest.Click += new System.EventHandler(this.btnwest_Click);
            // 
            // Adc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1513, 953);
            this.Controls.Add(this.btnwest);
            this.Controls.Add(this.btnjuqing);
            this.Controls.Add(this.btnAsia);
            this.Controls.Add(this.txterr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtendpage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbeginpage);
            this.Controls.Add(this.btnzipai);
            this.Controls.Add(this.txtLog);
            this.Name = "Adc";
            this.Text = "Adc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnzipai;
        private System.Windows.Forms.TextBox txtbeginpage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtendpage;
        private System.Windows.Forms.TextBox txterr;
        private System.Windows.Forms.Button btnAsia;
        private System.Windows.Forms.Button btnjuqing;
        private System.Windows.Forms.Button btnwest;
    }
}