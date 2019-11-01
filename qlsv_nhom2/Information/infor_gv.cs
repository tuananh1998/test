using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlsv_nhom2.Information
{
    public partial class infor_gv : Form
    {
        public infor_gv()
        {
            InitializeComponent();
            load();
        }
        public void load()
        {

            try
            {
                string sql = "select * from ttgiaovien";
                dgvad.DataSource = truyxuat.laybang(sql);
                dgvad.Columns[0].HeaderText = "Mã Giáo Viên";
                dgvad.Columns[1].HeaderText = "Tên Giáo Viên";
                dgvad.Columns[2].HeaderText = "Giới Tính";
                dgvad.Columns[3].HeaderText = "Ngày Sinh";
                dgvad.Columns[4].HeaderText = "Số Điện Thoại";
                dgvad.Columns[5].HeaderText = "Địa Chỉ";


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



        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txbAcc.Text.Trim().Equals(""))
            {
                string sql = "select * from ttgiaovien";
                Information.Print.gv.p_gv f = new Print.gv.p_gv(sql);
                f.ShowDialog();
            }
            else
            {
                string sql = "select * from ttgiaovien where magv='" + txbAcc.Text.Trim() + "'";
                Information.Print.gv.p_gv f = new Print.gv.p_gv(sql);
                f.ShowDialog();
            }
           
        }

        private void dgvad_Click(object sender, EventArgs e)
        {
            Binding();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
