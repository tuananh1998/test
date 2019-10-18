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
    public partial class frm_diem : Form
    {
        public frm_diem()
        {
            InitializeComponent();
        }
        SqlConnection s;
        public void load()
        {
            s = new SqlConnection(truyxuat.con);
            try
            {
                string sql = "select * from diem";
                dgvad.DataSource = truyxuat.laybang(sql);
                dgvad.Columns[0].HeaderText = "Mã ID";
                dgvad.Columns[1].HeaderText = "Mã Sinh Viên";
                dgvad.Columns[2].HeaderText = "Mã Môn Học";
                dgvad.Columns[3].HeaderText = "Điểm";
                comboBox1.DataSource = truyxuat.laybang("select * from monhoc");
                comboBox1.DisplayMember = "mamh";
                comboBox2.DataSource = truyxuat.laybang("select * from sinhvien");
                comboBox2.DisplayMember = "masv";
            }
            catch (Exception e)
            {

                MessageBox.Show("Thao Tác không thực hiện được. Vui lòng kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Binding()
        {
            txbAcc.Text = dgvad.CurrentRow.Cells[0].Value.ToString();
            comboBox2.Text = dgvad.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dgvad.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dgvad.CurrentRow.Cells[3].Value.ToString();


        }
        private void frm_diem_Load(object sender, EventArgs e)
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
                    MessageBox.Show("Bạn chưa nhập mã !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txbAcc.Focus();

                }
                else 
                {
                    if (comboBox2.Text.Trim() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mã sinh viên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        comboBox2.Focus();
                    }
                    else
                    {
                        if (comboBox1.Text.Trim() == "")
                        {
                            MessageBox.Show("Bạn chưa nhập Mã môn học!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            comboBox1.Focus();
                        }
                        else
                        {
                            if (textBox2.Text.Trim() == "")
                            {
                                MessageBox.Show("Bạn chưa nhập Điểm!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                textBox2.Focus();
                            }
                        }
                    }
                        
                }
                 
                 
                if(txbAcc.Text.Trim() != ""&& comboBox2.Text.Trim() != "" && comboBox1.Text.Trim() != "" && textBox2.Text.Trim() != "")
                {
                    SqlConnection ketnoi = new SqlConnection(truyxuat.con);
                    ketnoi.Open();
                   // int id =Convert.ToInt32( txbAcc.Text.Trim());
                    string st = "select count(*) from diem where id='" + txbAcc.Text + "'";
                    int i = 0;
                    SqlCommand cmd = new SqlCommand(st, ketnoi);
                    i = (int)cmd.ExecuteScalar();
                    if (i != 0)
                    {
                        MessageBox.Show("Mã ID đã được thêm. Vui lòng sử dụng Mã ID khác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbAcc.Focus();
                        txbAcc.Text = "";
                        comboBox2.Text = "";
                        
                        textBox2.Text = "";
                    }
                    
                    else
                    {
                        try
                        {
                            //double diem = Convert.ToDouble(textBox2.Text.Trim());
                            double diem = double.Parse(textBox2.Text.Trim());
                            if (diem < 0 || diem > 10)
                            {
                                MessageBox.Show("Hãy Nhập đúng định dạng về điểm!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBox2.Clear();
                                textBox2.Focus();
                            }
                            else
                            {

                                string s = "insert into diem values('" + txbAcc.Text.Trim() + "','" + comboBox2.Text.Trim() + "','" + comboBox1.Text.Trim() + "','" + diem + "')";
                                SqlCommand cm = new SqlCommand(s, ketnoi);
                                cm.ExecuteNonQuery();

                                MessageBox.Show("Thêm thành công!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                load();
                                // this.Hide();
                            }
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Hãy Nhập đúng định dạng về điểm!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox2.Clear();
                            textBox2.Focus();
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
                    MessageBox.Show("Bạn chưa nhập mã !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txbAcc.Focus();

                }
                else
                {
                    if (comboBox2.Text.Trim() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mã sinh viên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        comboBox2.Focus();
                    }
                    else
                    {
                        if (comboBox1.Text.Trim() == "")
                        {
                            MessageBox.Show("Bạn chưa nhập Mã môn học!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            comboBox1.Focus();
                        }
                        else
                        {
                            if (textBox2.Text.Trim() == "")
                            {
                                MessageBox.Show("Bạn chưa nhập Điểm!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                textBox2.Focus();
                            }
                        }
                    }

                }


                if (txbAcc.Text.Trim() != "" && comboBox2.Text.Trim() != "" && comboBox1.Text.Trim() != "" && textBox2.Text.Trim() != "")
                {
                    SqlConnection ketnoi = new SqlConnection(truyxuat.con);
                    ketnoi.Open();
                    //int id = Convert.ToInt32(txbAcc.Text.Trim());
                    string st = "select count(*) from diem where id='" + txbAcc.Text + "'";
                    int i = 0;
                    SqlCommand cmd = new SqlCommand(st, ketnoi);
                    i = (int)cmd.ExecuteScalar();
                    if (i == 0)
                    {
                        MessageBox.Show("Mã ID không tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbAcc.Focus();
                        txbAcc.Text = "";
                        comboBox2.Text = "";
                        
                        textBox2.Text = "";

                    }


                    else
                    {
                        try
                        {
                            double diem = double.Parse(textBox2.Text.Trim());
                            if (diem < 0 || diem > 10)
                            {
                                MessageBox.Show("Hãy Nhập đúng định dạng về điểm!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBox2.Text = "";
                                textBox2.Focus();
                            }
                            else
                            {
                                string s = "update diem set masv='" + comboBox2.Text + "',mamh='" + comboBox1.Text + "',diem='" + textBox2.Text + "' where id='" + txbAcc.Text + "'";
                                truyxuat.thaotac(s);

                                MessageBox.Show("Sửa thành công!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                load();
                                // this.Hide();
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Hãy Nhập đúng định dạng về điểm!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox2.Text = "";
                            textBox2.Focus();

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
                    MessageBox.Show("Bạn chưa nhập Mã ID!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txbAcc.Focus();
                }

                else
                {
                    SqlConnection ketnoi = new SqlConnection(truyxuat.con);
                    ketnoi.Open();
                    int id = Convert.ToInt32(txbAcc.Text.Trim());
                    string st = "select count(*) from diem where id='" + txbAcc.Text + "'";
                    int i = 0;
                    SqlCommand cmd = new SqlCommand(st, ketnoi);
                    i = (int)cmd.ExecuteScalar();
                    if (i == 0)
                    {
                        MessageBox.Show("Mã ID không tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbAcc.Focus();
                        txbAcc.Text = "";
                        comboBox2.Text = "";
                        
                        textBox2.Text = "";

                    }


                    else
                    {
                        
                        if (MessageBox.Show("Bạn có muốn xóa không?","Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            MessageBox.Show("Xóa thành công!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            string s = "delete from diem where id='" + txbAcc.Text + "'";
                            truyxuat.thaotac(s);
                            load();
                            txbAcc.Focus();
                            txbAcc.Text = "";
                            comboBox2.Text = "";

                            textBox2.Text = "";
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
            
            textBox2.Clear();
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
