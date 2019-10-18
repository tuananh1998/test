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
    public partial class f_resetpass : Form
    {
        public f_resetpass()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)

        {

            if (txbTK.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập tài khoản!","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txbTK.Focus();

            }
            else
            {
                if (txbOMK.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu cũ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbOMK.Focus();
                }
                else
                {
                    if (txbNMK.Text=="")
                    {
                        MessageBox.Show("Bạn hãy nhập mật khẩu mới!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbNMK.Focus();
                    }
                    else
                    {
                        if (txbRNMK.Text=="")
                        {
                            MessageBox.Show("Bạn hãy nhập lại mật khẩu mới!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txbRNMK.Focus();
                        }
                        else
                        {
                            try
                            {
                                SqlConnection ketnoi = new SqlConnection(truyxuat.con);
                                ketnoi.Open();
                                string tk = txbTK.Text.Trim();
                                string mk = txbOMK.Text.Trim();
                                string nmk = txbNMK.Text.Trim();
                                string rnmk = txbRNMK.Text.Trim();
                                string taikhoan = "select count(*) from admin where tk='" + txbTK.Text + "' and mk='" + txbOMK.Text + "'";
                                SqlCommand cm = new SqlCommand(taikhoan, ketnoi);
                                int i = (int)cm.ExecuteScalar();
                                cm.Dispose();
                                string tku = "select count(*) from nguoidung where tk='" + txbTK.Text + "' and mk='" + txbOMK.Text + "'";
                                SqlCommand com = new SqlCommand(tku, ketnoi);
                                int j = (int)com.ExecuteScalar();
                                com.Dispose();
                                string tkgv = "select count(*) from giaovien where tk='" + txbTK.Text + "' and mk='" + txbOMK.Text + "'";
                                SqlCommand comm = new SqlCommand(tkgv, ketnoi);
                                int k = (int)comm.ExecuteScalar();
                                comm.Dispose();
                                string tktk = "select count(*) from truongkhoa where tk='" + txbTK.Text + "' and mk='" + txbOMK.Text + "'";
                                SqlCommand commm = new SqlCommand(tktk, ketnoi);
                                int l = (int)commm.ExecuteScalar();
                                commm.Dispose();
                                if (i > 0)
                                {
                                    try
                                    {
                                        if (nmk == rnmk)
                                        {
                                            string sql;
                                            sql = "update admin set mk='" + txbNMK.Text + "' where tk='" + txbTK.Text + "'";
                                            SqlCommand sa = new SqlCommand(sql, ketnoi);
                                            sa.ExecuteNonQuery();
                                            MessageBox.Show("Bạn đã thay đổi mật khẩu thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            this.Hide();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Mật khẩu nhập lại chưa trùng khớp!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }

                                    }
                                    catch (Exception)
                                    {

                                        MessageBox.Show("Thao Tác không thực hiện được. Vui lòng kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    //frmain f = new frmain();
                                    //f.Show();
                                }
                                else
                                {
                                    if (k > 0)
                                    {

                                        //MessageBox.Show("Bạn đã đăng nhập vào tài khoản Giáo Viên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        try
                                        {
                                            if (nmk == rnmk)
                                            {
                                                string sqlgv;
                                                sqlgv = "update giaovien set mk='" + txbNMK.Text + "' where tk='" + txbTK.Text + "'";
                                                SqlCommand sa = new SqlCommand(sqlgv, ketnoi);
                                                sa.ExecuteNonQuery();
                                                MessageBox.Show("Bạn đã thay đổi mật khẩu thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                this.Hide();
                                            }
                                            else
                                            {
                                                MessageBox.Show("Mật khẩu nhập lại chưa trùng khớp!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }

                                        }
                                        catch (Exception)
                                        {

                                            MessageBox.Show("Thao Tác không thực hiện được. Vui lòng kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }

                                    //frmain f = new frmain();
                                    //f.Show();
                                    else
                                    {
                                        if (j > 0)
                                        {

                                            // MessageBox.Show("Bạn đã đăng nhập vào tài khoản User!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            try
                                            {
                                                if (nmk == rnmk)
                                                {
                                                    string sqlu;
                                                    sqlu = "update nguoidung set mk='" + txbNMK.Text + "' where tk='" + txbTK.Text + "'";
                                                    SqlCommand sa = new SqlCommand(sqlu, ketnoi);
                                                    sa.ExecuteNonQuery();
                                                    MessageBox.Show("Bạn đã thay đổi mật khẩu thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    this.Hide();
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Mật khẩu nhập lại chưa trùng khớp!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                }

                                            }
                                            catch (Exception)
                                            {

                                                MessageBox.Show("Thao Tác không thực hiện được. Vui lòng kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }

                                            //frmain f = new frmain();
                                            //f.Show();
                                        }
                                        else
                                        {
                                            if (l > 0)
                                            {
                                                // MessageBox.Show("Bạn đã đăng nhập vào tài khoản Trưởng khoa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                try
                                                {
                                                    if (nmk == rnmk)
                                                    {
                                                        string sqltk;
                                                        sqltk = "update truongkhoa set mk='" + txbNMK.Text + "' where tk='" + txbTK.Text + "'";
                                                        SqlCommand sa = new SqlCommand(sqltk, ketnoi);
                                                        sa.ExecuteNonQuery();
                                                        MessageBox.Show("Bạn đã thay đổi mật khẩu thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        this.Hide();
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Mật khẩu nhập lại chưa trùng khớp!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    }

                                                }
                                                catch (Exception)
                                                {

                                                    MessageBox.Show("Thao Tác không thực hiện được. Vui lòng kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                                //frmain f = new frmain();
                                                //f.Show();
                                            }
                                            else
                                            {

                                                MessageBox.Show("Username Hoặc Password sai !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                this.txbTK.Clear();
                                                this.txbOMK.Clear();
                                                this.txbNMK.Clear();
                                                this.txbRNMK.Clear();
                                                this.txbTK.Focus();
                                            }


                                        }
                                    }
                                }
                            }

                            catch (Exception ex)
                            {

                                MessageBox.Show("Thao Tác không thực hiện được. Vui lòng kiểm tra lại!", "Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void f_resetpass_Load(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
               
                txbOMK.UseSystemPasswordChar = false;
            }
            else
            {

                txbOMK.UseSystemPasswordChar = true;

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                txbNMK.UseSystemPasswordChar = false;
                txbRNMK.UseSystemPasswordChar = false;
            }
            else
            {
                txbNMK.UseSystemPasswordChar = true;
                txbRNMK.UseSystemPasswordChar = true;

            }
        }
    }
}
