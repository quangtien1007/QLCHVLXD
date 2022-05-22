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
    public partial class frmNhapHang : Form
    {
        public frmNhapHang()
        {
            InitializeComponent();
        }
        
        public Form HienThiForm;
     
        private void btnNhap_Click(object sender, EventArgs e)
        {

        }
        public void SetHeaderText()
        {
            dgDSHDN.Columns["SoHDNhap1"].HeaderText = "Số chứng từ nhập";
            dgDSHDN.Columns["SoHDNhap1"].Width = 350;
            dgDSHDN.Columns["TenNV1"].HeaderText = "Tên nhân viên ";
            dgDSHDN.Columns["TenNV1"].Width = 400;
            dgDSHDN.Columns["TenNCC1"].HeaderText = "Tên nhà cung cấp";
            dgDSHDN.Columns["TenNCC1"].Width = 400;
            dgDSHDN.Columns["NgayLap1"].HeaderText = "Ngày lập";
            dgDSHDN.Columns["NgayLap1"].Width = 340;

        }
        private void HienThiLenDataGrid()
        {
            List<DTO_HDNHAP> lstHDNhap = BUS_HDNHAP.LayHDNhap();
            dgDSHDN.DataSource = lstHDNhap;
        }
        public void ColorDataGrid()
        {
            dgDSHDN.BorderStyle = BorderStyle.None;
            dgDSHDN.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgDSHDN.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgDSHDN.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgDSHDN.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgDSHDN.BackgroundColor = Color.White;

            dgDSHDN.EnableHeadersVisualStyles = false;
            dgDSHDN.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgDSHDN.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgDSHDN.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        private void HienThiLenCombobox()
        {
            List<DTO_NCC> lstNCC = BUS_NCC.LayNCC();
            cbNCC.DataSource = lstNCC;
            cbNCC.DisplayMember = "TenNCC1";
            cbNCC.ValueMember = "MaNCC1";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtSoHD.Text == "" || cbNCC.Text == "" || txtNV.Text == "" || dtpNgayLap.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra số hóa đơn có độ dài chuỗi hợp lệ hay không
            if (txtSoHD.Text.Length > 8)
            {
                MessageBox.Show("Số hóa đơn tối đa 8 ký tự!");
                return;
            }
            // Kiểm tra mã khách hàng có bị trùng không
            if (BUS_HDNHAP.TimHDNTheoMa(txtSoHD.Text) != null)
            {
                MessageBox.Show("Mã khách hàng đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu DTO_KhachHang
            DTO_HDNHAP hdn = new DTO_HDNHAP();
            hdn.SoHDNhap1 = txtSoHD.Text;
            hdn.MaNCC1 = cbNCC.SelectedValue.ToString();
            hdn.MaNV1 = txtNV.Text;
            hdn.NgayLap1 = dtpNgayLap.Text;
            // Thực hiện thêm
            if (BUS_HDNHAP.ThemHDN(hdn) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            HienThiLenDataGrid();
            MessageBox.Show("Đã thêm hóa đơn.");
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            HienThiLenDataGrid(); ;
            ColorDataGrid();
            HienThiLenCombobox();
            SetHeaderText();
        }
    }
}
