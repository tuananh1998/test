using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlsv_nhom2.Search
{
    public partial class search_sv : Form
    {
        public search_sv()
        {
            InitializeComponent();
            load();
        }
        public void load()
        {
            btnfind.ImageAlign = ContentAlignment.MiddleLeft;
            btnRs.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnfind.Image=Bitmap.FromFile(@"C:\Users\tuan anh\Desktop\LT_NET\Photo for Design Form\Photo for Design Form\Find.png");
            btnRs.Image = Bitmap.FromFile(@"C:\Users\tuan anh\Desktop\LT_NET\Photo for Design Form\Photo for Design Form\Load.png");
            btnClose.Image = Bitmap.FromFile(@"C:\Users\tuan anh\Desktop\LT_NET\Photo for Design Form\Photo for Design Form\PNG\yellow\18\close.png");
            

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
                comboBox1.SelectedIndex = 0;

            }
            catch (Exception e)
            {

                MessageBox.Show("Thao Tác không thực hiện được. Vui lòng kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnfind_Click(object sender, EventArgs e)
        {
            if (txbAcc.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập Từ khóa tìm kiếm!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbAcc.Focus();
            }
            else
            {
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn tìm kiếm theo trường nào!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    comboBox1.Text = "";
                }
                else
                {


                    try
                    {
                        string chuoi = txbAcc.Text.Trim();
                        int key = comboBox1.SelectedIndex;
                        if (key == 0)
                        {
                            string sql = "select * from sinhvien where masv like '%" + chuoi + "%' ";
                            dgvad.DataSource = truyxuat.laybang(sql);
                            txbAcc.Text = "";
                            txbAcc.Focus();
                        }
                        else if (key == 1)
                        {
                            string sql1 = "select * from sinhvien where tensv like N'%" + chuoi + "%'";
                            dgvad.DataSource = truyxuat.laybang(sql1);
                            txbAcc.Text = "";
                            txbAcc.Focus();
                        }
                        else if (key == 2)
                        {
                            string sql1 = "select * from sinhvien where gioitinh like N'%" + chuoi + "%'";
                            dgvad.DataSource = truyxuat.laybang(sql1);
                            txbAcc.Text = "";
                            txbAcc.Focus();
                        }
                        else if (key == 3)
                        {
                            string sql1 = "select * from sinhvien where ngaysinh = '" + chuoi + "'";
                            dgvad.DataSource = truyxuat.laybang(sql1);
                            txbAcc.Text = "";
                            txbAcc.Focus();
                        }
                        else if (key == 4)
                        {
                            string sql1 = "select * from sinhvien where sdt like '%" + chuoi + "%'";
                            dgvad.DataSource = truyxuat.laybang(sql1);
                            txbAcc.Text = "";
                            txbAcc.Focus();
                        }
                        else if (key == 5)
                        {
                            string sql1 = "select * from sinhvien where diachi like N'%" + chuoi + "%'";
                            dgvad.DataSource = truyxuat.laybang(sql1);
                            txbAcc.Text = "";
                            txbAcc.Focus();
                        }
                        else if (key == 6)
                        {
                            string sql1 = "select * from sinhvien where macs like '%" + chuoi + "%'";
                            dgvad.DataSource = truyxuat.laybang(sql1);
                            txbAcc.Text = "";
                            txbAcc.Focus();
                        }
                        else if (key == 7)
                        {
                            string sql1 = "select * from sinhvien where malop like '%" + chuoi + "%'";
                            dgvad.DataSource = truyxuat.laybang(sql1);
                            txbAcc.Text = "";
                            txbAcc.Focus();
                        }




                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Thao Tác không thực hiện được. Vui lòng kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void btnRs_Click(object sender, EventArgs e)
        {
            load();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
