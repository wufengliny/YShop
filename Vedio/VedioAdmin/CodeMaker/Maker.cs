using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeMaker
{
    public partial class Maker : Form
    {
        public Maker()
        {
            InitializeComponent();
            string defaultConn= System.Configuration.ConfigurationManager.AppSettings["defaultconn"];
            var list = System.Configuration.ConfigurationManager.AppSettings;
            List<string> listcons = new List<string>();
            foreach (var item in list)
            {
                if (item.ToString().StartsWith("conn"))
                {
                    this.cbb_conns.Items.Add(item); ;
                }
            }
            this.cbb_conns.SelectedItem = defaultConn;
        }

        private void btnColse_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            var list = System.Configuration.ConfigurationManager.AppSettings;
            List<string> listcons = new List<string>();
            foreach(var item in list)
            {
                if(item.ToString().StartsWith("conn"))
                {
                    listcons.Add(item.ToString());
                    string txtval = System.Configuration.ConfigurationManager.AppSettings[item.ToString()];
                }
            }

        }
    }
}
