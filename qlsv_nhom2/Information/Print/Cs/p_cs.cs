using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
namespace qlsv_nhom2.Information.Print
{
    public partial class p_cs : Form
    {
        public static string t;
        public p_cs(string sql)
        {
            InitializeComponent();
            t = sql;
            
        }
        
        public void loadrp(string s)
        { 
            s = t;
            DataTable tb = new DataTable();
            tb = truyxuat.laybang(s);
            Print.Cs.in_cs r = new Cs.in_cs();
            r.SetDataSource(tb);
            crystalReportViewer1.ReportSource = r;
        }
        private void p_cs_Load(object sender, EventArgs e)
        {
            loadrp(t);
        }
    }
}
