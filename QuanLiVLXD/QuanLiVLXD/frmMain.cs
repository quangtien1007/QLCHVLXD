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
        public void MoFormMain(Form FormMoi)
        {
            if (HienThiForm != null)
            {
                HienThiForm.Close();
            }
            HienThiForm = FormMoi;
            FormMoi.Show();
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
                TaiKhoan = BUS_TaiKhoan.LayTaiKhoan1(fDN.txtTen.Text, fDN.txtMatKhau.Text);
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
        
        public void HienThiMenu()
        {
            menuDangNhap.Enabled = !bDangNhap;
            menuDangXuat.Enabled = bDangNhap;
            menuDoiMK.Enabled = !bDangNhap;

            if (bDangNhap == false)
            {
                sttTTTaiKhoan.Text = "Chưa đăng nhập";
                sttTTThoiGian.Text = "";

                menuNhapHang.Enabled = false;
                menuQLTK.Visible = false ;
                menuDoiMK.Enabled = false;
                menuTaoTK.Enabled = true;
                menuQLNV.Visible = false;
                menuBaoCao.Visible = false;
                menuTacVu.Enabled = false;
            }
            else
            {
                int quyen;
                if (TaiKhoan == null)
                    quyen = 0;
                else
                {
                    quyen = TaiKhoan.IQuyen;
                    if (quyen == 1)
                    {
                        sttTTTaiKhoan.Text = "Chào " + TaiKhoan.STen + "! (Admin)";
                        sttTTThoiGian.Text = "Thời điểm đăng nhập: " + DateTime.Now;
                    }
                    else if(quyen == 2)
                    {
                        sttTTTaiKhoan.Text = "Chào " + TaiKhoan.STen + "! (User)";
                        sttTTThoiGian.Text = "Thời điểm đăng nhập: " + DateTime.Now;
                    }
                }
                switch (quyen) // hiển thị menu phù hợp với quyền 
                {
                    case 1: // quản trị
                        menuBaoCao.Visible = true;
                        menuTacVu.Enabled = true;
                        menuBaoCao.Enabled = true;
                        menuNhapHang.Enabled = true;
                        menuQLTK.Visible = true;
                        menuDoiMK.Enabled = true;
                        menuTaoTK.Enabled = true;
                        menuQLNV.Visible = true;
                        menuDoiMK.Visible = false;
                        break;
                    case 2: // nhân viên
                        menuDoiMK.Visible = true;
                        menuNhapHang.Enabled = true;
                        menuTacVu.Enabled = true;
                        menuBaoCao.Visible = true;
                        menuBaoCao.Enabled = false;
                        menuDoiMK.Enabled = true;
                        menuBaoCao.Visible = false;
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
            this.Refresh();
            //Refresh lại form đang đứng
            // Đóng các form đang mở (nếu có)
            this.Hide();
            frmMain f = new frmMain();
            f.Show();
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

        private void menuKhachHang_Click(object sender, EventArgs e)
        {
            MoForm(new frmKhachHang());
        }

        private void menuGiaoHang_Click(object sender, EventArgs e)
        {
            MoForm(new frmXuatHang());
        }

        private void menuBCK_Click(object sender, EventArgs e)
        {
            MoForm(new frmBaoCaoKho());
        }

        private void menuBCN_Click(object sender, EventArgs e)
        {
            MoForm(new frmBaoCaoNhapHang());
        }

        private void menuBCX_Click(object sender, EventArgs e)
        {
            MoForm(new frmBaoCaoXuatHang());
        }

        private void menuDSKH_Click(object sender, EventArgs e)
        {
            MoForm(new frmDSKH());
        }

        private void menuDSNCC_Click(object sender, EventArgs e)
        {
            MoForm(new frmDSNCC());
        }

        private void menuDSLH_Click(object sender, EventArgs e)
        {
            MoForm(new frmDSLH());
        }

        private void menuDSHH_Click(object sender, EventArgs e)
        {
            MoForm(new frmDSHH());
        }

        private void menuQLNV_Click(object sender, EventArgs e)
        {
            MoForm(new frmNhanVien());
        }

        private void menuNCC_Click(object sender, EventArgs e)
        {
            MoForm(new frmNhaCungCap());
        }

        private void menuLoaiHang_Click(object sender, EventArgs e)
        {
            MoForm(new frmLoaiHang());
        }

        private void menuHangHoa_Click(object sender, EventArgs e)
        {
            MoForm(new frmHangHoa());
        }

        private void menuKho_Click(object sender, EventArgs e)
        {
            MoForm(new frmKho());
        }

        private void menuHelp_Click(object sender, EventArgs e)
        {
            MoForm(new frmTroGiup());
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn có muốn đóng chương trình", "THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
            else if (traloi == DialogResult.Cancel)
                e.Cancel = true;
        }
    }
}
