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
    public partial class infor_lop : Form
    {
        public infor_lop()
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
                string sql = "select * from lop";
                dgvad.DataSource = truyxuat.laybang(sql);
                dgvad.Columns[0].HeaderText = "Mã Lớp";
                dgvad.Columns[1].HeaderText = "Tên Lớp";
                dgvad.Columns[2].HeaderText = "Mã Khoa";

                comboBox1.DataSource = truyxuat.laybang("select * from khoa");
                comboBox1.DisplayMember = "makhoa";
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
            comboBox1.Text = dgvad.CurrentRow.Cells[2].Value.ToString();



        }
        private void infor_lop_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txbAcc.Text.Trim().Equals(""))
            {
                string sql = "select * from lop";
                Information.Print.lop.p_lop f = new Print.lop.p_lop(sql);
                f.ShowDialog();
            }
            else
            {
                string sql = "select * from lop where malop='" + txbAcc.Text.Trim() + "'";
                Information.Print.lop.p_lop f = new Print.lop.p_lop(sql);
                f.ShowDialog();
            }
            
        }
    }
}
