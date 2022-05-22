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
using BUS;
using DTO;

namespace QuanLiVLXD
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        private void HienThiLenDataGrid()
        {
            List<DTO_KhachHang> lstKhachHang = BUS_KhachHang.LayKH();
            dgDSKH.DataSource = lstKhachHang;
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            HienThiLenDataGrid(); 
            SetHeaderText();
            ColorDataGrid();
        }
        public void SetHeaderText()
        {
            dgDSKH.Columns["MaKH1"].HeaderText = "Mã khách hàng";
            dgDSKH.Columns["MaKH1"].Width= 350;
            dgDSKH.Columns["TenKH1"].HeaderText = "Tên khách hàng";
            dgDSKH.Columns["TenKH1"].Width = 400;
            dgDSKH.Columns["DiaChi1"].HeaderText = "Địa chỉ";
            dgDSKH.Columns["DiaChi1"].Width = 400;
            dgDSKH.Columns["SDT1"].HeaderText = "Số điện thoại";
            dgDSKH.Columns["SDT1"].Width = 340;
        }
        public void ColorDataGrid()
        {
            dgDSKH.BorderStyle = BorderStyle.None;
            dgDSKH.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgDSKH.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgDSKH.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgDSKH.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgDSKH.BackgroundColor = Color.White;

            dgDSKH.EnableHeadersVisualStyles = false;
            dgDSKH.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgDSKH.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgDSKH.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void dgDSKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtMaKH.Text = dgDSKH.Rows[i].Cells["MaKH1"].Value.ToString();
            txtTenKH.Text = dgDSKH.Rows[i].Cells["TenKH1"].Value.ToString();
            txtDiaChi.Text = dgDSKH.Rows[i].Cells["DiaChi1"].Value.ToString();
            txtSDT.Text = dgDSKH.Rows[i].Cells["SDT1"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaKH.Text == "" || txtTenKH.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã khách hàng có độ dài chuỗi hợp lệ hay không
            if (txtMaKH.Text.Length > 8)
            {
                MessageBox.Show("Mã khách hàng tối đa 8 ký tự!");
                return;
            }
            if (txtSDT.Text.Length < 10)
            {
                MessageBox.Show("Số điện thoại ít nhất 10 số!!!", "Thông báo");
                return;
            }
            // Kiểm tra mã khách hàng có bị trùng không
            if (BUS_KhachHang.TimKhachHangTheoMa(txtMaKH.Text) != null)
            {
                MessageBox.Show("Mã khách hàng đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu DTO_KhachHang
            DTO_KhachHang kh = new DTO_KhachHang();
            kh.MaKH1 = txtMaKH.Text;
            kh.TenKH1 = txtTenKH.Text;
            kh.DiaChi1 = txtDiaChi.Text;
            kh.SDT1 = txtSDT.Text;
            // Thực hiện thêm
            if (BUS_KhachHang.ThemKhachHang(kh) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            HienThiLenDataGrid();
            MessageBox.Show("Đã thêm khách hàng.");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaKH.Text == "" || txtTenKH.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã khách hàng có độ dài chuỗi hợp lệ hay không
            if (txtMaKH.Text.Length > 8)
            {
                MessageBox.Show("Mã khách hàng tối đa 8 ký tự!");
                return;
            }
            if (txtSDT.Text.Length < 10)
            {
                MessageBox.Show("Số điện thoại ít nhất 10 số!!!", "Thông báo");
                return;
            }
            // Kiểm tra mã khách hàng có bị trùng không
            if (BUS_KhachHang.TimKhachHangTheoMa(txtMaKH.Text) == null)
            {
                MessageBox.Show("Mã khách hàng không tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu DTO_KhachHang
            DTO_KhachHang kh = new DTO_KhachHang();
            kh.MaKH1 = txtMaKH.Text;
            kh.TenKH1 = txtTenKH.Text;
            kh.DiaChi1 = txtDiaChi.Text;
            kh.SDT1 = txtSDT.Text;
            // Thực hiện thêm
            if (BUS_KhachHang.CapNhatKhachHang(kh) == false)
            {
                MessageBox.Show("Không sửa được.");
                return;
            }
            HienThiLenDataGrid();
            MessageBox.Show("Đã sửa khách hàng.");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã NCC có tồn tại không
            if (BUS_KhachHang.TimKhachHangTheoMa(txtMaKH.Text) == null)
            {
                MessageBox.Show("Mã khách hàng không tồn tại!");
                return;
            }
            // Gán dữ liệu vào kiểu DTO_NCC
            DTO_KhachHang kh = new DTO_KhachHang();
            kh.MaKH1 = txtMaKH.Text;

            // Thực hiện xóa 
            if (BUS_KhachHang.XoaKhachHang(kh) == false)
            {
                MessageBox.Show("Không xóa được.");
                return;
            }
            HienThiLenDataGrid();
            MessageBox.Show("Đã xóa khách hàng.");
        }
    }
}
