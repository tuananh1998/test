using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace qlsv_nhom2
{
    public partial class frmdk : Form
    {
        public frmdk()
        {
            InitializeComponent();
        }
        
        
        private void frmdk_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                string a = textBox2.Text;
                string b = textBox3.Text;
                if (textBox2.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu!", "Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox2.Focus();
                }
                else
                {
                    if (textBox3.Text.Trim() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập lại mật khẩu!", "Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBox3.Focus();
                    }
                    else
                    {
                        if (a == b)
                        {

                            if (textBox1.Text.Trim() == "")
                            {
                                MessageBox.Show("Bạn chưa nhập tên người dùng!", "Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                textBox1.Focus();
                            }

                            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "")
                            {
                                SqlConnection ketnoi = new SqlConnection(truyxuat.con);
                                ketnoi.Open();
                                string st = "select count(*) from nguoidung where tk='" + textBox1.Text + "'";
                                int i = 0;
                                SqlCommand cmd = new SqlCommand(st, ketnoi);
                                i = (int)cmd.ExecuteScalar();
                                if (i != 0)
                                {
                                    MessageBox.Show("Tài khoản đã được đăng ký. Vui lòng sử dụng tên khác!", "Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    textBox1.Focus();
                                    textBox1.Text = "";
                                    textBox2.Text = "";
                                    textBox3.Text = "";
                                }


                                else
                                {
                                    string s = "insert into nguoidung values('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "')";
                                    SqlCommand cm = new SqlCommand(s, ketnoi);
                                    cm.ExecuteNonQuery();

                                    if (MessageBox.Show("Đăng Ký thành công. Bạn muốn đăng nhập không?", "Đăng Ký", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        frmdn f = new frmdn();
                                        f.Show();
                                        this.Hide();
                                    }
                                    else
                                    {
                                        this.Hide();
                                    }

                                }
                                // this.Hide();
                            }
                        }

                        else
                        {
                            MessageBox.Show("Mật khẩu bạn nhập lại không khớp! Bạn vui lòng kiểm tra lại!", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox2.Clear();
                            textBox3.Clear();
                        }
                    }
                }
               
            }
            catch (Exception ex)
            {

                MessageBox.Show("Thao Tác không thực hiện được. Vui lòng kiểm tra lại!","Đăng Nhập",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
                textBox3.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                textBox3.UseSystemPasswordChar = true;

            }
        }
    }
}
