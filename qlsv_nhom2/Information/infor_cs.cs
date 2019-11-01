using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlsv_nhom2.Information
{
    public partial class infor_cs : Form
    {
        public infor_cs()
        {
            InitializeComponent();
            load();
        }
        SqlConnection s;
        public void load()
        {
            s = new SqlConnection(truyxuat.con);
            try
            {
                string sql = "select * from chinhsach";
                dgvad.DataSource = truyxuat.laybang(sql);
                dgvad.Columns[0].HeaderText = "Mã Chính Sách";
                dgvad.Columns[1].HeaderText = "Tên Chính Sách";
                dgvad.Columns[2].HeaderText = "Chế Độ";
            }
            catch (Exception e)
            {

                MessageBox.Show("Thao Tác không thực hiện được. Vui lòng kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Binding()
        {
            txbAcc.Text = dgvad.CurrentRow.Cells[0].Value.ToString();
            txbPas.Text = dgvad.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dgvad.CurrentRow.Cells[2].Value.ToString();


        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txbAcc.Text.Trim().Equals(""))
            {
                string sql = "select * from chinhsach";
                Information.Print.p_cs f = new Print.p_cs(sql);
                f.ShowDialog();
            }
            else
            {
                string sql = "select * from chinhsach where macs='" + txbAcc.Text.Trim() + "'";
                Information.Print.p_cs f = new Print.p_cs(sql);
                f.ShowDialog();
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgvad_Click(object sender, EventArgs e)
        {
            Binding();
        }
    }
}
