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
    public partial class search_mh : Form
    {
        public search_mh()
        {
            InitializeComponent();
            load();
        }
        public void load()
        {
            btnfind.ImageAlign = ContentAlignment.MiddleLeft;
            btnRs.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnfind.Image = Bitmap.FromFile(@"C:\Users\tuan anh\Desktop\LT_NET\Photo for Design Form\Photo for Design Form\Find.png");
            btnRs.Image = Bitmap.FromFile(@"C:\Users\tuan anh\Desktop\LT_NET\Photo for Design Form\Photo for Design Form\Load.png");
            btnClose.Image = Bitmap.FromFile(@"C:\Users\tuan anh\Desktop\LT_NET\Photo for Design Form\Photo for Design Form\PNG\yellow\18\close.png");

            try
            {
                string sql = "select mamh,tenmh,sotiet,tengv from monhoc,ttgiaovien where monhoc.magv=ttgiaovien.magv";
            
                dgvad.DataSource = truyxuat.laybang(sql);
                dgvad.Columns[0].HeaderText = "Mã Môn Học";
                dgvad.Columns[1].HeaderText = "Tên Môn Học";
                dgvad.Columns[2].HeaderText = "Số Tiết";
                dgvad.Columns[3].HeaderText = "Tên Giáo Viên";
                comboBox1.SelectedIndex = 0;

            }
            catch (Exception e)
            {

                MessageBox.Show("Thao Tác không thực hiện được. Vui lòng kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void btnRs_Click(object sender, EventArgs e)
        {
            load();
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
                            string sql = "select mamh,tenmh,sotiet,tengv from monhoc,ttgiaovien where monhoc.magv=ttgiaovien.magv and mamh like '%" + chuoi + "%' ";
                            dgvad.DataSource = truyxuat.laybang(sql);
                            txbAcc.Text = "";
                            txbAcc.Focus();
                        }
                        else if (key == 1)
                        {
                            string sql1 = "select mamh,tenmh,sotiet,tengv from monhoc,ttgiaovien where monhoc.magv=ttgiaovien.magv and tenmh like N'%" + chuoi + "%'";
                            dgvad.DataSource = truyxuat.laybang(sql1);
                            txbAcc.Text = "";
                            txbAcc.Focus();
                        }
                        else if (key == 2)
                        {
                            int sot = Convert.ToInt32(txbAcc.Text.Trim());
                            string sql1 = "select * from monhoc where sotiet like '%" + sot + "%'";
                            dgvad.DataSource = truyxuat.laybang(sql1);
                            txbAcc.Text = "";
                            txbAcc.Focus();
                        }
                        else if (key == 3)
                        {
                            string sql1 = "select mamh,tenmh,sotiet,tengv from monhoc,ttgiaovien where monhoc.magv=ttgiaovien.magv and ttgiaovien.tengv like N'%" + chuoi + "%'";
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

        private void search_mh_Load(object sender, EventArgs e)
        {

        }
    }
}
