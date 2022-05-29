using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;
using BUS;

namespace QuanLiVLXD
{
    public partial class frmDoimk : Form
    {
        public frmDoimk()
        {
            InitializeComponent();
        }
        public DTO_TaiKhoan TaiKhoan;
        public String GetMD5(string txt)
        {
            String str = "";
            Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(txt);
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            foreach (Byte b in buffer)
            {
                str += b.ToString("x2");
            }
            return str;
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DTO_TaiKhoan tk = new DTO_TaiKhoan();
            tk.STen = txtTaiKhoan.Text;
            tk.SMatKhau = GetMD5(txtMKMoi.Text);
            tk.IQuyen = 2;

            TaiKhoan = BUS_TaiKhoan.LayTaiKhoan1(txtTaiKhoan.Text, txtMKCu.Text);

            if (TaiKhoan != null)
            {
                if (txtMKCu.Text == "" || txtMKCu.Text == "" || txtTaiKhoan.Text == "" || txtXacNhanMK.Text == "")
                {
                    MessageBox.Show("Không được bỏ trống !!!");
                }
                else if (txtMKMoi.Text != txtXacNhanMK.Text)
                {
                    MessageBox.Show("Mật khẩu xác nhận không đúng!!!");
                }
                else if (BUS_TaiKhoan.SuaTaiKhoan(tk) == false)
                {
                    MessageBox.Show("Không đổi được.");
                    return;
                }
                else
                    MessageBox.Show("Đã đổi mật khẩu thành công!!!");
            }
            else
            {
                MessageBox.Show("Mật khậu cũ không đúng, nhập lại đi bé!!!");
            }
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
