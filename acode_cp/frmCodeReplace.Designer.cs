namespace acode
{
    partial class frmCodeReplace
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
            this.txtVName = new System.Windows.Forms.TextBox();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnChangeStr = new System.Windows.Forms.Button();
            this.btnChinese = new System.Windows.Forms.Button();
            this.btnSql = new System.Windows.Forms.Button();
            this.btnToPinYing = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtVName
            // 
            this.txtVName.Location = new System.Drawing.Point(21, 12);
            this.txtVName.Name = "txtVName";
            this.txtVName.Size = new System.Drawing.Size(129, 21);
            this.txtVName.TabIndex = 0;
            this.txtVName.Text = "strTableList";
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(21, 52);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBox1.Size = new System.Drawing.Size(235, 419);
            this.TextBox1.TabIndex = 1;
            this.TextBox1.DoubleClick += new System.EventHandler(this.TextBox1_DoubleClick);
            // 
            // TextBox2
            // 
            this.TextBox2.Location = new System.Drawing.Point(364, 52);
            this.TextBox2.Multiline = true;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBox2.Size = new System.Drawing.Size(433, 419);
            this.TextBox2.TabIndex = 2;
            this.TextBox2.DoubleClick += new System.EventHandler(this.TextBox2_DoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(273, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "生成过滤";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnChangeStr
            // 
            this.btnChangeStr.Location = new System.Drawing.Point(273, 90);
            this.btnChangeStr.Name = "btnChangeStr";
            this.btnChangeStr.Size = new System.Drawing.Size(75, 23);
            this.btnChangeStr.TabIndex = 4;
            this.btnChangeStr.Text = "生成转换";
            this.btnChangeStr.UseVisualStyleBackColor = true;
            this.btnChangeStr.Click += new System.EventHandler(this.btnChangeStr_Click);
            // 
            // btnChinese
            // 
            this.btnChinese.Location = new System.Drawing.Point(168, 10);
            this.btnChinese.Name = "btnChinese";
            this.btnChinese.Size = new System.Drawing.Size(75, 23);
            this.btnChinese.TabIndex = 5;
            this.btnChinese.Text = "保留汉字";
            this.btnChinese.UseVisualStyleBackColor = true;
            this.btnChinese.Click += new System.EventHandler(this.btnChinese_Click);
            // 
            // btnSql
            // 
            this.btnSql.Location = new System.Drawing.Point(273, 128);
            this.btnSql.Name = "btnSql";
            this.btnSql.Size = new System.Drawing.Size(75, 23);
            this.btnSql.TabIndex = 6;
            this.btnSql.Text = "生成SQL";
            this.btnSql.UseVisualStyleBackColor = true;
            this.btnSql.Click += new System.EventHandler(this.btnSql_Click);
            // 
            // btnToPinYing
            // 
            this.btnToPinYing.Location = new System.Drawing.Point(273, 166);
            this.btnToPinYing.Name = "btnToPinYing";
            this.btnToPinYing.Size = new System.Drawing.Size(75, 23);
            this.btnToPinYing.TabIndex = 7;
            this.btnToPinYing.Text = "转成拼音";
            this.btnToPinYing.UseVisualStyleBackColor = true;
            this.btnToPinYing.Click += new System.EventHandler(this.btnToPinYing_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(364, 30);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 16);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "加\\r\\n";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // frmCodeReplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 485);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnToPinYing);
            this.Controls.Add(this.btnSql);
            this.Controls.Add(this.btnChinese);
            this.Controls.Add(this.btnChangeStr);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.txtVName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCodeReplace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "代码过滤";
            this.Load += new System.EventHandler(this.frmCodeReplace_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVName;
        private System.Windows.Forms.TextBox TextBox1;
        private System.Windows.Forms.TextBox TextBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnChangeStr;
        private System.Windows.Forms.Button btnChinese;
        private System.Windows.Forms.Button btnSql;
        private System.Windows.Forms.Button btnToPinYing;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}