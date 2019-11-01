using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlsv_nhom2.Information.Print.Diem
{
    public partial class p_Diem : Form
    {
        public static string t;
        public p_Diem(string sql)
        {
            InitializeComponent();
            t = sql;

        }

        public void loadrp(string s)
        {
            s = t;
            DataTable tb = new DataTable();
            tb = truyxuat.laybang(s);
            Print.Diem.in_Diem r = new Diem.in_Diem();
            r.SetDataSource(tb);
            crystalReportViewer1.ReportSource = r;
        }
        private void p_Diem_Load(object sender, EventArgs e)
        {
            loadrp(t);
        }
    }
}
