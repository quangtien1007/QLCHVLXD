using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiVLXD
{
    public partial class frmQuanliTK : Form
    {
        public frmQuanliTK()
        {
            InitializeComponent();
        }
        private void HienThiDSTKLenDataGridView()
        {
            List<DTO_TaiKhoan> lstTaiKhoan = BUS_TaiKhoan.LayTKhoan();
            dgDSTK.DataSource = lstTaiKhoan;
        }

        private void frmQuanliTK_Load(object sender, EventArgs e)
        {
            HienThiDSTKLenDTGV();
            ColorDataGrid();
            SetHeaderText();
        }
        private void ColorDataGrid()
        {
            dgDSTK.BorderStyle = BorderStyle.None;
            dgDSTK.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgDSTK.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgDSTK.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgDSTK.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgDSTK.BackgroundColor = Color.White;

            dgDSTK.EnableHeadersVisualStyles = false;
            dgDSTK.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgDSTK.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgDSTK.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        }

        private void dgDSTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtTaiKhoan.Text = dgDSTK.Rows[i].Cells["STen"].Value.ToString();
            txtMatKhau.Text = dgDSTK.Rows[i].Cells["SMatKhau"].Value.ToString();
            txtQuyen.Text = dgDSTK.Rows[i].Cells["IQuyen"].Value.ToString();
        }
        private void HienThiDSTKLenDTGV()
        {
            List<DTO_TaiKhoan> lstTaiKhoan = BUS_TaiKhoan.LayTKhoan();
            dgDSTK.DataSource = lstTaiKhoan;   
        }
        private void SetHeaderText()
        {
            dgDSTK.Columns["STen"].HeaderText = "Tên tài khoản";
            dgDSTK.Columns["STen"].Width = 200;
            dgDSTK.Columns["SMatKhau"].HeaderText = "Mật khẩu";
            dgDSTK.Columns["SMatKhau"].Width = 200;
            dgDSTK.Columns["IQuyen"].HeaderText = "Quyền";
            dgDSTK.Columns["IQuyen"].Width = 200;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Ten dang nhap va tai khoan khong duoc bo trong!!!");
                return;
            }
            DTO_TaiKhoan tk = new DTO_TaiKhoan();
            tk.STen = txtTaiKhoan.Text;
            tk.SMatKhau = txtMatKhau.Text;
            tk.IQuyen = int.Parse(txtQuyen.Text);
            if (BUS_TaiKhoan.ThemTaiKhoan(tk) == false)
            {
                MessageBox.Show("Không thêm được!!!","Thông báo");
                return;
            }
            HienThiDSTKLenDTGV();
            MessageBox.Show("Đã thêm nhân viên.","Thông báo");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Gán dữ liệu vào kiểu NhanVienDTO
            DTO_TaiKhoan tk = new DTO_TaiKhoan();
            tk.STen = txtTaiKhoan.Text;

            // Thực hiện xóa (xóa quá trình lương trước khi xóa nhân viên)
            if (BUS_TaiKhoan.XoaTaiKhoan(tk) == false)
            {
                MessageBox.Show("Không xóa được.");
                return;
            }
            HienThiDSTKLenDTGV();
            MessageBox.Show("Đã xóa nhân viên.");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Gán dữ liệu vào kiểu NhanVienDTO
            DTO_TaiKhoan tk = new DTO_TaiKhoan();
            tk.STen = txtTaiKhoan.Text;
            tk.SMatKhau = txtMatKhau.Text;
            tk.IQuyen = int.Parse(txtQuyen.Text);

            if (BUS_TaiKhoan.SuaTaiKhoan(tk) == false)
            {
                MessageBox.Show("Không sửa được.");
                return;
            }
            HienThiDSTKLenDTGV();
            MessageBox.Show("Đã sửa nhân viên.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgDSTK_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtTaiKhoan.Text = dgDSTK.Rows[i].Cells["STen"].Value.ToString();
            txtMatKhau.Text = dgDSTK.Rows[i].Cells["SMatKhau"].Value.ToString();
            txtQuyen.Text = dgDSTK.Rows[i].Cells["IQuyen"].Value.ToString();
        }
    }
}
