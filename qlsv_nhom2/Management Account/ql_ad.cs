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
    public partial class ql_ad : Form
    {
        public ql_ad()
        {
            InitializeComponent();
        }
        SqlConnection s;
        public void load() {
           s = new SqlConnection(truyxuat.con);
            try
            {
                string sql = "select tk,convert(varchar(32),hashbytes('md5',mk),2) from admin";
                dgvad.DataSource=truyxuat.laybang(sql);
                dgvad.Columns[0].HeaderText = "Tài Khoản";
                dgvad.Columns[1].HeaderText = "Mật Khẩu";

            }
            catch (Exception e)
            {

                MessageBox.Show("Thao Tác không thực hiện được. Vui lòng kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ql_ad_Load(object sender, EventArgs e)
        {
            
            load();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           
            this.Hide();
        }

        private void btnRs_Click(object sender, EventArgs e)
        {
            txbAcc.Clear();
            txbPas.Clear();
            txbAcc.Focus();

        }
        public void Binding()
        {
            txbAcc.Text = dgvad.CurrentRow.Cells[0].Value.ToString();
            txbPas.Text = dgvad.CurrentRow.Cells[1].Value.ToString();
            


        }
        private void dgvad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvad_Click(object sender, EventArgs e)
        {
            Binding();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {

             

                    if (txbAcc.Text.Trim() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập tên tài khoản!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txbAcc.Focus();
                    }
                    
                    else
                {
                    if (txbPas.Text.Trim() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mật khẩu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txbPas.Focus();
                    }
                    else
                    {
                        SqlConnection ketnoi = new SqlConnection(truyxuat.con);
                        ketnoi.Open();
                        string st = "select count(*) from admin where tk='" + txbAcc.Text + "'";
                        int i = 0;
                        SqlCommand cmd = new SqlCommand(st, ketnoi);
                        i = (int)cmd.ExecuteScalar();
                        if (i != 0)
                        {
                            MessageBox.Show("Tài khoản đã được thêm. Vui lòng sử dụng tên khác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txbAcc.Focus();
                            txbAcc.Text = "";
                            txbPas.Text = "";


                        }


                        else
                        {
                            string s = "insert into admin values('" + txbAcc.Text.Trim() + "','" + txbPas.Text.Trim() + "')";
                            SqlCommand cm = new SqlCommand(s, ketnoi);
                            cm.ExecuteNonQuery();

                            MessageBox.Show("Thêm thành công!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            load();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {



                if (txbAcc.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên tài khoản!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txbAcc.Focus();
                }
                else
                {
                    if (txbPas.Text.Trim() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mật khẩu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txbPas.Focus();
                    }
                    else
                    {
                        SqlConnection ketnoi = new SqlConnection(truyxuat.con);
                        ketnoi.Open();
                        string st = "select count(*) from admin where tk='" + txbAcc.Text + "'";
                        int i = 0;
                        SqlCommand cmd = new SqlCommand(st, ketnoi);
                        i = (int)cmd.ExecuteScalar();
                        if (i == 0)
                        {
                            MessageBox.Show("Tài Khoản không tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txbAcc.Focus();
                            txbAcc.Text = "";
                            txbPas.Text = "";

                        }


                        else
                        {
                            string s = "update admin set mk='" + txbPas.Text + "' where tk='" + txbAcc.Text + "'";
                            truyxuat.thaotac(s);

                            MessageBox.Show("Sửa thành công!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            load();
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

        private void btnDel_Click(object sender, EventArgs e)
        {
            
            try
            {



                if (txbAcc.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên tài khoản!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                
                else
                {
                    SqlConnection ketnoi = new SqlConnection(truyxuat.con);
                    ketnoi.Open();
                    string st = "select count(*) from admin where tk='" + txbAcc.Text + "'";
                    int i = 0;
                    SqlCommand cmd = new SqlCommand(st, ketnoi);
                    i = (int)cmd.ExecuteScalar();
                    if (i == 0)
                    {
                        MessageBox.Show("Tài Khoản không tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbAcc.Focus();
                        txbAcc.Text = "";
                        txbPas.Text = "";

                    }


                    else
                    {
                        string s = "delete from admin where tk='" + txbAcc.Text + "'";
                        truyxuat.thaotac(s);

                        MessageBox.Show("Xóa thành công!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        load();
                        txbAcc.Focus();
                        txbAcc.Text = "";
                        txbPas.Text = "";
                        // this.Hide();
                    }


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Thao Tác không thực hiện được. Vui lòng kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
