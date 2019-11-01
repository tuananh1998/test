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
    public partial class f_sv : Form
    {
        public f_sv()
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
                string sql = "select * from sinhvien";
                dgvad.DataSource = truyxuat.laybang(sql);
                dgvad.Columns[0].HeaderText = "Mã Sinh Viên";
                dgvad.Columns[1].HeaderText = "Tên Sinh Viên";
                dgvad.Columns[2].HeaderText = "Giới Tính";
                dgvad.Columns[3].HeaderText = "Ngày Sinh";
                dgvad.Columns[4].HeaderText = "Số Điện Thoại";
                dgvad.Columns[5].HeaderText = "Địa Chỉ";
                dgvad.Columns[6].HeaderText = "Mã Chính Sách";
                dgvad.Columns[7].HeaderText = "Mã Lớp";
                comboBox1.DataSource = truyxuat.laybang("select * from chinhsach");
                comboBox1.DisplayMember = "macs";
                comboBox2.DataSource = truyxuat.laybang("select * from lop");
                comboBox2.DisplayMember = "malop";
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
            dateTimePicker1.Text = dgvad.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dgvad.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dgvad.CurrentRow.Cells[5].Value.ToString();
            comboBox1.Text = dgvad.CurrentRow.Cells[6].Value.ToString();
            comboBox2.Text = dgvad.CurrentRow.Cells[7].Value.ToString();



        }
        private void f_sv_Load(object sender, EventArgs e)
        {
            
            //dgvad.Columns[2].HeaderText = "Giới Tính";
            //dgvad.Columns[3].HeaderText = "Ngày Sinh";
            //dgvad.Columns[4].HeaderText = "Số Điện Thoại";
            //dgvad.Columns[5].HeaderText = "Địa Chỉ";
            //dgvad.Columns[6].HeaderText = "Mã Chính Sách";
            //dgvad.Columns[7].HeaderText = "Mã Lớp";
        }

        private void dgvad_Click(object sender, EventArgs e)
        {
            Binding();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {



                if (txbAcc.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã SV!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txbAcc.Focus();

                }
                else
                {
                    if (txbPas.Text.Trim() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập Tên sinh viên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txbPas.Focus();
                    }

                    else
                    {
                        if (textBox1.Text.Trim() == "")
                        {
                            MessageBox.Show("Bạn chưa nhập Giới Tính!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            textBox1.Focus();
                        }
                        else
                        {
                            if (dateTimePicker1.Text.Trim() == "")
                            {
                                MessageBox.Show("Bạn chưa nhập Ngày Sinh!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                dateTimePicker1.Focus();
                            }
                            else
                            {
                                if (textBox3.Text.Trim() == "")
                                {
                                    MessageBox.Show("Bạn chưa nhập Số ĐT!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    textBox3.Focus();
                                }
                                else
                                {
                                    if (textBox4.Text.Trim() == "")
                                    {
                                        MessageBox.Show("Bạn chưa nhập Địa Chỉ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        textBox4.Focus();
                                    }
                                }
                            }
                        }


                    }
                }

                if (txbAcc.Text.Trim() != "" && txbPas.Text.Trim() != "" && textBox1.Text.Trim() != "" && dateTimePicker1.Text.Trim() != "" && textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "")
                {
                    SqlConnection ketnoi = new SqlConnection(truyxuat.con);
                    ketnoi.Open();
                    // int id =Convert.ToInt32( txbAcc.Text.Trim());
                    string st = "select count(*) from sinhvien where masv='" + txbAcc.Text + "'";
                    int i = 0;
                    SqlCommand cmd = new SqlCommand(st, ketnoi);
                    i = (int)cmd.ExecuteScalar();
                    if (i != 0)
                    {
                        MessageBox.Show("Mã SV đã được thêm. Vui lòng sử dụng Mã SV khác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbAcc.Focus();
                        txbAcc.Text = "";
                        txbPas.Text = "";
                        textBox1.Text = "";
                        dateTimePicker1.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                    }

                    else
                    {
                        try
                        {
                            int sdt = int.Parse(textBox3.Text);
                            string s = "insert into sinhvien values('" + txbAcc.Text.Trim() + "',N'" + txbPas.Text.Trim() + "',N'"+textBox1.Text.Trim()+"','" + dateTimePicker1.Text.Trim() + "','" + textBox3.Text.Trim() + "',N'" + textBox4.Text.Trim() + "','" + comboBox1.Text.Trim() + "','" + comboBox2.Text.Trim() + "')";
                            SqlCommand cm = new SqlCommand(s, ketnoi);
                            cm.ExecuteNonQuery();

                            MessageBox.Show("Thêm thành công!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            load();
                            txbAcc.Text = "";
                            txbPas.Text = "";
                            textBox1.Text = "";
                            dateTimePicker1.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            txbAcc.Focus();
                            // this.Hide();

                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Hãy nhập đúng định dạng cho SĐT!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox3.Clear();
                            textBox3.Focus();
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
                    MessageBox.Show("Bạn chưa nhập mã SV!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txbAcc.Focus();

                }
                else
                {
                    if (txbPas.Text.Trim() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập Tên sinh viên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txbPas.Focus();
                    }

                    else
                    {
                        if (textBox1.Text.Trim() == "")
                        {
                            MessageBox.Show("Bạn chưa nhập Giới Tính!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            textBox1.Focus();
                        }
                        else
                        {
                            if (dateTimePicker1.Text.Trim() == "")
                            {
                                MessageBox.Show("Bạn chưa nhập Ngày Sinh!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                dateTimePicker1.Focus();
                            }
                            else
                            {
                                if (textBox3.Text.Trim() == "")
                                {
                                    MessageBox.Show("Bạn chưa nhập Số ĐT!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    textBox3.Focus();
                                }
                                else
                                {
                                    if (textBox4.Text.Trim() == "")
                                    {
                                        MessageBox.Show("Bạn chưa nhập Địa Chỉ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        textBox4.Focus();
                                    }
                                }
                            }
                        }
                    }

                }
                if (txbAcc.Text.Trim() != "" && txbPas.Text.Trim() != "" && textBox1.Text.Trim() != "" && dateTimePicker1.Text.Trim() != "" && textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "")
                {
                    SqlConnection ketnoi = new SqlConnection(truyxuat.con);
                    ketnoi.Open();
                    //int id = Convert.ToInt32(txbAcc.Text.Trim());
                    string st = "select count(*) from sinhvien where masv='" + txbAcc.Text + "'";
                    int i = 0;
                    SqlCommand cmd = new SqlCommand(st, ketnoi);
                    i = (int)cmd.ExecuteScalar();
                    if (i == 0)
                    {
                        MessageBox.Show("Mã SV không tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                        txbAcc.Text = "";
                        txbPas.Text = "";
                        textBox1.Text = "";
                        dateTimePicker1.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        txbAcc.Focus();
                    }


                    else
                    {
                        try
                        {
                            int sdt = int.Parse(textBox3.Text);
                            string s = "update sinhvien set tensv=N'" + txbPas.Text.Trim() + "',gioitinh=N'" + textBox1.Text.Trim() + "',ngaysinh='" + dateTimePicker1.Text.Trim() + "',sdt='" + textBox3.Text.Trim() + "',diachi=N'" + textBox4.Text + "',macs='" + comboBox1.Text.Trim() + "',malop='" + comboBox2.Text.Trim() + "' where masv='" + txbAcc.Text.Trim() + "'";
                            truyxuat.thaotac(s);

                            MessageBox.Show("Sửa thành công!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            load();
                            txbAcc.Text = "";
                            txbPas.Text = "";
                            textBox1.Text = "";
                            dateTimePicker1.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            txbAcc.Focus();
                            // this.Hide();

                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Hãy nhập đúng định dạng cho SĐT!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox3.Clear();
                            textBox3.Focus();
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
                    MessageBox.Show("Bạn chưa nhập Mã SV!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

                else
                {

                    SqlConnection ketnoi = new SqlConnection(truyxuat.con);
                    ketnoi.Open();
                    int id = Convert.ToInt32(txbAcc.Text.Trim());
                    string st = "select count(*) from sinhvien where masv='" + txbAcc.Text + "'";
                    int i = 0;
                    SqlCommand cmd = new SqlCommand(st, ketnoi);
                    i = (int)cmd.ExecuteScalar();
                    if (i == 0)
                    {
                        MessageBox.Show("Mã SV không tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbAcc.Text = "";
                        txbPas.Text = "";
                        textBox1.Text = "";
                        dateTimePicker1.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        txbAcc.Focus();

                    }


                    else
                    {

                        if (MessageBox.Show("Bạn có muốn xóa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            string s = "delete from sinhvien where masv='" + txbAcc.Text + "'";
                            truyxuat.thaotac(s);

                            MessageBox.Show("Xóa thành công!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            load();
                            txbAcc.Text = "";
                            txbPas.Text = "";
                            textBox1.Text = "";
                            dateTimePicker1.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
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
            txbAcc.Text = "";
            txbPas.Text = "";
            textBox1.Text = "";
            dateTimePicker1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
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
