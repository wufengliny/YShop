namespace acode
{
    partial class SysConfig
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtConn = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCommonFile = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCreatePath = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTextAreaCss = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBottonCss = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtInputCss = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTdHtml = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddUpdateSave = new System.Windows.Forms.Button();
            this.txtBottomTdHtml = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTopTdHtml = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTabHtml = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据连接设置";
            // 
            // txtConn
            // 
            this.txtConn.Location = new System.Drawing.Point(106, 18);
            this.txtConn.Name = "txtConn";
            this.txtConn.Size = new System.Drawing.Size(473, 21);
            this.txtConn.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCommonFile);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtCreatePath);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtNamespace);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtConn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(853, 243);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "系统设置";
            // 
            // txtCommonFile
            // 
            this.txtCommonFile.Location = new System.Drawing.Point(106, 80);
            this.txtCommonFile.Multiline = true;
            this.txtCommonFile.Name = "txtCommonFile";
            this.txtCommonFile.Size = new System.Drawing.Size(732, 147);
            this.txtCommonFile.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 12;
            this.label11.Text = "全站公共文件";
            // 
            // txtCreatePath
            // 
            this.txtCreatePath.Location = new System.Drawing.Point(336, 45);
            this.txtCreatePath.Name = "txtCreatePath";
            this.txtCreatePath.Size = new System.Drawing.Size(243, 21);
            this.txtCreatePath.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(253, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "批量生成路径";
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(106, 49);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(129, 21);
            this.txtNamespace.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "命名空间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "表头Html";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTextAreaCss);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtBottonCss);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtInputCss);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtTdHtml);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnAddUpdateSave);
            this.groupBox2.Controls.Add(this.txtBottomTdHtml);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtTopTdHtml);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtTabHtml);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 273);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(853, 212);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "添加修改页面样式设置";
            // 
            // txtTextAreaCss
            // 
            this.txtTextAreaCss.Location = new System.Drawing.Point(496, 145);
            this.txtTextAreaCss.Name = "txtTextAreaCss";
            this.txtTextAreaCss.Size = new System.Drawing.Size(88, 21);
            this.txtTextAreaCss.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(389, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "TextArea样式名称";
            // 
            // txtBottonCss
            // 
            this.txtBottonCss.Location = new System.Drawing.Point(295, 144);
            this.txtBottonCss.Name = "txtBottonCss";
            this.txtBottonCss.Size = new System.Drawing.Size(88, 21);
            this.txtBottonCss.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(200, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "Botton样式名称";
            // 
            // txtInputCss
            // 
            this.txtInputCss.Location = new System.Drawing.Point(106, 145);
            this.txtInputCss.Name = "txtInputCss";
            this.txtInputCss.Size = new System.Drawing.Size(88, 21);
            this.txtInputCss.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "Text样式名称";
            // 
            // txtTdHtml
            // 
            this.txtTdHtml.Location = new System.Drawing.Point(106, 118);
            this.txtTdHtml.Name = "txtTdHtml";
            this.txtTdHtml.Size = new System.Drawing.Size(732, 21);
            this.txtTdHtml.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "表单元格Html";
            // 
            // btnAddUpdateSave
            // 
            this.btnAddUpdateSave.Location = new System.Drawing.Point(763, 174);
            this.btnAddUpdateSave.Name = "btnAddUpdateSave";
            this.btnAddUpdateSave.Size = new System.Drawing.Size(75, 23);
            this.btnAddUpdateSave.TabIndex = 15;
            this.btnAddUpdateSave.Text = "保存";
            this.btnAddUpdateSave.UseVisualStyleBackColor = true;
            this.btnAddUpdateSave.Click += new System.EventHandler(this.btnAddUpdateSave_Click);
            // 
            // txtBottomTdHtml
            // 
            this.txtBottomTdHtml.Location = new System.Drawing.Point(106, 89);
            this.txtBottomTdHtml.Name = "txtBottomTdHtml";
            this.txtBottomTdHtml.Size = new System.Drawing.Size(732, 21);
            this.txtBottomTdHtml.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "表尾合并列Html";
            // 
            // txtTopTdHtml
            // 
            this.txtTopTdHtml.Location = new System.Drawing.Point(106, 56);
            this.txtTopTdHtml.Name = "txtTopTdHtml";
            this.txtTopTdHtml.Size = new System.Drawing.Size(732, 21);
            this.txtTopTdHtml.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "表头合并列Html";
            // 
            // txtTabHtml
            // 
            this.txtTabHtml.Location = new System.Drawing.Point(106, 24);
            this.txtTabHtml.Name = "txtTabHtml";
            this.txtTabHtml.Size = new System.Drawing.Size(732, 21);
            this.txtTabHtml.TabIndex = 10;
            // 
            // SysConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 497);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SysConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统设置";
            this.Load += new System.EventHandler(this.SysConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTabHtml;
        private System.Windows.Forms.TextBox txtTopTdHtml;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddUpdateSave;
        private System.Windows.Forms.TextBox txtBottomTdHtml;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTdHtml;
        private System.Windows.Forms.TextBox txtBottonCss;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtInputCss;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTextAreaCss;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCommonFile;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCreatePath;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.Label label9;
    }
}