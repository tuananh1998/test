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
    public partial class f_khoa : Form
    {
        public f_khoa()
        {
            InitializeComponent();
            load();
        }
        SqlConnection s;
        public void load()
        {
            s = new SqlConnection(truyxuat.con);
            try
            {
                string sql = "select * from khoa";
                dgvad.DataSource = truyxuat.laybang(sql);
                dgvad.Columns[0].HeaderText = "Mã Khoa";
                dgvad.Columns[1].HeaderText = "Tên Khoa";
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



        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {



                if (txbAcc.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã Khoa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txbAcc.Focus();

                }
                else 
                {
                    if (txbPas.Text.Trim() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập Tên Khoa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txbPas.Focus();
                    }
                       
                }
                if(txbAcc.Text.Trim() != ""&& txbPas.Text.Trim() != "")
                {
                    SqlConnection ketnoi = new SqlConnection(truyxuat.con);
                    ketnoi.Open();
                    string st = "select count(*) from khoa where makhoa='" + txbAcc.Text + "'";
                    int i = 0;
                    SqlCommand cmd = new SqlCommand(st, ketnoi);
                    i = (int)cmd.ExecuteScalar();
                    if (i != 0)
                    {
                        MessageBox.Show("Mã Khoa đã được thêm. Vui lòng sử dụng Mã Khoa khác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbAcc.Focus();
                        txbAcc.Text = "";
                        txbPas.Text = "";


                    }


                    else
                    {
                        string s = "insert into khoa values('" + txbAcc.Text.Trim() + "',N'" + txbPas.Text.Trim() + "')";
                        SqlCommand cm = new SqlCommand(s, ketnoi);
                        cm.ExecuteNonQuery();

                        MessageBox.Show("Thêm thành công!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load();

                        // this.Hide();
                    }


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Thao Tác không thực hiện được. Vui lòng kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvad_Click(object sender, EventArgs e)
        {
            Binding();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {



                if (txbAcc.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã Khoa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txbAcc.Focus();
                }
                else
                {
                    if (txbPas.Text.Trim() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập Tên Khoa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txbPas.Focus();
                    }

                }
                if (txbAcc.Text.Trim() != "" && txbPas.Text.Trim() != "")
                {
                    SqlConnection ketnoi = new SqlConnection(truyxuat.con);
                    ketnoi.Open();
                    string st = "select count(*) from khoa where makhoa='" + txbAcc.Text + "'";
                    int i = 0;
                    SqlCommand cmd = new SqlCommand(st, ketnoi);
                    i = (int)cmd.ExecuteScalar();
                    if (i == 0)
                    {
                        MessageBox.Show("Mã Khoa không tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbAcc.Focus();
                        txbAcc.Text = "";
                        txbPas.Text = "";

                    }


                    else
                    {
                        string s = "update khoa set tenkhoa=N'" + txbPas.Text + "' where makhoa='" + txbAcc.Text + "'";
                        truyxuat.thaotac(s);

                        MessageBox.Show("Sửa thành công!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {



                if (txbAcc.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập Mã Khoa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txbAcc.Focus();
                }

                else
                {
                    SqlConnection ketnoi = new SqlConnection(truyxuat.con);
                    ketnoi.Open();
                    string st = "select count(*) from khoa where makhoa='" + txbAcc.Text + "'";
                    int i = 0;
                    SqlCommand cmd = new SqlCommand(st, ketnoi);
                    i = (int)cmd.ExecuteScalar();
                    if (i == 0)
                    {
                        MessageBox.Show("Mã Khoa không tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbAcc.Focus();
                        txbAcc.Text = "";
                        txbPas.Text = "";

                    }


                    else
                    {

                        if (MessageBox.Show("Bạn có muốn xóa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            string s = "delete from khoa where makhoa='" + txbAcc.Text + "'";
                            truyxuat.thaotac(s);

                            MessageBox.Show("Xóa thành công!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            load();
                            txbAcc.Clear();
                            txbPas.Clear();
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
        }

        private void dgvad_Click_1(object sender, EventArgs e)
        {
            Binding();
        }
    }
}
