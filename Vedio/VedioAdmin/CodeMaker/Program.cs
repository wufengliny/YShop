using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeMaker
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Maker ma = new Maker();
            ma.ShowDialog();
            if(ma.DialogResult==DialogResult.OK)
            {
                ma.Dispose();
                Application.Run(new CodeGenerate());
            }
            else if (ma.DialogResult == DialogResult.Cancel)
            {
                ma.Dispose();
                Application.Exit();
            }
            
        }
    }
}
