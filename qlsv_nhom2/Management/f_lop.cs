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

namespace qlsv_nhom2
{
    public partial class f_lop : Form
    {
        public f_lop()
        {
            InitializeComponent();
            load();
        }
        SqlConnection s;
        public void load()
        {
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnRs.ImageAlign = ContentAlignment.MiddleLeft;
            btnEdit.ImageAlign = ContentAlignment.MiddleLeft;
            btnDel.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Image = Bitmap.FromFile(@"C:\Users\tuan anh\Desktop\LT_NET\Photo for Design Form\Photo for Design Form\PNG\yellow\18\add.png");
            btnEdit.Image = Bitmap.FromFile(@"C:\Users\tuan anh\Desktop\LT_NET\Photo for Design Form\Photo for Design Form\Save.png");
            btnDel.Image = Bitmap.FromFile(@"C:\Users\tuan anh\Desktop\LT_NET\Photo for Design Form\Photo for Design Form\PNG\yellow\18\del.png");
            btnRs.Image = Bitmap.FromFile(@"C:\Users\tuan anh\Desktop\LT_NET\Photo for Design Form\Photo for Design Form\Load.png");
            btnClose.Image = Bitmap.FromFile(@"C:\Users\tuan anh\Desktop\LT_NET\Photo for Design Form\Photo for Design Form\PNG\yellow\18\close.png");
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {



                if (txbAcc.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã Lớp!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txbAcc.Focus();
                }
                else
                {
                    if (txbPas.Text.Trim() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập Tên Lớp!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txbPas.Focus();
                    }


                    else
                    {
                        if (comboBox1.Text.Trim() == "")
                        {
                            MessageBox.Show("Bạn chưa nhập Mã Khoa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            comboBox1.Focus();
                        }
                    }

                } 
                
                
                
                if(txbAcc.Text.Trim() != ""&& txbPas.Text.Trim() != ""&& comboBox1.Text.Trim() != "")
                {
                    SqlConnection ketnoi = new SqlConnection(truyxuat.con);
                    ketnoi.Open();
                    // int id =Convert.ToInt32( txbAcc.Text.Trim());
                    string st = "select count(*) from lop where malop='" + txbAcc.Text + "'";
                    int i = 0;
                    SqlCommand cmd = new SqlCommand(st, ketnoi);
                    i = (int)cmd.ExecuteScalar();
                    if (i != 0)
                    {
                        MessageBox.Show("Mã Lớp đã được thêm. Vui lòng sử dụng Mã Lớp khác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        
                        txbAcc.Text = "";
                        txbPas.Text = "";
                        txbAcc.Focus();

                    }

                    else
                    {
                        string s = "insert into lop values('" + txbAcc.Text + "',N'" + txbPas.Text.Trim() + "','" + comboBox1.Text.Trim() + "')";
                        SqlCommand cm = new SqlCommand(s, ketnoi);
                        cm.ExecuteNonQuery();

                        MessageBox.Show("Thêm thành công!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load();
                        txbAcc.Text = "";
                        txbPas.Text = "";
                        txbAcc.Focus();
                        // this.Hide();
                    }


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Thao Tác không thực hiện được. Vui lòng kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {




                if (txbAcc.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã Lớp!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txbAcc.Focus();
                }
                else
                {
                    if (txbPas.Text.Trim() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập Tên Lớp!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txbPas.Focus();
                    }
                    else
                    {
                        if (comboBox1.Text.Trim() == "")
                        {
                            MessageBox.Show("Bạn chưa nhập Mã Khoa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            comboBox1.Focus();
                        }
                    }

                }



                if (txbAcc.Text.Trim() != "" && txbPas.Text.Trim() != "" && comboBox1.Text.Trim() != "")
                {
                    SqlConnection ketnoi = new SqlConnection(truyxuat.con);
                    ketnoi.Open();
                    //int id = Convert.ToInt32(txbAcc.Text.Trim());
                    string st = "select count(*) from lop where malop='" + txbAcc.Text + "'";
                    int i = 0;
                    SqlCommand cmd = new SqlCommand(st, ketnoi);
                    i = (int)cmd.ExecuteScalar();
                    if (i == 0)
                    {
                        MessageBox.Show("Mã Lớp không tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbAcc.Focus();
                        txbAcc.Text = "";
                        txbPas.Text = "";

                        

                    }


                    else
                    {
                        string s = "update lop set tenlop=N'" + txbPas.Text + "',makhoa='" + comboBox1.Text + "' where malop='" + txbAcc.Text + "'";
                        truyxuat.thaotac(s);

                        MessageBox.Show("Sửa thành công!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load();
                        txbAcc.Text = "";
                        txbPas.Text = "";
                        txbAcc.Focus();
                        // this.Hide();
                    }


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Thao Tác không thực hiện được. Vui lòng kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {



                if (txbAcc.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập Mã Lớp!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txbAcc.Focus();

                }

                else
                {
                    SqlConnection ketnoi = new SqlConnection(truyxuat.con);
                    ketnoi.Open();
                    //int id = Convert.ToInt32(txbAcc.Text.Trim());
                    string st = "select count(*) from lop where malop='" + txbAcc.Text + "'";
                    int i = 0;
                    SqlCommand cmd = new SqlCommand(st, ketnoi);
                    i = (int)cmd.ExecuteScalar();
                    if (i == 0)
                    {
                        MessageBox.Show("Mã Lớp không tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbAcc.Focus();
                        txbAcc.Text = "";
                        txbPas.Text = "";



                    }


                    else
                    {

                        if (MessageBox.Show("Bạn có muốn xóa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            string s = "delete from lop where malop='" + txbAcc.Text + "'";
                            truyxuat.thaotac(s);

                            MessageBox.Show("Xóa thành công!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            load();
                            txbAcc.Text = "";
                            txbPas.Text = "";
                            txbAcc.Focus();
                            // this.Hide();
                        }
                    }


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Thao Tác không thực hiện được. Vui lòng kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRs_Click(object sender, EventArgs e)
        {
            txbAcc.Clear();
            txbPas.Clear();
            
            txbAcc.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgvad_Click(object sender, EventArgs e)
        {
            Binding();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
        }

        private void dgvad_Click_1(object sender, EventArgs e)
        {
            Binding();
        }

        private void f_lop_Load(object sender, EventArgs e)
        {

        }
    }
}
