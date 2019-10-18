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

namespace qlsv_nhom2.Search
{
    public partial class search_khoa : Form
    {
        public search_khoa()
        {
            InitializeComponent();
            load();
        }
        public void load()
        {

            try
            {
                string sql = "select * from khoa";
                dgvad.DataSource = truyxuat.laybang(sql);
                dgvad.Columns[0].HeaderText = "Mã Khoa";
                dgvad.Columns[1].HeaderText = "Tên Khoa";
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
                        int i = 0, j = 0, k = 0;
                        SqlConnection ketnoi = new SqlConnection(truyxuat.con);
                        ketnoi.Open();
                        string st = "select count(*) from khoa where makhoa like '%" + chuoi + "%' ";
                        string s1 = "select count(*) from khoa where tenkhoa like N'%" + chuoi + "%'";
                        
                        SqlCommand cmd = new SqlCommand(st, ketnoi);
                        i = (int)cmd.ExecuteScalar();
                        SqlCommand cmd1 = new SqlCommand(s1, ketnoi);
                        j = (int)cmd1.ExecuteScalar();
                        
                        if (key == 0)
                        {
                            if (i != 0)
                            {
                                string sql = "select * from khoa where makhoa like '%" + chuoi + "%' ";
                                dgvad.DataSource = truyxuat.laybang(sql);
                                txbAcc.Text = "";
                                txbAcc.Focus();

                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txbAcc.Focus();
                                txbAcc.Text = "";
                            }
                            
                        }
                        else if (key == 1)
                        {
                            if (j != 0)
                            {
                                string sql1 = "select * from khoa where tenkhoa like N'%" + chuoi + "%'";
                                dgvad.DataSource = truyxuat.laybang(sql1);
                                txbAcc.Text = "";
                                txbAcc.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txbAcc.Focus();
                                txbAcc.Text = "";
                            }
                           
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
    

