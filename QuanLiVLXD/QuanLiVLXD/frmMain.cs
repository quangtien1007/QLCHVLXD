using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAO;
using DTO;

namespace QuanLiVLXD
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
            
        public DTO_TaiKhoan TaiKhoan; // lưu thông tin người dùng đã đăng nhập 
        public bool bDangNhap = false; // cho biết đã đăng nhập thành công chưa
        public Form HienThiForm;
        public void MoForm(Form Formmoi)
        {
            if (HienThiForm != null)
            {
                HienThiForm.Close();
            }
            HienThiForm = Formmoi;
            Formmoi.TopLevel = false;
            Formmoi.FormBorderStyle = FormBorderStyle.None;
            Formmoi.Dock = DockStyle.Fill;
            panelCentral.Controls.Add(Formmoi);
            panelCentral.Tag = Formmoi;
            Formmoi.BringToFront();
            Formmoi.Show();
        }
        private void menuDoiMK_Click(object sender, EventArgs e)
        {
            frmDoimk d = new frmDoimk();
            d.ShowDialog();
        }

        private void menuNhapHang_Click(object sender, EventArgs e)
        {
            MoForm(new frmNhapHang());
        }
        frmDangNhap fDN;
        private void menuDangNhap_Click(object sender, EventArgs e)
        { 
            fDN = new frmDangNhap();
            if (fDN.ShowDialog() == DialogResult.OK)
            {
                TaiKhoan = BUS_TaiKhoan.LayTaiKhoan(fDN.txtTen.Text, fDN.txtMatKhau.Text);
                if (TaiKhoan != null)
                {
                    bDangNhap = true;
                    MessageBox.Show("Đăng nhập thành công !!!");
                }
                else
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu !!!");
            }
            else
            {
                bDangNhap = false;
            }
            HienThiMenu();
        }
        private void HienThiMenu()
        {
            menuDangNhap.Enabled = !bDangNhap;
            menuDangXuat.Enabled = bDangNhap;
            menuDoiMK.Enabled = !bDangNhap;

            if (bDangNhap == false)
            {
                sttTTTaiKhoan.Text = "Chưa đăng nhập";
                sttTTThoiGian.Text = "";

                menuNhapHang.Enabled = false;
                menuQLTK.Enabled = false;
                menuDoiMK.Enabled = false;
                menuDanhMuc.Enabled = false;
                menuBanHang.Enabled = false;
            }
            else
            {
                int quyen;
                if (TaiKhoan == null)
                    quyen = 0;
                else
                {
                    quyen = TaiKhoan.IQuyen;
                    sttTTTaiKhoan.Text = "Chào " + TaiKhoan.STen + "! ";
                    sttTTThoiGian.Text = "Thời điểm đăng nhập: " + DateTime.Now;
                }
                switch (quyen) // hiển thị menu phù hợp với quyền 
                {
                    case 1: // quản trị
                        menuNhapHang.Enabled = true;
                        menuGiaoHang.Enabled = true;
                        menuDoiMK.Visible = false;
                        menuQLTK.Enabled = true;
                        menuDangXuat.Enabled = true;
                        break;
                    case 2: // nhân viên
                        menuBanHang.Enabled = true;
                        menuDanhMuc.Enabled = false;
                        menuDoiMK.Enabled = true;
                        break;
                    default:
                        break;

                }
            }

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            HienThiMenu();
        }

        private void menuDangXuat_Click(object sender, EventArgs e)
        {
            // Đóng các form đang mở (nếu có)
            /*foreach (Form f in this.MdiChildren)
            {
                if (!f.IsDisposed)
                    f.Close();
            }*/
  
            frmMain m = new frmMain();
            m.Show();
            // Gán lại trạng thái đăng nhập = false
            bDangNhap = false;
            HienThiMenu();
        }

        private void menuQLTK_Click(object sender, EventArgs e)
        {
            MoForm(new frmQuanliTK());
        }
        private void menuTaoTK_Click(object sender, EventArgs e)
        {
            MoForm(new frmTaoTaiKhoan());
        }
        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoForm(new frmNhaCungCap());
        }
        private void menuKhachHang_Click(object sender, EventArgs e)
        {
            MoForm(new frmKhachHang());
        }
        private void loạiHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoForm(new frmLoaiHang());
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoForm(new frmHangHoa());
        }

        private void menuGiaoHang_Click(object sender, EventArgs e)
        {
            MoForm(new frmXuatHang());
        }
    }
}
