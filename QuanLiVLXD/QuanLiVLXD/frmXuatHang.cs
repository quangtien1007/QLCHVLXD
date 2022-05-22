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
            List<DTO_HDXUAT> lstHDXuat = BUS_HDXUAT.LayHDXuat();
            cbKH.DataSource = lstHDXuat;
            cbKH.DisplayMember = "TenKH1";
            cbKH.ValueMember = "TenNV1";
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
            txtNV.Text = cbKH.SelectedValue.ToString();
        }

        private void dgDSHDX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtSoHD.Text = dgDSHDX.Rows[i].Cells["SoHDXuat1"].Value.ToString();
            cbKH.Text = dgDSHDX.Rows[i].Cells["TenKH1"].Value.ToString();
            txtNV.Text = dgDSHDX.Rows[i].Cells["TenNV1"].Value.ToString();
            dtpNgayLap.Text = dgDSHDX.Rows[i].Cells["NgayLap1"].Value.ToString();
        }

        
        Form HienThiForm;
        frmMain fM;
        private void btnXuatHang_Click(object sender, EventArgs e)
        {
            MoForm(new frmCTHDXuat());
        }
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
            DTO_HDXUAT hdx = new DTO_HDXUAT();
            hdx.SoHDXuat1 = txtSoHD.Text;
            hdx.MaKH1 = cbKH.Text;
            hdx.MaNV1 = txtNV.Text;
            hdx.NgayLap1 = dtpNgayLap.Text;
            // Thực hiện thêm
            if (BUS_HDXUAT.ThemHDX(hdx) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            HienThiLenDataGrid();
            MessageBox.Show("Đã thêm hóa đơn.");
        }
    }
}
