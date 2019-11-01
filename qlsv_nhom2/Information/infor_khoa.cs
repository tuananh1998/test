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
    public partial class infor_khoa : Form
    {
        public infor_khoa()
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
                string sql = "select * from khoa";
                dgvad.DataSource = truyxuat.laybang(sql);
                dgvad.Columns[0].HeaderText = "Mã Khoa";
                dgvad.Columns[1].HeaderText = "Tên Khoa";
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



        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgvad_Click(object sender, EventArgs e)
        {
            Binding();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txbAcc.Text.Trim().Equals(""))
            {
                string sql = "select * from khoa";
                Information.Print.khoa.p_khoa f = new Print.khoa.p_khoa(sql);
                f.ShowDialog();
            }
            else
            {
                string sql = "select * from khoa where makhoa='" + txbAcc.Text.Trim() + "'";
                Information.Print.khoa.p_khoa f = new Print.khoa.p_khoa(sql);
                f.ShowDialog();
            }
          
        }
    }
}
