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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        public void SetHeaderText()
        {
            dgDSNV.Columns["TenNV1"].HeaderText = "Tên nhân viên";
            dgDSNV.Columns["TenNV1"].Width = 250;
            dgDSNV.Columns["NgaySinh1"].HeaderText = "Ngày sinh";
            dgDSNV.Columns["NgaySinh1"].Width = 240;
            dgDSNV.Columns["GioiTinh1"].HeaderText = "Giới tính";
            dgDSNV.Columns["GioiTinh1"].Width = 250;
            dgDSNV.Columns["DiaChi1"].HeaderText = "Địa chỉ";
            dgDSNV.Columns["DiaChi1"].Width = 250;
            dgDSNV.Columns["SDT1"].HeaderText = "SĐT";
            dgDSNV.Columns["SDT1"].Width = 250;
            dgDSNV.Columns["DienGiai1"].HeaderText = "Diễn giải";
            dgDSNV.Columns["DienGiai1"].Width = 250;
        }
        private void HienThiLenDataGrid()
        {
            List<DTO_NhanVien> lstNV = BUS_NhanVien.LayNV();
            dgDSNV.DataSource = lstNV;
        }
        public void ColorDataGrid()
        {
            dgDSNV.BorderStyle = BorderStyle.None;
            dgDSNV.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgDSNV.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgDSNV.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgDSNV.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgDSNV.BackgroundColor = Color.White;

            dgDSNV.EnableHeadersVisualStyles = false;
            dgDSNV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgDSNV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgDSNV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            HienThiLenDataGrid();
            ColorDataGrid();
            SetHeaderText();
        }

        private void dgDSNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtMaNV.Text = dgDSNV.Rows[i].Cells["MaNV1"].Value.ToString();
            txtTenNV.Text = dgDSNV.Rows[i].Cells["TenNV1"].Value.ToString();
            txtDiaChi.Text = dgDSNV.Rows[i].Cells["DiaChi1"].Value.ToString();
            txtSDT.Text = dgDSNV.Rows[i].Cells["SDT1"].Value.ToString();
            cbGioiTinh.Text = dgDSNV.Rows[i].Cells["GioiTinh1"].Value.ToString();
            dtpNgaySinh.Text = dgDSNV.Rows[i].Cells["NgaySinh1"].Value.ToString();
            txtDienGiai.Text = dgDSNV.Rows[i].Cells["DienGiai1"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaNV.Text == "" || cbGioiTinh.Text == "" || txtTenNV.Text == "" || txtSDT.Text == "" || txtDienGiai.Text == "" || dtpNgaySinh.Text == "" || txtDiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã hàng hóa có độ dài chuỗi hợp lệ hay không
            if (txtMaNV.Text.Length > 6)
            {
                MessageBox.Show("Mã nhân viên tối đa 6 ký tự!");
                return;
            }
            // Kiểm tra mã hàng hóa có bị trùng không
            if (BUS_NhanVien.TimNhanVienTheoMa(txtMaNV.Text) != null)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu DTO_NhanVien
            string ns = dtpNgaySinh.Value.ToString("yyyy/MM/dd");
            DTO_NhanVien nv = new DTO_NhanVien();
            nv.MaNV1 = txtMaNV.Text;
            nv.TenNV1 = txtTenNV.Text;
            nv.GioiTinh1 = cbGioiTinh.Text;
            nv.NgaySinh1 = ns;
            nv.DiaChi1 = txtDiaChi.Text;
            nv.SDT1 = txtSDT.Text;
            nv.DienGiai1 = txtDienGiai.Text;
            nv.Flag1 = 1;
            // Thực hiện thêm
            if (BUS_NhanVien.ThemNhanVien(nv) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            HienThiLenDataGrid();
            MessageBox.Show("Đã thêm nhân viên.");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaNV.Text == "" || cbGioiTinh.Text == "" || txtTenNV.Text == "" || txtSDT.Text == "" || txtDienGiai.Text == "" || dtpNgaySinh.Text == "" || txtDiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã nhân viên đã có chưa
            if (BUS_NhanVien.TimNhanVienTheoMa(txtMaNV.Text) == null)
            {
                MessageBox.Show("Mã nhân viên không tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu DTO_NhanVien
            string ns = dtpNgaySinh.Value.ToString("yyyy/MM/dd");
            DTO_NhanVien nv = new DTO_NhanVien();
            nv.MaNV1 = txtMaNV.Text;
            nv.TenNV1 = txtTenNV.Text;
            nv.GioiTinh1 = cbGioiTinh.Text;
            nv.NgaySinh1 = ns;
            nv.DiaChi1 = txtDiaChi.Text;
            nv.SDT1 = txtSDT.Text;
            nv.DienGiai1 = txtDienGiai.Text;
            nv.Flag1 = 1;
            // Thực hiện thêm
            if (BUS_NhanVien.CapNhatNhanVien(nv) == false)
            {
                MessageBox.Show("Không cập nhật được.");
                return;
            }
            HienThiLenDataGrid();
            MessageBox.Show("Đã cập nhật nhân viên.");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã nhân viên có tồn tại không
            if (BUS_NhanVien.TimNhanVienTheoMa(txtMaNV.Text) == null)
            {
                MessageBox.Show("Mã nhân viên không tồn tại!");
                return;
            }
            // Gán dữ liệu vào kiểu DTO_NhanVien
            DTO_NhanVien nv = new DTO_NhanVien();
            nv.MaNV1 = txtMaNV.Text;

            // Thực hiện xóa 
            if (BUS_NhanVien.XoaNhanVien(nv) == false)
            {
                MessageBox.Show("Không xóa được.");
                return;
            }
            HienThiLenDataGrid();
            MessageBox.Show("Đã xóa nhân viên.");
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (rdTen.Checked == true)
            {
                List<DTO_NhanVien> nv = BUS_NhanVien.LayNV();
                List<DTO_NhanVien> kq = (from ten in nv
                                         where ten.TenNV1.Contains(txtTim.Text)
                                         select ten).ToList();
                dgDSNV.DataSource = kq;
            }
            else if (rdMa.Checked == true)
            {
                List<DTO_NhanVien> nv = BUS_NhanVien.LayNV();
                List<DTO_NhanVien> kq = (from ma in nv
                                         where ma.MaNV1.Contains(txtTim.Text)
                                         select ma).ToList();
                dgDSNV.DataSource = kq;
            }
        }
    }
}
