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
    public partial class search_gv : Form
    {
        public search_gv()
        {
            InitializeComponent();
            load();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
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
                comboBox1.SelectedIndex = 0;

            }
            catch (Exception e)
            {

                MessageBox.Show("Thao Tác không thực hiện được. Vui lòng kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txbAcc.Text.Trim()=="")
            {
                MessageBox.Show("Bạn chưa nhập Từ khóa tìm kiếm!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbAcc.Focus();
            }
            else
            {
                if (comboBox1.Text=="")
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
                        if (key==0)
                        {
                            string sql = "select * from ttgiaovien where magv like '%"+chuoi+"%' ";
                            dgvad.DataSource = truyxuat.laybang(sql);
                            txbAcc.Text = "";
                            txbAcc.Focus();
                        }
                        else if (key==1)
                        {
                            string sql1 = "select * from ttgiaovien where tengv like N'%" + chuoi + "%'";
                            dgvad.DataSource = truyxuat.laybang(sql1);
                            txbAcc.Text = "";
                            txbAcc.Focus();
                        }
                        else if (key==2)
                        {
                            string sql1 = "select * from ttgiaovien where gioitinh like N'%" + chuoi + "%'";
                            dgvad.DataSource = truyxuat.laybang(sql1);
                            txbAcc.Text = "";
                            txbAcc.Focus();
                        }
                        else if (key == 3)
                        {
                            string sql1 = "select * from ttgiaovien where ngaysinh = '" + chuoi + "'";
                            dgvad.DataSource = truyxuat.laybang(sql1);
                            txbAcc.Text = "";
                            txbAcc.Focus();
                        }
                        else if (key == 4)
                        {
                            string sql1 = "select * from ttgiaovien where sdt like '%" + chuoi + "%'";
                            dgvad.DataSource = truyxuat.laybang(sql1);
                            txbAcc.Text = "";
                            txbAcc.Focus();
                        }
                        else if (key == 5)
                        {
                            string sql1 = "select * from ttgiaovien where diachi like N'%" + chuoi + "%'";
                            dgvad.DataSource = truyxuat.laybang(sql1);
                            txbAcc.Text = "";
                            txbAcc.Focus();
                        }




                    }
                    catch (Exception )
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
    }
}
