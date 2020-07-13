using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace acode
{
    public partial class UsualCode : Form
    {
        public UsualCode()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SysConfig set ");
            strSql.Append("ParameterValue=@ParameterValue");
            strSql.Append(" where ParameterName=@ParameterName");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ParameterValue", OleDbType.LongVarChar),
                    new OleDbParameter("@ParameterName", OleDbType.VarChar,50)
            };
            parameters[0].Value = txtCode.Text.Trim();
            parameters[1].Value = "usualcode";
            

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);

        }

        private void UsualCode_Load(object sender, EventArgs e)
        {
            txtCode.Text = SysCommn.GetUsualCode();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SysConfig set ");
            strSql.Append("ParameterValue=@ParameterValue");
            strSql.Append(" where ParameterName=@ParameterName");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ParameterValue", OleDbType.LongVarChar),
                    new OleDbParameter("@ParameterName", OleDbType.VarChar,50)
            };
            parameters[0].Value = txtCode.Text.Trim();
            parameters[1].Value = "usualcode";


            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);

            this.Close();
            
        }
    }
}