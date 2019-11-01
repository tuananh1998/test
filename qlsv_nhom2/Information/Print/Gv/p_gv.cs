using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlsv_nhom2.Information.Print.gv
{
    public partial class p_gv : Form
    {
        
        public static string t;
        public p_gv(string sql)
        {
            InitializeComponent();
            t = sql;

        }

        public void loadrp(string s)
        {
            s = t;
            DataTable tb = new DataTable();
            tb = truyxuat.laybang(s);
            Print.Gv.in_gv r = new Gv.in_gv();
            r.SetDataSource(tb);
            crystalReportViewer1.ReportSource = r;
        }
        private void p_gv_Load(object sender, EventArgs e)
        {
            loadrp(t);
        }
    }
}
