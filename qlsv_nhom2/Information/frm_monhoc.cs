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
    public partial class frm_monhoc : Form
    {
        public frm_monhoc()
        {
            InitializeComponent();
        }
        SqlConnection s;
        public void load()
        {
            s = new SqlConnection(truyxuat.con);
            try
            {
                string sql = "select * from monhoc";
                dgvad.DataSource = truyxuat.laybang(sql);
                dgvad.Columns[0].HeaderText = "Mã Môn Học";
                dgvad.Columns[1].HeaderText = "Tên Môn Học";
                dgvad.Columns[2].HeaderText = "Số Tiết";
                dgvad.Columns[3].HeaderText = "Mã Giáo Viên";
                string sql1 = "select magv from ttgiaovien";
                comboBox1.DataSource = truyxuat.laybang(sql1);
                comboBox1.DisplayMember = "magv";
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
            textBox1.Text = dgvad.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dgvad.CurrentRow.Cells[3].Value.ToString();
        }

        private void frm_monhoc_Load(object sender, EventArgs e)
        {
            load();

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
                    MessageBox.Show("Bạn chưa nhập mã môn học !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txbAcc.Focus();

                }
                else
                {
                    if (txbPas.Text.Trim() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập Tên môn học!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txbPas.Focus();
                    }
                    else
                    {
                        if (textBox1.Text.Trim() == "")
                        {
                            MessageBox.Show("Bạn chưa nhập Số Tiết!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            textBox1.Focus();
                        }
                        else
                        {
                            if (comboBox1.Text.Trim() == "")
                            {
                                MessageBox.Show("Bạn chưa nhập Mã Giáo Viên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                comboBox1.Focus();
                            }
                        }
                    }
                }
                
                
                if(txbAcc.Text.Trim() != ""&& txbPas.Text.Trim() != "" && textBox1.Text.Trim() != "" && comboBox1.Text.Trim() != "" )
                {
                    SqlConnection ketnoi = new SqlConnection(truyxuat.con);
                    ketnoi.Open();
                    // int id =Convert.ToInt32( txbAcc.Text.Trim());
                    string st = "select count(*) from monhoc where mamh='" + txbAcc.Text + "'";
                    int i = 0;
                    SqlCommand cmd = new SqlCommand(st, ketnoi);
                    i = (int)cmd.ExecuteScalar();
                    if (i != 0)
                    {
                        MessageBox.Show("Mã môn học đã được thêm. Vui lòng sử dụng Mã môn học khác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbAcc.Focus();
                        txbAcc.Text = "";
                        txbPas.Text = "";
                        textBox1.Text = "";
                        //comboBox1.Text = "";
                    }

                    else
                    {
                        string s = "insert into monhoc values('" + txbAcc.Text + "',N'" + txbPas.Text.Trim() + "','" + textBox1.Text.Trim() + "','" + comboBox1.Text.Trim() + "')";
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {


                if (txbAcc.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã môn học !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txbAcc.Focus();

                }
                else
                {
                    if (txbPas.Text.Trim() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập Tên môn học!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txbPas.Focus();
                    }
                    else
                    {
                        if (textBox1.Text.Trim() == "")
                        {
                            MessageBox.Show("Bạn chưa nhập Số Tiết!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            textBox1.Focus();
                        }
                        else
                        {
                            if (comboBox1.Text.Trim() == "")
                            {
                                MessageBox.Show("Bạn chưa nhập Mã Giáo Viên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                comboBox1.Focus();
                            }
                        }
                    }
                }




                if (txbAcc.Text.Trim() != "" && txbPas.Text.Trim() != "" && textBox1.Text.Trim() != "" && comboBox1.Text.Trim() != "")
                {
                    SqlConnection ketnoi = new SqlConnection(truyxuat.con);
                    ketnoi.Open();
                    //int id = Convert.ToInt32(txbAcc.Text.Trim());
                    string st = "select count(*) from monhoc where mamh='" + txbAcc.Text + "'";
                    int i = 0;
                    SqlCommand cmd = new SqlCommand(st, ketnoi);
                    i = (int)cmd.ExecuteScalar();
                    if (i == 0)
                    {
                        MessageBox.Show("Mã môn học không tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbAcc.Focus();
                        txbAcc.Text = "";
                        txbPas.Text = "";
                        textBox1.Text = "";

                    }


                    else
                    {
                        string s = "update monhoc set tenmh=N'" + txbPas.Text + "',sotiet='" + textBox1.Text + "',magv='" + comboBox1.Text + "' where mamh='" + txbAcc.Text + "'";
                        truyxuat.thaotac(s);

                        MessageBox.Show("Sửa thành công!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {



                if (txbAcc.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập Mã Môn học!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

                else
                {
                    SqlConnection ketnoi = new SqlConnection(truyxuat.con);
                    ketnoi.Open();
                    //int id = Convert.ToInt32(txbAcc.Text.Trim());
                    string st = "select count(*) from monhoc where mamh='" + txbAcc.Text + "'";
                    int i = 0;
                    SqlCommand cmd = new SqlCommand(st, ketnoi);
                    i = (int)cmd.ExecuteScalar();
                    if (i == 0)
                    {
                        MessageBox.Show("Mã môn học không tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbAcc.Focus();
                        txbAcc.Text = "";
                        txbPas.Text = "";
                        textBox1.Text = "";

                    }


                    else
                    {

                        if (MessageBox.Show("Bạn có muốn xóa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            string s = "delete from monhoc where mamh='" + txbAcc.Text + "'";
                            truyxuat.thaotac(s);

                            MessageBox.Show("Xóa thành công!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            load();
                            txbAcc.Focus();
                            txbAcc.Text = "";
                            txbPas.Text = "";
                            textBox1.Text = "";
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
            textBox1.Clear();
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
