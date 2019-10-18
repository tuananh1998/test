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
    public partial class frmdn : Form
    {

        public frmdn()
        {
            InitializeComponent();
            
        }
       
        
        int sai = 5;
        public string tk1 = "";
        Boolean kt = false;

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection ketnoi = new SqlConnection(truyxuat.con);
                ketnoi.Open();
                string tk = textBox1.Text.Trim();
                string mk = textBox2.Text.Trim();
                if (tk == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên tài khoản!", "Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Focus();
                }
                else
                {
                    if (mk == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mật khẩu!", "Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox2.Focus();
                    }
                    else
                    {
                        string taikhoan = "select count(*) from admin where tk='" + textBox1.Text + "' and mk='" + textBox2.Text + "'";
                        SqlCommand cm = new SqlCommand(taikhoan, ketnoi);
                        int i = (int)cm.ExecuteScalar();
                        cm.Dispose();
                        string tku = "select count(*) from nguoidung where tk='" + textBox1.Text + "' and mk='" + textBox2.Text + "'";
                        SqlCommand com = new SqlCommand(tku, ketnoi);
                        int j = (int)com.ExecuteScalar();
                        com.Dispose();
                        string tkgv = "select count(*) from giaovien where tk='" + textBox1.Text + "' and mk='" + textBox2.Text + "'";
                        SqlCommand comm = new SqlCommand(tkgv, ketnoi);
                        int k = (int)comm.ExecuteScalar();
                        comm.Dispose();
                        string tktk = "select count(*) from truongkhoa where tk='" + textBox1.Text + "' and mk='" + textBox2.Text + "'";
                        SqlCommand commm = new SqlCommand(tktk, ketnoi);
                        int l = (int)commm.ExecuteScalar();
                        commm.Dispose();
                        if (sai > 0)
                        {
                            if (i > 0)
                            {
                                tk1 = textBox1.Text;
                                this.Close();
                                MessageBox.Show("Bạn đã đăng nhập vào tài khoản Admin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                frmain f = new frmain("Admin");
                                f.Show();
                            }
                            else if (k > 0)
                            {
                                tk1 = textBox1.Text;
                                this.Close();
                                MessageBox.Show("Bạn đã đăng nhập vào tài khoản Giáo Viên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                frmain f = new frmain("Giáo Viên");
                                f.qladmin.Visible = false;
                                f.qlgv.Visible = false;
                                f.qltk.Visible = false;
                                f.qluser.Visible = false;
                                
                                //f_khoa kh = new f_khoa();
                                //kh.groupBox2.Visible = false;
                                //f_lop lop = new f_lop();
                                //lop.groupBox2.Visible = false;
                                //f_sv sv = new f_sv();
                                //sv.groupBox2.Visible = false;
                                //frm_CS cs = new frm_CS();
                                //cs.groupBox2.Visible = false;
                                //frm_monhoc mh = new frm_monhoc();
                                //mh.groupBox2.Visible = false;
                                //frm_diem diem = new frm_diem();
                                //diem.groupBox2.Visible = false;
                                //f.sinhViênToolStripMenuItem1.Visible = false;
                                //f.mônHọcToolStripMenuItem1.Visible = false;
                                //f.chínhSáchToolStripMenuItem1.Visible = false;
                                f.Show();
                            }
                            else if (j > 0)
                            {
                                tk1 = textBox1.Text;
                                this.Close();
                                MessageBox.Show("Bạn đã đăng nhập vào tài khoản User!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                frmain f = new frmain("User");
                                f.qladmin.Visible = false;
                                f.qlgv.Visible = false;
                                f.qltk.Visible = false;
                                f.qluser.Visible = false;
                                
                                f.Show();
                            }
                            else if (l > 0)
                            {
                                tk1 = textBox1.Text;
                                this.Close();
                                MessageBox.Show("Bạn đã đăng nhập vào tài khoản Trưởng khoa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                frmain f = new frmain("Trưởng Khoa");
                                f.qladmin.Visible = false;
                                f.qlgv.Visible = false;
                                f.qltk.Visible = false;
                                f.qluser.Visible = false;
                                f.Show();
                            }
                            else
                            {
                                sai = sai - 1;
                                MessageBox.Show("Username Hoặc Password sai ! Bạn còn " + sai + "Lần đăng nhập!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.textBox1.Clear();
                                this.textBox2.Clear();
                                this.textBox1.Focus();
                            }

                        }



                        else
                        {
                            MessageBox.Show("Đã hết lượt truy cập mời bạn đăng nhập lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                            Form1 f = new Form1();
                            f.Show();
                        }
                    }




                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Thao Tác không thực hiện được. Vui lòng kiểm tra lại!", "Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            }
            else
            {
                textBox2.UseSystemPasswordChar = true;


            }
        }
    }
}
