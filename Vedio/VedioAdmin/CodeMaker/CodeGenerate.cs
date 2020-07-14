using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeMaker.Helper;
namespace CodeMaker
{
    public partial class CodeGenerate : Form
    {
        public CodeGenerate()
        {
            InitializeComponent();
        }
        private string Columns = string.Empty;
        private void CodeGenerate_Load(object sender, EventArgs e)
        {
            DataSet ds = SQLHelper.ExecuteDataSet("select  *  from  sysobjects  where  xtype='U' order by name asc");
            this.cobTable.Items.Clear();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                this.cobTable.Items.Add(row["name"].ToString());
            }
        }

        private void cobTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = SQLHelper.ExecuteDataSet(" exec SysTable  '" + this.cobTable.SelectedItem.ToString() + "'");
            this.checkedListBox1.Items.Clear();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                this.checkedListBox1.Items.Add(row["column_name"].ToString(), true);
            }
            Columns = "|";
            for (int j = 0; j < checkedListBox1.Items.Count; j++)
            {
                if (checkedListBox1.GetItemChecked(j))
                {
                    Columns += checkedListBox1.Items[j].ToString() + "|";
                }
            }
        }

        /// <summary>
        /// 全选/取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                for (int j = 0; j < this.checkedListBox1.Items.Count; j++)
                {
                    checkedListBox1.SetItemChecked(j, true);
                }
            }
            else
            {
                for (int j = 0; j < this.checkedListBox1.Items.Count; j++)
                {
                    checkedListBox1.SetItemChecked(j, false);
                }
            }
            Columns = "|";
            for (int j = 0; j < checkedListBox1.Items.Count; j++)
            {
                if (checkedListBox1.GetItemChecked(j))
                {
                    Columns += checkedListBox1.Items[j].ToString() + "|";
                }
            }
        }

        private void btnModel_Click(object sender, EventArgs e)
        {
            string TableName = "";
            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }
            else
            {
                TableName = this.cobTable.SelectedItem.ToString().Trim();
            }
            this.txtValue.Text = HandlerHelper.CreateModel(TableName,Columns).ToString();
        }

        private void txtValue_DoubleClick(object sender, EventArgs e)
        {
            this.txtValue.SelectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.cobTable.SelectedItem == null)
            {
                MessageBox.Show("请选择表名!");
                return;
            }
            string tableName = this.cobTable.SelectedItem.ToString().Trim();
            txtValue.Text = HandlerHelper.CreateDAL(tableName,Columns).ToString();
        }
    }
}
