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
    public partial class frmLoaiHang : Form
    {
        public frmLoaiHang()
        {
            InitializeComponent();
        }
        private void HienThiLenDataGrid()
        {
            List<DTO_LoaiHang> lstLoaiHang = BUS_LoaiHang.LayLH();
            dgDSLH.DataSource = lstLoaiHang;
        }

        private void frmLoaiHang_Load(object sender, EventArgs e)
        {
            HienThiLenDataGrid();
            SetHeaderText();
            ColorDataGrid();
        }
        public void SetHeaderText()
        {
            dgDSLH.Columns["MaLoai1"].HeaderText = "Mã loại hàng";
            dgDSLH.Columns["MaLoai1"].Width = 350;
            dgDSLH.Columns["TenLoai1"].HeaderText = "Tên loại hàng";
            dgDSLH.Columns["TenLoai1"].Width = 400;
            dgDSLH.Columns["DienGiai1"].HeaderText = "Diễn giải";
            dgDSLH.Columns["DienGiai1"].Width = 400;
            dgDSLH.Columns["TrangThai1"].HeaderText = "Trạng thái";
            dgDSLH.Columns["TrangThai1"].Width = 340;
        }
        public void ColorDataGrid()
        {
            dgDSLH.BorderStyle = BorderStyle.None;
            dgDSLH.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgDSLH.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgDSLH.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgDSLH.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgDSLH.BackgroundColor = Color.White;

            dgDSLH.EnableHeadersVisualStyles = false;
            dgDSLH.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgDSLH.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgDSLH.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaLoai.Text == "" || txtTenLoai.Text == "" || txtDienGiai.Text == "" || txtTrangThai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã loại hàng có độ dài chuỗi hợp lệ hay không
            if (txtMaLoai.Text.Length > 8)
            {
                MessageBox.Show("Mã loại hàng tối đa 8 ký tự!");
                return;
            }
            // Kiểm tra mã khách hàng có bị trùng không
            if (BUS_LoaiHang.TimLoaiHangTheoMa(txtMaLoai.Text) != null)
            {
                MessageBox.Show("Mã loại hàng đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu DTO_KhachHang
            DTO_LoaiHang lh = new DTO_LoaiHang();
            lh.MaLoai1 = txtMaLoai.Text;
            lh.TenLoai1 = txtTenLoai.Text;
            lh.DienGiai1 = txtDienGiai.Text;
            lh.TrangThai1 = txtTrangThai.Text;
            // Thực hiện thêm
            if (BUS_LoaiHang.ThemLoaiHang(lh) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            HienThiLenDataGrid();
            MessageBox.Show("Đã thêm loại hàng.");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaLoai.Text == "" || txtTenLoai.Text == "" || txtDienGiai.Text == "" || txtTrangThai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã loại hàng có độ dài chuỗi hợp lệ hay không
            if (txtMaLoai.Text.Length > 8)
            {
                MessageBox.Show("Mã loại hàng tối đa 8 ký tự!");
                return;
            }
            // Kiểm tra mã khách hàng có bị trùng không
            if (BUS_LoaiHang.TimLoaiHangTheoMa(txtMaLoai.Text) == null)
            {
                MessageBox.Show("Mã khách hàng không tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu DTO_KhachHang
            DTO_LoaiHang lh = new DTO_LoaiHang();
            lh.MaLoai1 = txtMaLoai.Text;
            lh.TenLoai1 = txtTenLoai.Text;
            lh.DienGiai1 = txtDienGiai.Text;
            lh.TrangThai1 = txtTrangThai.Text;
            // Thực hiện thêm
            if (BUS_LoaiHang.CapNhatLoaiHang(lh) == false)
            {
                MessageBox.Show("Không sửa được.");
                return;
            }
            HienThiLenDataGrid();
            MessageBox.Show("Đã sửa loại hàng.");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã loại có tồn tại không
            if (BUS_LoaiHang.TimLoaiHangTheoMa(txtMaLoai.Text) == null)
            {
                MessageBox.Show("Mã loại hàng không tồn tại!");
                return;
            }
            // Gán dữ liệu vào kiểu DTO_LoaiHang
            DTO_LoaiHang lh = new DTO_LoaiHang();
            lh.MaLoai1 = txtMaLoai.Text;

            // Thực hiện xóa 
            if (BUS_LoaiHang.XoaLoaiHang(lh) == false)
            {
                MessageBox.Show("Không xóa được.");
                return;
            }
            HienThiLenDataGrid();
            MessageBox.Show("Đã xóa loại hàng.");
        }

        private void dgDSLH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtMaLoai.Text = dgDSLH.Rows[i].Cells["MaLoai1"].Value.ToString();
            txtTenLoai.Text = dgDSLH.Rows[i].Cells["TenLoai1"].Value.ToString();
            txtDienGiai.Text = dgDSLH.Rows[i].Cells["DienGiai1"].Value.ToString();
            txtTrangThai.Text = dgDSLH.Rows[i].Cells["TrangThai1"].Value.ToString();
        }
    }
}
