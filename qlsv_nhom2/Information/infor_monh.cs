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
    public partial class infor_monh : Form
    {
        public infor_monh()
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
                string sql = "select * from monhoc";
                dgvad.DataSource = truyxuat.laybang(sql);
                dgvad.Columns[0].HeaderText = "Mã Môn Học";
                dgvad.Columns[1].HeaderText = "Tên Môn Học";
                dgvad.Columns[2].HeaderText = "Số Tiết";
                dgvad.Columns[3].HeaderText = "Mã Giáo Viên";
                string sql1 = "select magv from ttgiaovien";
                comboBox1.DataSource = truyxuat.laybang(sql1);
                comboBox1.DisplayMember = "magv";
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
            comboBox1.Text = dgvad.CurrentRow.Cells[3].Value.ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txbAcc.Text.Trim().Equals(""))
            {
                string sql = "select * from monhoc";
                Information.Print.monhoc.p_mh f = new Print.monhoc.p_mh(sql);
                f.ShowDialog();
            }
            else
            {
                string sql = "select * from monhoc where mamh='" + txbAcc.Text.Trim() + "'";
                Information.Print.monhoc.p_mh f = new Print.monhoc.p_mh(sql);
                f.ShowDialog();
            }
        }

        private void dgvad_Click(object sender, EventArgs e)
        {
            Binding();
        }
    }
}
