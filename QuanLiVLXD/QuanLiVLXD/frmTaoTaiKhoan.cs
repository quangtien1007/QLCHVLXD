using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace QuanLiVLXD
{
    public partial class frmTaoTaiKhoan : Form
    {
        public frmTaoTaiKhoan()
        {
            InitializeComponent();
        }

        private void btnDangki_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được bỏ trống !!!");
                return;
            }
            else if (txtMatKhau.Text != txtXacNhan.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không đúng, vui lòng nhập lại !!!");
                return;
            }
            DTO_TaiKhoan tk = new DTO_TaiKhoan();
            tk.STen = txtTaiKhoan.Text;
            tk.SMatKhau = txtMatKhau.Text;
            tk.IQuyen = 2;
            if (BUS_TaiKhoan.ThemTaiKhoan(tk) == false)
            {
                MessageBox.Show("Có lỗi khi đăng kí tài khoản");
                return;
            }
            MessageBox.Show("Tạo tài khoản thành công!!!");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTaoTaiKhoan_Load(object sender, EventArgs e)
        {
            txtTaiKhoan.Focus();
        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
