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
    public partial class frmXuatHang : Form
    {
        public frmXuatHang()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        public void SetHeaderText()
        {
            dgDSHDX.Columns["SoHDXuat1"].HeaderText = "Số chứng từ xuất";
            dgDSHDX.Columns["SoHDXuat1"].Width = 350;
            dgDSHDX.Columns["TenNV1"].HeaderText = "Tên nhân viên ";
            dgDSHDX.Columns["TenNV1"].Width = 400;
            dgDSHDX.Columns["TenKH1"].HeaderText = "Tên khách hàng";
            dgDSHDX.Columns["TenKH1"].Width = 400;
            dgDSHDX.Columns["NgayLap1"].HeaderText = "Ngày lập";
            dgDSHDX.Columns["NgayLap1"].Width = 340;

        }
        private void HienThiLenDataGrid()
        {
            List<DTO_HDXUAT> lstHDXuat = BUS_HDXUAT.LayHDXuat();
            dgDSHDX.DataSource = lstHDXuat;
        }
        public void ColorDataGrid()
        {
            dgDSHDX.BorderStyle = BorderStyle.None;
            dgDSHDX.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgDSHDX.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgDSHDX.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgDSHDX.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgDSHDX.BackgroundColor = Color.White;

            dgDSHDX.EnableHeadersVisualStyles = false;
            dgDSHDX.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgDSHDX.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgDSHDX.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        private void HienThiLenCombobox()
        {
            List<DTO_KhachHang> lstHDXuat = BUS_KhachHang.LayKH();
            cbKH.DataSource = lstHDXuat;
            cbKH.DisplayMember = "MaKH1";
            cbKH.ValueMember = "MaKH1";
        }
        private void frmXuatHang_Load(object sender, EventArgs e)
        {
            HienThiLenDataGrid();
            ColorDataGrid();
            SetHeaderText();
            HienThiLenCombobox();
        }

        private void cbKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dgDSHDX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtSoHD.Text = dgDSHDX.Rows[i].Cells["SoHDXuat1"].Value.ToString();
            cbKH.Text = dgDSHDX.Rows[i].Cells["MaKH1"].Value.ToString();
            txtNV.Text = dgDSHDX.Rows[i].Cells["MaNV1"].Value.ToString();
            dtpNgayLap.Text = dgDSHDX.Rows[i].Cells["NgayLap1"].Value.ToString();
        }
        
        private void btnXuatHang_Click(object sender, EventArgs e)
        {
            //frmCTHDXuat fCT = new frmCTHDXuat(txtSoHD.Text, cbKH.Text, dtpNgayLap.Text, txtNV.Text);
            //DTO_HDXUAT hdx = new DTO_HDXUAT();
            frmCTHDXuat f = new frmCTHDXuat(txtSoHD.Text,cbKH.Text,dtpNgayLap.Text,txtNV.Text);
            //MoForm(new frmCTHDXuat(txtSoHD.Text, cbKH.Text, dtpNgayLap.Text, txtNV.Text);
            this.Hide();
            f.Show();
            //MoForm(new frmCTHDXuat());
        }
        Form HienThiForm;
        frmMain fM;
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
            fM.panelCentral.Controls.Add(Formmoi);
            fM.panelCentral.Tag = Formmoi;
            Formmoi.BringToFront();
            Formmoi.Show();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtSoHD.Text == "" || cbKH.Text == "" || txtNV.Text == "" || dtpNgayLap.Text == "")
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
            if (BUS_HDXUAT.TimHDXTheoMa(txtSoHD.Text) != null)
            {
                MessageBox.Show("Mã khách hàng đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu DTO_KhachHang
            string nbd = dtpNgayLap.Value.ToString("yyyy/MM/dd");
            DTO_HDXUAT hdx = new DTO_HDXUAT();
            hdx.SoHDXuat1 = txtSoHD.Text;
            hdx.MaKH1 = cbKH.Text;
            hdx.MaNV1 = txtNV.Text;
            hdx.NgayLap1 = nbd;
            hdx.Flag1 = 1;
            // Thực hiện thêm
            if (BUS_HDXUAT.ThemHDX(hdx) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            HienThiLenDataGrid();
            MessageBox.Show("Đã thêm hóa đơn.");
        }

        private void rdTen_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (rdTen.Checked == true)
            {
                List<DTO_HDXUAT> lh = BUS_HDXUAT.LayHDXuat();
                List<DTO_HDXUAT> kq = (from hd in lh
                                       where hd.TenKH1.Contains(txtTim.Text)
                                       select hd).ToList();
                dgDSHDX.DataSource = kq;
            }
            else if (rdMa.Checked == true)
            {
                List<DTO_HDXUAT> hh = BUS_HDXUAT.LayHDXuat();
                List<DTO_HDXUAT> kq = (from ma in hh
                                       where ma.SoHDXuat1.Contains(txtTim.Text)
                                       select ma).ToList();
                dgDSHDX.DataSource = kq;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtSoHD.Text == "" || cbKH.Text == "" || txtNV.Text == "" || dtpNgayLap.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã khách hàng có bị trùng không
            if (BUS_HDXUAT.TimHDXTheoMa(txtSoHD.Text) == null)
            {
                MessageBox.Show("Mã khách hàng không tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu DTO_KhachHang
            DTO_HDXUAT hdx = new DTO_HDXUAT();
            hdx.SoHDXuat1 = txtSoHD.Text;
            hdx.MaKH1 = cbKH.Text;
            hdx.MaNV1 = txtNV.Text;
            hdx.NgayLap1 = dtpNgayLap.Text;
            hdx.Flag1 = 1;
            // Thực hiện thêm
            if (BUS_HDXUAT.CapNhatHDX(hdx) == false)
            {
                MessageBox.Show("Không cập nhật được.");
                return;
            }
            HienThiLenDataGrid();
            MessageBox.Show("Đã cập nhật hóa đơn.");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã NCC có tồn tại không
            if (BUS_HDXUAT.TimHDXTheoMa(txtSoHD.Text) == null)
            {
                MessageBox.Show("Số hóa đơn không tồn tại!");
                return;
            }
            // Gán dữ liệu vào kiểu DTO_NCC
            DTO_HDXUAT hdx = new DTO_HDXUAT();
            hdx.SoHDXuat1 = txtSoHD.Text;

            // Thực hiện xóa 
            if (BUS_HDXUAT.XoaHDX(hdx) == false)
            {
                MessageBox.Show("Không xóa được.");
                return;
            }
            HienThiLenDataGrid();
            MessageBox.Show("Đã xóa hóa đơn.");
        }
    }
}
