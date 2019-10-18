﻿using System;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            load();
        }
        
        string gt = "";
        public void load()
        {
            dgvad.DataSource = truyxuat.laybang("select * from ttgiaovien");
            rdfemale.Checked = true;
            dgvad.Columns[0].HeaderText = "Mã Giáo Viên";
            dgvad.Columns[1].HeaderText = "Tên Giáo Viên";
            dgvad.Columns[2].HeaderText = "Giới Tính";
            dgvad.Columns[3].HeaderText = "Ngày Sinh";
            dgvad.Columns[4].HeaderText = "Số Điện Thoại";
            dgvad.Columns[5].HeaderText = "Địa Chỉ";
        }
        public void Bindding()
        {
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
           
            dateTimePicker1.Text = dgvad.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dgvad.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dgvad.CurrentRow.Cells[5].Value.ToString();
        }
        public void rdcheck()
        {
           
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {



                if (txbAcc.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã GV!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txbAcc.Focus();

                }
                else
                {
                    if (txbPas.Text.Trim() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập Tên Giáo viên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    string st = "select count(*) from ttgiaovien where magv='" + txbAcc.Text + "'";
                    int i = 0;
                    SqlCommand cmd = new SqlCommand(st, ketnoi);
                    i = (int)cmd.ExecuteScalar();
                    if (i != 0)
                    {
                        MessageBox.Show("Mã GV đã được thêm. Vui lòng sử dụng Mã GV khác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


                            string s = "insert into ttgiaovien values('" + txbAcc.Text.Trim() + "',N'" + txbPas.Text.Trim() + "',N'"+gt+"',N'" + dateTimePicker1.Text.Trim() + "','" + textBox3.Text.Trim() + "',N'" + textBox4.Text.Trim() + "')";
                            SqlCommand cm = new SqlCommand(s, ketnoi);
                            cm.ExecuteNonQuery();

                            MessageBox.Show("Thêm thành công!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            load();
                            txbAcc.Focus();
                            txbAcc.Text = "";
                            txbPas.Text = "";
                           
                            dateTimePicker1.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Hãy nhập đúng định dạng cho SĐT!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox3.Clear();
                            textBox3.Focus();
                        }


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
                    MessageBox.Show("Bạn chưa nhập mã GV!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txbAcc.Focus();

                }
                else
                {
                    if (txbPas.Text.Trim() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập Tên Giáo viên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                                    else
                                    {

                                        SqlConnection ketnoi = new SqlConnection(truyxuat.con);
                                        ketnoi.Open();
                                        //int id = Convert.ToInt32(txbAcc.Text.Trim());
                                        string st = "select count(*) from ttgiaovien where magv='" + txbAcc.Text + "'";
                                        int i = 0;
                                        SqlCommand cmd = new SqlCommand(st, ketnoi);
                                        i = (int)cmd.ExecuteScalar();
                                        if (i == 0)
                                        {
                                            MessageBox.Show("Mã GV không tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);


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
                                               
                                                    string s = "update ttgiaovien set tengv=N'" + txbPas.Text + "',gioitinh=N'" + gt + "',ngaysinh='" + dateTimePicker1.Text + "',sdt=N'" + textBox3.Text + "',diachi=N'" + textBox4.Text + "' where magv='" + txbAcc.Text + "'";
                                                truyxuat.thaotac(s);

                                                MessageBox.Show("Sửa thành công!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                load();
                                                txbAcc.Focus();
                                                txbAcc.Text = "";
                                                txbPas.Text = "";
                                               
                                                dateTimePicker1.Text = "";
                                                textBox3.Text = "";
                                                textBox4.Text = "";
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
                            }
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
                    MessageBox.Show("Bạn chưa nhập Mã GV!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txbAcc.Focus();
                }

                else
                {
                    SqlConnection ketnoi = new SqlConnection(truyxuat.con);
                    ketnoi.Open();
                    int id = Convert.ToInt32(txbAcc.Text.Trim());
                    string st = "select count(*) from ttgiaovien where magv='" + txbAcc.Text + "'";
                    int i = 0;
                    SqlCommand cmd = new SqlCommand(st, ketnoi);
                    i = (int)cmd.ExecuteScalar();
                    if (i == 0)
                    {
                        MessageBox.Show("Mã GV không tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                            string s = "delete from ttgiaovien where magv='" + txbAcc.Text + "'";
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

        private void dgvad_Click(object sender, EventArgs e)
        {
            Bindding();
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
        }
    }
}
