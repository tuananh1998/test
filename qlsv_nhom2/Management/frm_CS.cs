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
    public partial class frm_CS : Form
    {
        public frm_CS()
        {
            InitializeComponent();
        }
        SqlConnection s;
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
            s = new SqlConnection(truyxuat.con);
            try
            {
                string sql = "select * from chinhsach";
                dgvad.DataSource = truyxuat.laybang(sql);
                dgvad.Columns[0].HeaderText = "Mã Chính Sách";
                dgvad.Columns[1].HeaderText = "Tên Chính Sách";
                dgvad.Columns[2].HeaderText = "Chế Độ";
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
            textBox1.Text= dgvad.CurrentRow.Cells[2].Value.ToString();


        }
        private void frm_CS_Load(object sender, EventArgs e)
        {
           
            load();
        }

        private void dgvad_Click(object sender, EventArgs e)
        {
          
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {



                if (txbAcc.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã chính sách!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txbAcc.Focus();
                }
                else
                {
                    if (txbPas.Text.Trim() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập Tên Chính sách!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txbPas.Focus();
                    }
                    else
                    {
                        if (textBox1.Text.Trim() == "")
                        {
                            MessageBox.Show("Bạn chưa nhập Chế Độ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            textBox1.Focus();
                        }
                        
                    }
                }
                 
                if(txbAcc.Text.Trim() != "" && txbPas.Text.Trim() != "" && textBox1.Text != "")
                {
                    SqlConnection ketnoi = new SqlConnection(truyxuat.con);
                    ketnoi.Open();
                    string st = "select count(*) from chinhsach where macs='" + txbAcc.Text + "'";
                    int i = 0;
                    SqlCommand cmd = new SqlCommand(st, ketnoi);
                    i = (int)cmd.ExecuteScalar();
                    if (i != 0)
                    {
                        MessageBox.Show("Mã chính sách đã được thêm. Vui lòng sử dụng Mã Chính sách khác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbAcc.Focus();
                        txbAcc.Text = "";
                        txbPas.Text = "";
                        textBox1.Text = "";

                    }


                    else
                    {
                        string s = "insert into chinhsach values('" + txbAcc.Text.Trim() + "',N'" + txbPas.Text.Trim() + "',N'" + textBox1.Text.Trim() + "')";
                        SqlCommand cm = new SqlCommand(s, ketnoi);
                        cm.ExecuteNonQuery();

                        MessageBox.Show("Thêm thành công!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load();
                        txbAcc.Focus();
                        txbAcc.Text = "";
                        txbPas.Text = "";
                        textBox1.Text = "";
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
                    MessageBox.Show("Bạn chưa nhập mã chính sách!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txbAcc.Focus();
                }
                else
                {
                    if (txbPas.Text.Trim() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập Tên Chính sách!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txbPas.Focus();
                    }
                    else
                    {
                        if (textBox1.Text.Trim() == "")
                        {
                            MessageBox.Show("Bạn chưa nhập Chế Độ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            textBox1.Focus();
                        }
                        else
                        {

                            SqlConnection ketnoi = new SqlConnection(truyxuat.con);
                            ketnoi.Open();
                            string st = "select count(*) from chinhsach where macs='" + txbAcc.Text + "'";
                            int i = 0;
                            SqlCommand cmd = new SqlCommand(st, ketnoi);
                            i = (int)cmd.ExecuteScalar();
                            if (i == 0)
                            {
                                MessageBox.Show("Mã Chính sách không tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txbAcc.Focus();
                                txbAcc.Text = "";
                                txbPas.Text = "";
                                textBox1.Text = "";
                            }


                            else
                            {

                                string s = "update chinhsach set tencs=N'" + txbPas.Text + "',cd=N'" + textBox1.Text.Trim() + "' where macs='" + txbAcc.Text + "'";
                                truyxuat.thaotac(s);

                                MessageBox.Show("Sửa thành công!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Bạn chưa nhập Mã chính sách!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txbAcc.Focus();

                }

                else
                {
                    SqlConnection ketnoi = new SqlConnection(truyxuat.con);
                    ketnoi.Open();
                    string st = "select count(*) from chinhsach where macs='" + txbAcc.Text + "'";
                    int i = 0;
                    SqlCommand cmd = new SqlCommand(st, ketnoi);
                    i = (int)cmd.ExecuteScalar();
                    if (i == 0)
                    {
                        MessageBox.Show("Mã chính sách không tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbAcc.Focus();
                        txbAcc.Text = "";
                        txbPas.Text = "";
                        textBox1.Text = "";

                    }


                    else
                    {

                        if (MessageBox.Show("Bạn có muốn xóa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            string s = "delete from chinhsach where macs='" + txbAcc.Text + "'";
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
            txbAcc.Focus();
            textBox1.Clear();
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
