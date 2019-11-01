using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlsv_nhom2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (label2.Left <= this.Width)
            {
                label2.Left = label2.Left + 10;
            }
            else label2.Left = -label2.Width;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tt;
            tt = "Phần mềm: QUẢN LÝ SINH VIÊN\n";
            tt += "\n";
            tt += "Version:1.1 \n";
            tt += "Học phần thực tập:\n\n";
            tt += "Lập trình hướng cơ sở dữ liệu \n";
            tt += "\n\n";
            tt += "Copy right @ năm 2017 \n";
            tt += "Designer by: Nhóm 2 \n";
            tt += "Email: nhom2tin10a2@gmail.com \n\n";
            MessageBox.Show((tt),"Thông Tin",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát không?", "Nhóm 2-nhom2tin10a2hn@gmail.com",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (DialogResult.Yes==r)
            {
                Application.Exit();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmdk f = new frmdk();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmdn f = new frmdn();
            f.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string tt;
            tt = "Phần mềm: QUẢN LÝ SINH VIÊN\n";
            tt += "\n";
            tt += "Version:1.1 \n";
            tt += "Học phần thực tập:\n\n";
            tt += "Lập trình hướng cơ sở dữ liệu \n";
            tt += "\n\n";
            tt += "Copy right @ năm 2017 \n";
            tt += "Designer by: Tuấn Anh \n";
            tt += "Email: tuananhcan63@gmail.com \n\n";
            MessageBox.Show((tt), "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
