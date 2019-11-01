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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            load();
        }
        string gt = "";
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
            dgvad.DataSource = truyxuat.laybang("select * from sinhvien");
            rdfemale.Checked = true;
            dgvad.Columns[0].HeaderText = "Mã Sinh Viên";
            dgvad.Columns[1].HeaderText = "Tên Sinh Viên";
            dgvad.Columns[2].HeaderText = "Giới Tính";
            dgvad.Columns[3].HeaderText = "Ngày Sinh";
            dgvad.Columns[4].HeaderText = "Số Điện Thoại";
            dgvad.Columns[5].HeaderText = "Địa Chỉ";
            dgvad.Columns[6].HeaderText = "Mã Chính Sách";
            dgvad.Columns[7].HeaderText = "Mã Lớp";
        }
        public void Bindding()
        {
            txbAcc.Text = dgvad.CurrentRow.Cells[0].Value.ToString();
            txbPas.Text = dgvad.CurrentRow.Cells[1].Value.ToString();
            
            dateTimePicker1.Text = dgvad.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dgvad.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dgvad.CurrentRow.Cells[5].Value.ToString();
            comboBox1.Text = dgvad.CurrentRow.Cells[6].Value.ToString();
            comboBox2.Text = dgvad.CurrentRow.Cells[7].Value.ToString();
            txbAcc.Text = dgvad.CurrentRow.Cells[0].Value.ToString();
            txbPas.Text = dgvad.CurrentRow.Cells[1].Value.ToString();
            if (dgvad.CurrentRow.Cells[2].Value.ToString().Equals("Nam"))
            {
                rdfemale.Checked = true;
                rdmale.Checked = false;
            }
            else
            {
                rdfemale.Checked = false;
                rdmale.Checked = true;
            }

          
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
                        if (rdfemale.Checked == false && rdmale.Checked == false)
                        {
                            MessageBox.Show("Bạn chưa chọn Giới Tính!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                      
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

                if (txbAcc.Text.Trim() != "" && txbPas.Text.Trim() != ""  && dateTimePicker1.Text.Trim() != "" && textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "")
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
                        
                        dateTimePicker1.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                    }

                    else
                    {
                        try
                        {
                            int sdt = int.Parse(textBox3.Text);
                            if (rdfemale.Checked == true)
                            {
                                gt = "Nam";
                            }
                            if (rdmale.Checked == true)
                            {
                                gt = "Nữ";
                            }
                            string s = "insert into sinhvien values('" + txbAcc.Text.Trim() + "',N'" + txbPas.Text.Trim() + "',N'" +gt + "','" + dateTimePicker1.Text.Trim() + "','" + textBox3.Text.Trim() + "',N'" + textBox4.Text.Trim() + "','" + comboBox1.Text.Trim() + "','" + comboBox2.Text.Trim() + "')";
                            SqlCommand cm = new SqlCommand(s, ketnoi);
                            cm.ExecuteNonQuery();

                            MessageBox.Show("Thêm thành công!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            load();
                            txbAcc.Text = "";
                            txbPas.Text = "";
                            
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
                        if (rdfemale.Checked == false && rdmale.Checked == false)
                        {
                            MessageBox.Show("Bạn chưa nhập Giới Tính!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            
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
                if (txbAcc.Text.Trim() != "" && txbPas.Text.Trim() != ""  && dateTimePicker1.Text.Trim() != "" && textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "")
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
                            if (rdfemale.Checked == true)
                            {
                                gt = "Nam";
                            }
                            if (rdmale.Checked == true)
                            {
                                gt = "Nữ";
                            }
                            string s = "update sinhvien set tensv=N'" + txbPas.Text.Trim() + "',gioitinh=N'" + gt + "',ngaysinh='" + dateTimePicker1.Text.Trim() + "',sdt='" + textBox3.Text.Trim() + "',diachi=N'" + textBox4.Text + "',macs='" + comboBox1.Text.Trim() + "',malop='" + comboBox2.Text.Trim() + "' where masv='" + txbAcc.Text.Trim() + "'";
                            truyxuat.thaotac(s);

                            MessageBox.Show("Sửa thành công!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            load();
                            txbAcc.Text = "";
                            txbPas.Text = "";
                            
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

            dateTimePicker1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            txbAcc.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgvad_Click(object sender, EventArgs e)
        {
            Bindding();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
        }
    }
}
