using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace acode
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.txtConn.Text = SysCommn.GetConn();
        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            DbHelperOleDb.ExecuteSql("Update SysConfig set ParameterValue='" + this.txtConn.Text.Trim() + "' where ParameterName='conn'");
            this.Hide ();
            Form1 frm = new Form1();

            Control.NamespaceName = SysCommn.GetParameterValue("namespace");
            Control.CommonFile = SysCommn.GetParameterValue("commonfile");
            Control.TabHtml = SysCommn.GetParameterValue("tabhtml");
            Control.TdTopHtml = SysCommn.GetParameterValue("toptdhtml");
            Control.TdHtml = SysCommn.GetParameterValue("tdhtml");
            Control.TdButtomHtml = SysCommn.GetParameterValue("bottomtdhtml");
            Control.CreatePath = SysCommn.GetParameterValue("createpath");

            frm.Show();
        }

        private void btnColse_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}