using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlsv_nhom2.Information.Print.khoa
{
    public partial class p_khoa : Form
    {
        
        public static string t;
        public p_khoa(string sql)
        {
            InitializeComponent();
            t = sql;

        }

        public void loadrp(string s)
        {
            s = t;
            DataTable tb = new DataTable();
            tb = truyxuat.laybang(s);
            Print.Khoa.in_khoa r = new Khoa.in_khoa();
            r.SetDataSource(tb);
            crystalReportViewer1.ReportSource = r;
        }
        private void p_khoa_Load(object sender, EventArgs e)
        {
            loadrp(t);
        }
    }
}
