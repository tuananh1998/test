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
    public partial class infor_Diem : Form
    {
        public infor_Diem()
        {
            InitializeComponent();
        }
        SqlConnection s;
        public void load()
        {
            s = new SqlConnection(truyxuat.con);
            try
            {
                string sql = "select * from diem";
                dgvad.DataSource = truyxuat.laybang(sql);
                dgvad.Columns[0].HeaderText = "Mã ID";
                dgvad.Columns[1].HeaderText = "Mã Sinh Viên";
                dgvad.Columns[2].HeaderText = "Mã Môn Học";
                dgvad.Columns[3].HeaderText = "Điểm";
                comboBox1.DataSource = truyxuat.laybang("select * from monhoc");
                comboBox1.DisplayMember = "mamh";
                comboBox2.DataSource = truyxuat.laybang("select * from sinhvien");
                comboBox2.DisplayMember = "masv";
            }
            catch (Exception e)
            {

                MessageBox.Show("Thao Tác không thực hiện được. Vui lòng kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Binding()
        {
            txbAcc.Text = dgvad.CurrentRow.Cells[0].Value.ToString();
            comboBox2.Text = dgvad.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dgvad.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dgvad.CurrentRow.Cells[3].Value.ToString();


        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void infor_Diem_Load(object sender, EventArgs e)
        {
            load();
        }

        private void dgvad_Click(object sender, EventArgs e)
        {
            Binding();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txbAcc.Text.Trim().Equals(""))
            {
                string sql = "select * from diem";
                Information.Print.Diem.p_Diem f = new Print.Diem.p_Diem(sql);
                f.ShowDialog();
            }
            else
            {
                string sql = "select * from diem where id='" + txbAcc.Text.Trim() + "'";
                Information.Print.Diem.p_Diem f = new Print.Diem.p_Diem(sql);
                f.ShowDialog();
            }
        }
    }
}
