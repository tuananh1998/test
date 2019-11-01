using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlsv_nhom2.Information.Print.monhoc
{
    public partial class p_mh : Form
    {
        public static string t;
        public p_mh(string sql)
        {
            InitializeComponent();
            t = sql;

        }

        public void loadrp(string s)
        {
            s = t;
            DataTable tb = new DataTable();
            tb = truyxuat.laybang(s);
            Print.MonHoc.in_mh r = new MonHoc.in_mh();
            r.SetDataSource(tb);
            crystalReportViewer1.ReportSource = r;
        }
        private void p_mh_Load(object sender, EventArgs e)
        {
            loadrp(t);

        }
    }
}
