using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace acode
{
    public partial class SysConfig : Form
    {
        public SysConfig()
        {
            InitializeComponent();
        }

        private void SysConfig_Load(object sender, EventArgs e)
        {
            this.txtConn.Text =SysCommn .GetConn ();

            this.txtTabHtml .Text  = SysCommn.GetParameterValue("tabhtml");
            this.txtTopTdHtml.Text = SysCommn.GetParameterValue("toptdhtml");
            this.txtBottomTdHtml.Text = SysCommn.GetParameterValue("bottomtdhtml");
            this.txtTdHtml.Text = SysCommn.GetParameterValue("tdhtml");
            this.txtInputCss.Text = SysCommn.GetParameterValue("inputcss");
            this.txtBottonCss.Text = SysCommn.GetParameterValue("bottoncss");
            this.txtTextAreaCss.Text = SysCommn.GetParameterValue("textareacss");

            this.txtCommonFile.Text = SysCommn.GetParameterValue("commonfile");
            this.txtNamespace.Text = SysCommn.GetParameterValue("namespace");
            this.txtCreatePath.Text = SysCommn.GetParameterValue("createpath");
        }
       
        /// <summary>
        /// 保存操作
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="parameterValue"></param>
        public void UpdateSave(string parameterName, string parameterValue)
        {
            DbHelperOleDb.ExecuteSql("Update SysConfig set ParameterValue='" + parameterValue + "' where ParameterName='" + parameterName + "'");

        }

        private void btnAddUpdateSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.UpdateSave("tabhtml", this.txtTabHtml.Text);
                this.UpdateSave("toptdhtml", this.txtTopTdHtml.Text);
                this.UpdateSave("bottomtdhtml", this.txtBottomTdHtml.Text);
                this.UpdateSave("tdhtml", this.txtTdHtml.Text);
                this.UpdateSave("inputcss", this.txtInputCss.Text);
                this.UpdateSave("bottoncss", this.txtBottonCss.Text);
                this.UpdateSave("textareacss", this.txtTextAreaCss.Text);

                this.UpdateSave("conn", this.txtConn.Text);
                this.UpdateSave("namespace", this.txtNamespace.Text);
                this.UpdateSave("createpath", this.txtCreatePath.Text);
                this.UpdateSave("commonfile", this.txtCommonFile.Text);

                MessageBox.Show("操作成功");

                Control.NamespaceName = SysCommn.GetParameterValue("namespace");
                Control.CommonFile = SysCommn.GetParameterValue("commonfile");
                Control.TabHtml = SysCommn.GetParameterValue("tabhtml");
                Control.TdTopHtml = SysCommn.GetParameterValue("toptdhtml");
                Control.TdHtml = SysCommn.GetParameterValue("tdhtml");
                Control.TdButtomHtml = SysCommn.GetParameterValue("bottomtdhtml");
                Control.CreatePath = SysCommn.GetParameterValue("createpath");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}