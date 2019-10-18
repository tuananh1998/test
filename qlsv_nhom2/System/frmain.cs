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
    public partial class frmain : Form
    {
        public string pq;
        public frmain(string loai)
        {
            InitializeComponent();
            pq = loai;
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void điểmToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_resetpass f = new f_resetpass();
            f.ShowDialog();
            
        }

        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();

        }

        private void qladmin_Click(object sender, EventArgs e)
        {
            ql_ad f = new ql_ad();
            f.ShowDialog();
            
        }

        private void qluser_Click(object sender, EventArgs e)
        {
            ql_user f = new ql_user();
            f.ShowDialog();
        }

        private void qlgv_Click(object sender, EventArgs e)
        {

            ql_gv f = new ql_gv();
            f.ShowDialog();
        }

        private void qltk_Click(object sender, EventArgs e)
        {

            ql_tk f = new ql_tk();
            f.ShowDialog();
        }

        private void hỗTrợToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void thôngTinToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void paintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mspaint.exe");
        }

        private void cmdToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
        System.Diagnostics.Process.Start("cmd.exe");
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                System.Diagnostics.Process.Start("notepad.exe");
        }

        private void máyTínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                System.Diagnostics.Process.Start("calc.exe");
        }

        private void liênHệToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string tt;
            tt = "Phần mềm: QUẢN LÝ SINH VIÊN\n";
            tt += "\n";
            tt += "SĐT:0971133263 \n";
            tt += "\n";
            tt += "Email: tuananhcan63@gmail.com \n\n";
            MessageBox.Show((tt), "Liên Hệ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cậpNhậtPhầnMềmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn Đang Sử Dụng phiên bản mới nhất!", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.8;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label2.Left <= this.Width)
            {
                label2.Left = label2.Left + 10;
            }
            else label2.Left = -label2.Width;
        }

        private void frmain_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.45;
        }

        private void khoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
                }
           
        private void khoa_Click(object sender, EventArgs e)
        {
            
            qladmin.Visible = false;
            qltk.Visible = false;
            qlgv.Visible = false;
            qluser.Visible = false;
            resetpas.Visible = false;
            thôngTinToolStripMenuItem.Visible = false;
            tìmKiếmToolStripMenuItem.Visible = false;
            điểmToolStripMenuItem2.Visible = false;
            quảnLýToolStripMenuItem.Visible = false;
            hỗTrợToolStripMenuItem.Visible = false;
            thoátToolStripMenuItem.Visible = false;
            hỗTrợToolStripMenuItem1.Visible = false;
            thoátToolStripMenuItem1.Visible = false;
            frmdn f = new frmdn();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
            this.Hide();
        }

        private void chínhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void điểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void mônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void sinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void lớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void giáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
        }

        private void mặcĐịnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }

        private void tiếngViệtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qladmin.Text = "Quản Lý Tài Khoản Admin";
            qltk.Text = "Quản Lý Tài Khoản Trưởng Khoa";
            qlgv.Text = "Quản Lý Tài Khoản Giáo Viên";
            qluser.Text = "Quản Lý Tài Khoản Người dùng";
            khoa.Text = "Khóa";
            resetpas.Text = "Đổi Mật khẩu";
            đăngXuấtToolStripMenuItem1.Text = "Đăng Xuất";
            thôngTinToolStripMenuItem.Text = "Thông Tin";
            giáoViênToolStripMenuItem.Text = "Giáo Viên";
            lớpToolStripMenuItem.Text = "Lớp";
            sinhViênToolStripMenuItem.Text = "Sinh Viên";
            mônHọcToolStripMenuItem.Text = "Môn Học";
            điểmToolStripMenuItem.Text = "Điểm";
            tìmKiếmToolStripMenuItem.Text = "Tìm Kiếm";
            khoaToolStripMenuItem1.Text = "Khoa";
            giáoViênToolStripMenuItem1.Text = "Giáo Viên";
            lớpToolStripMenuItem1.Text = "Lớp";
            sinhViênToolStripMenuItem1.Text = "Sinh Viên";
            hỗTrợToolStripMenuItem1.Text = "Hỗ Trợ";
            cậpNhậtPhầnMềmToolStripMenuItem.Text = "Cập nhật phần mềm";
            thôngTinToolStripMenuItem1.Text = "Thông Tin";
            liênHệToolStripMenuItem.Text = "Liên Hệ";
            thoátToolStripMenuItem1.Text = "Thoát";
            máyTínhToolStripMenuItem.Text = "Máy Tính";
            ngônNgữToolStripMenuItem.Text = "Ngôn Ngữ";
            tiếngViệtToolStripMenuItem.Text = "Tiếng Việt";
            tiếngAnhToolStripMenuItem.Text = "Tiếng Anh";
            hỗTrợToolStripMenuItem.Text = "Hiển Thị";
            điểmToolStripMenuItem2.Text = "Điểm";
            quảnLýToolStripMenuItem.Text = "Quản Lý";
            khoaToolStripMenuItem2.Text = "Khoa";
            giáoViênToolStripMenuItem2.Text = "Giáo Viên";
            lớpToolStripMenuItem2.Text = "Lớp";
            sinhViênToolStripMenuItem2.Text = "Sinh Viên";
            mônHọcToolStripMenuItem2.Text = "Môn Học";
            chínhSáchToolStripMenuItem2.Text = "Chính Sách";
            điểmToolStripMenuItem3.Text = "Điểm";
            kiểuXemToolStripMenuItem.Text = "Kiểu xem";
            label2.Text = "CHÀO MỪNG BẠN ĐẾN VỚI CHƯƠNG TRÌNH CHÍNH";
            chínhSáchToolStripMenuItem1.Text = "Chính Sách";
            chínhSáchToolStripMenuItem.Text = "Chính Sách";
            mônHọcToolStripMenuItem.Text = "Môn Học";
            mônHọcToolStripMenuItem1.Text = "Môn Học";
            chínhSáchToolStripMenuItem2.Text = "Chính Sách";
            mônHọcToolStripMenuItem2.Text = "Môn Học";
            khoaToolStripMenuItem.Text = "Khoa";
            thoátToolStripMenuItem.Text = "Tiện Ích";
            
            mặcĐịnhToolStripMenuItem.Text = "Mặc Định";
        }

        private void tiếngAnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qladmin.Text = "Admin Manager";
            qltk.Text = "Dean Manager ";
            qlgv.Text = "Teacher Manager";
            qluser.Text = "User Manager";
            khoa.Text = "Lock";
            resetpas.Text = "Reset Password";
            thoátToolStripMenuItem.Text = "Utilities";
            đăngXuấtToolStripMenuItem1.Text = "Log out";
            thôngTinToolStripMenuItem.Text = "Information";
            giáoViênToolStripMenuItem.Text = "Teacher";
            lớpToolStripMenuItem.Text = "Class";
            sinhViênToolStripMenuItem.Text = "Student";
            mônHọcToolStripMenuItem.Text = "Subject";
            điểmToolStripMenuItem.Text = "Point";
            tìmKiếmToolStripMenuItem.Text = "Find";
            khoaToolStripMenuItem1.Text = "Department";
            giáoViênToolStripMenuItem1.Text = "Teacher";
            lớpToolStripMenuItem1.Text = "Class";
            sinhViênToolStripMenuItem1.Text = "Student";
            hỗTrợToolStripMenuItem1.Text = "Help";
            cậpNhậtPhầnMềmToolStripMenuItem.Text = "SoftWare Update";
            thôngTinToolStripMenuItem1.Text = "About SoftWare";
            liênHệToolStripMenuItem.Text = "Send Feedback";
            thoátToolStripMenuItem1.Text = "Exit";
            máyTínhToolStripMenuItem.Text = "Caculator";
            ngônNgữToolStripMenuItem.Text = "Language";
            tiếngViệtToolStripMenuItem.Text = "Vietnamese";
            tiếngAnhToolStripMenuItem.Text = "English";
            hỗTrợToolStripMenuItem.Text = "View";
            điểmToolStripMenuItem2.Text = "Point";
            quảnLýToolStripMenuItem.Text = "Manager";
            khoaToolStripMenuItem2.Text = "Department";
            giáoViênToolStripMenuItem2.Text = "Teacher";
            lớpToolStripMenuItem2.Text = "Class";
            sinhViênToolStripMenuItem2.Text = "Student";
            mônHọcToolStripMenuItem2.Text = "Subject";
            chínhSáchToolStripMenuItem2.Text = "Policy";
            điểmToolStripMenuItem3.Text = "Point";
            kiểuXemToolStripMenuItem.Text = "Software View";
            label2.Text = "Welcome!!!";
            chínhSáchToolStripMenuItem1.Text = "Policy";
            chínhSáchToolStripMenuItem.Text = "Policy";
            mônHọcToolStripMenuItem.Text = "Subject";
            mônHọcToolStripMenuItem1.Text = "Subject";
            chínhSáchToolStripMenuItem2.Text = "Policy";
            mônHọcToolStripMenuItem2.Text = "Subject";
            khoaToolStripMenuItem.Text = "Department";
            
            mặcĐịnhToolStripMenuItem.Text = "DeFault";
        }

        private void microsoftWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("WINWORD.exe");
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void khoaToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            if (pq == "Admin")
            {
                f_khoa f = new f_khoa();
                f.Show();
                f.linkLabel1.Visible = false;
            }
            else
            {
                f_khoa t = new f_khoa();
                t.groupBox2.Visible = false;
                t.groupBox3.Dock = DockStyle.Fill;
                t.dgvad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                t.ShowDialog();
            }
        }

        private void giáoViênToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (pq == "Admin")
            {
                Form2 f = new Form2();
                f.Show();
                f.linkLabel1.Visible = false;
            }
            else
            {
                Form2 t = new Form2();
                t.groupBox2.Visible = false;
                t.groupBox3.Dock = DockStyle.Fill;
                t.dgvad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                t.ShowDialog();
            }
        }

        private void lớpToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (pq == "Admin")
            {
                f_lop f = new f_lop();
                f.Show();
                f.linkLabel1.Visible = false;
            }
            else
            {
                f_lop t = new f_lop();
                t.groupBox2.Visible = false;
                t.groupBox3.Dock = DockStyle.Fill;
                t.dgvad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                t.ShowDialog();
            }
        }

        private void sinhViênToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (pq == "Admin")
            {
                Form3 f = new Form3();
                f.Show();
                f.linkLabel1.Visible = false;
            }
            else
            {
                Form3 t = new Form3();
                t.groupBox2.Visible = false;
                t.groupBox3.Dock = DockStyle.Fill;
                t.dgvad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                t.ShowDialog();
            }
        }

        private void mônHọcToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (pq == "Admin")
            {
                frm_monhoc f = new frm_monhoc();
                f.Show();
                f.linkLabel1.Visible = false;
            }
            else
            {
                frm_monhoc t = new frm_monhoc();
                t.groupBox2.Visible = false;
                t.groupBox3.Dock = DockStyle.Fill;
                t.dgvad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                t.ShowDialog();
            }
        }

        private void chínhSáchToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (pq == "Admin")
            {
                frm_CS f = new frm_CS();
                f.Show();
                f.linkLabel1.Visible = false;
            }
            else
            {
                frm_CS t = new frm_CS();
                t.groupBox2.Visible = false;
                t.groupBox3.Dock = DockStyle.Fill;
                t.dgvad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                t.ShowDialog();
            }
        }

        private void điểmToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (pq == "Admin")
            {
                frm_diem f = new frm_diem();
                f.Show();
                f.linkLabel1.Visible = false;
            }
            else
            {
                frm_diem t = new frm_diem();
                t.groupBox2.Visible = false;
                t.groupBox3.Dock = DockStyle.Fill;
                t.dgvad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                t.ShowDialog();
            }
        }

        private void khoaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Search.search_khoa f = new Search.search_khoa();
            f.ShowDialog();
        }

        private void giáoViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Search.search_gv f = new Search.search_gv();
            f.ShowDialog();
        }

        private void lớpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Search.search_lop f = new Search.search_lop();
            f.ShowDialog();
        }

        private void sinhViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Search.search_sv f = new Search.search_sv();
            f.ShowDialog();
        }

        private void mônHọcToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Search.search_mh f = new Search.search_mh();
            f.ShowDialog();
        }

        private void chínhSáchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Search.search_cs f = new Search.search_cs();
            f.ShowDialog();
        }
    }
}
