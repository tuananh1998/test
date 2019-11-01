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
    public partial class infor_sv : Form
    {
        public infor_sv()
        {
            InitializeComponent();
            load();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        SqlConnection s;
        public void load()
        {
            s = new SqlConnection(truyxuat.con);
            try
            {
                string sql = "select * from sinhvien";
                dgvad.DataSource = truyxuat.laybang(sql);
                dgvad.Columns[0].HeaderText = "Mã Sinh Viên";
                dgvad.Columns[1].HeaderText = "Tên Sinh Viên";
                dgvad.Columns[2].HeaderText = "Giới Tính";
                dgvad.Columns[3].HeaderText = "Ngày Sinh";
                dgvad.Columns[4].HeaderText = "Số Điện Thoại";
                dgvad.Columns[5].HeaderText = "Địa Chỉ";
                dgvad.Columns[6].HeaderText = "Mã Chính Sách";
                dgvad.Columns[7].HeaderText = "Mã Lớp";
                comboBox1.DataSource = truyxuat.laybang("select * from chinhsach");
                comboBox1.DisplayMember = "macs";
                comboBox2.DataSource = truyxuat.laybang("select * from lop");
                comboBox2.DisplayMember = "malop";
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
            dateTimePicker1.Text = dgvad.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dgvad.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dgvad.CurrentRow.Cells[5].Value.ToString();
            comboBox1.Text = dgvad.CurrentRow.Cells[6].Value.ToString();
            comboBox2.Text = dgvad.CurrentRow.Cells[7].Value.ToString();


        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txbAcc.Text.Trim().Equals(""))
            {
                string sql = "select * from sinhvien ";
                Information.Print.sv.p_sv f = new Print.sv.p_sv(sql);
                f.ShowDialog();
            }
            else
            {
                string sql = "select * from sinhvien where masv='"+txbAcc.Text.Trim()+"'";
                Information.Print.sv.p_sv f = new Print.sv.p_sv(sql);
                f.ShowDialog();
            }
           
        }

        private void dgvad_Click(object sender, EventArgs e)
        {
            Binding();
        }
    }
}
