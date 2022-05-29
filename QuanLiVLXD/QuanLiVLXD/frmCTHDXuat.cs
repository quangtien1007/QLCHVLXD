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
using DAO;
using BUS;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

namespace QuanLiVLXD
{
    public partial class frmCTHDXuat : Form
    {
        private string SoHD, KhachHang, KhachHang1, NhanVien, NgayLap;
        public frmCTHDXuat()
        {
            InitializeComponent();
        }
        public frmCTHDXuat(string SoHD, string KhachHang, string KhachHang1, string NgayLap, string NhanVien)
        {
            InitializeComponent();
            this.SoHD = SoHD;
            this.KhachHang = KhachHang;
            this.KhachHang1 = KhachHang1;
            this.NgayLap = NgayLap;
            this.NhanVien = NhanVien;
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }
        public void HienThiLenComboBox()
        {
            List<DTO_KhachHang> lstKH = BUS_KhachHang.LayKH();
            cbKH.DataSource = lstKH;
            cbKH.DisplayMember = "MaKH1";
            cbKH.ValueMember = "DiaChi1";
        }
        public void HienThiLenComboBox1()
        {
            List<DTO_KhachHang> lstKH = BUS_KhachHang.LayKH();
            cbKH1.DataSource = lstKH;
            cbKH1.DisplayMember = "MaKH1";
            cbKH1.ValueMember = "SDT1";
        }
        private void cbKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDiaChi.Text = cbKH.SelectedValue.ToString();
        }

        private void cbKH1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSDT.Text = cbKH1.SelectedValue.ToString();
        }
        private void HienThiLenComBox2()
        {
            List<DTO_HangHoa> lstHH = BUS_HangHoa.LayHH();
            cbHangHoa.DataSource = lstHH;
            cbHangHoa.DisplayMember = "TenHH1";
            cbHangHoa.ValueMember = "DVT1";
        }
        private void HienThiLenComBox3()
        {
            List<DTO_HangHoa> lstHH = BUS_HangHoa.LayHH();
            cbHH1.DataSource = lstHH;
            cbHH1.DisplayMember = "TenHH1";
            cbHH1.ValueMember = "XuatXu1";
        }
        private void HienThiLenComBox4()
        {
            List<DTO_DonGia> lstDG = BUS_DonGia.LayDG();
            cbHH2.DataSource = lstDG;
            cbHH2.DisplayMember = "TenHH1";
            cbHH2.ValueMember = "DonGia1";
        }
        private void HienThiLenComBox5()
        {
            List<DTO_Kho> lstKho = BUS_Kho.LayKho();
            cbHH3.DataSource = lstKho;
            cbHH3.DisplayMember = "MaHH1";
            cbHH3.ValueMember = "IDKho1";
        }
        private void HienThiLenComBox6()
        {
            List<DTO_HangHoa> lstHH = BUS_HangHoa.LayHH();
            cbHH4.DataSource = lstHH;
            cbHH4.DisplayMember = "TenHH1";
            cbHH4.ValueMember = "MaHH1";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtIDKho.Text == "" || txtIDX.Text == "" || txtDonGia.Text == "" || txtSoHD.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã loại hàng có độ dài chuỗi hợp lệ hay không
            if (txtIDX.Text.Length > 3)
            {
                MessageBox.Show("Mã loại hàng tối đa 3 ký tự!");
                return;
            }
            // Kiểm tra mã khách hàng có bị trùng không
            if (BUS_CTHDX.TimTheoMa(txtIDX.Text) != null)
            {
                MessageBox.Show("Mã đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu DTO_KhachHang
            DTO_CTHDXUAT h = new DTO_CTHDXUAT();
            h.IDXUAT1 = int.Parse(txtIDX.Text);
            h.IDKHO1 = int.Parse(txtIDKho.Text);
            h.SoHDXuat1 = txtSoHD.Text;
            h.SoLuong1 = int.Parse(txtSoLuong.Text);
            h.ThanhTien1 = int.Parse(txtThanhTien.Text);
            DTO_Kho k = new DTO_Kho();
            k.SoLuongKho1 = int.Parse(txtSoLuong.Text);
            k.IDKho1 = int.Parse(txtIDKho.Text);
            // Thực hiện thêm
            if (BUS_CTHDX.ThemCTHDX(h) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            if (BUS_Kho.xuatkho(k) == false)
            {
                MessageBox.Show("Không update được.");
                return;
            }
            HienThiLenDataGrid();
            MessageBox.Show("Đã thêm.");
        }

        private void dgDSCTHDX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            cbHangHoa.Text = dgDSCTHDX.Rows[i].Cells["TenHH1"].Value.ToString();
            txtSoLuong.Text = dgDSCTHDX.Rows[i].Cells["SoLuong1"].Value.ToString();
            txtDVT.Text = dgDSCTHDX.Rows[i].Cells["DVT1"].Value.ToString();
            txtDonGia.Text = dgDSCTHDX.Rows[i].Cells["DonGia1"].Value.ToString();
            txtXuatXu.Text = dgDSCTHDX.Rows[i].Cells["XuatXu1"].Value.ToString();
        }

        private void HienThiLenDataGrid()
        {
            List<DTO_CTHDXUAT> lstCTHDX = BUS_CTHDX.LayCTHDXuat();
            dgDSCTHDX.DataSource = lstCTHDX;
        }

        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuDangNhap_Click(object sender, EventArgs e)
        {

        }

        private void txtDVT_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbHH1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtXuatXu.Text = cbHH1.SelectedValue.ToString();
        }

        private void cbHangHoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDVT.Text = cbHangHoa.SelectedValue.ToString();
        }

        private void cbHH1_TextChanged(object sender, EventArgs e)
        {
            cbHangHoa.Text = cbHH1.Text;
            cbHH2.Text = cbHH1.Text;
        }

        private void cbHH2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDonGia.Text = cbHH2.SelectedValue.ToString();
        }

        private void cbHH3_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIDKho.Text = cbHH3.SelectedValue.ToString();
        }

        private void cbHH4_TextChanged(object sender, EventArgs e)
        {
            cbHH1.Text = cbHH4.Text;
        }

        private void cbHH4_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbHH3.Text = cbHH4.SelectedValue.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtIDKho.Text == "" || txtIDX.Text == "" || txtDonGia.Text == "" || txtSoHD.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã có bị trùng không
            if (BUS_CTHDX.TimTheoMa(txtIDX.Text) == null)
            {
                MessageBox.Show("Mã không tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu DTO_KhachHang
            DTO_CTHDXUAT h = new DTO_CTHDXUAT();
            h.IDXUAT1 = int.Parse(txtIDX.Text);
            h.IDKHO1 = int.Parse(txtIDKho.Text);
            h.SoHDXuat1 = txtSoHD.Text;
            h.SoLuong1 = int.Parse(txtSoLuong.Text);
            h.ThanhTien1 = int.Parse(txtThanhTien.Text);
            // Thực hiện thêm
            if (BUS_CTHDX.CapNhatCTHDX(h) == false)
            {
                MessageBox.Show("Không sửa được.");
                return;
            }
            HienThiLenDataGrid();
            MessageBox.Show("Đã sửa.");
        }
        public DTO_TaiKhoan TaiKhoan;
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int quyen;
            if (TaiKhoan == null)
                quyen = 0;
            else
                quyen = TaiKhoan.IQuyen;
            switch (quyen) {
                case 1:
                    // Kiểm tra mã có tồn tại không
                    if (BUS_CTHDX.TimTheoMa(txtIDX.Text) == null)
                    {
                        MessageBox.Show("Mã không tồn tại!");
                        return;
                    }
                    // Gán dữ liệu vào kiểu DTO_CTHDXUAT
                    DTO_CTHDXUAT x = new DTO_CTHDXUAT();
                    x.IDXUAT1 = int.Parse(txtIDX.Text);

                    // Thực hiện xóa 
                    if (BUS_CTHDX.XoaCTHDX(x) == false)
                    {
                        MessageBox.Show("Không xóa được.");
                        return;
                    }
                    HienThiLenDataGrid();
                    MessageBox.Show("Đã xóa.");
                    break;
                case 2:
                    btnXoa.Enabled = false;
                    break;
        }
    }
        private void ExportToExcel(DataGridView g, string duongdan, string tentaptin)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for (int i = 1; i < g.Columns.Count + 1; i++)
            {
                obj.Cells[1, i] = g.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < g.Rows.Count; i++)
            {
                for (int j = 0; j < g.Columns.Count; j++)
                {
                    if (g.Rows[i].Cells[j].Value != null)
                        obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString();
                }
            }
            obj.ActiveWorkbook.SaveCopyAs(duongdan + tentaptin + ".xlsx");
            obj.ActiveWorkbook.Saved = true;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgDSCTHDX, @"D:\LTQL\", "CTHDX");
            MessageBox.Show("Đã xuất file Excel thành công");
        }

        
        private void btnInPX_Click(object sender, EventArgs e)
        {
            frmPhieuXuat f = new frmPhieuXuat(cbKH1.Text, txtDiaChi.Text, txtSDT.Text, cbHH4.Text, dtpNgayLap.Text,int.Parse(txtSoLuong.Text), int.Parse(txtThanhTien.Text), txtTenNV.Text, txtTenNV.Text);
            this.Hide();
            f.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMain f = new frmMain();
            this.Hide();
            f.Show();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            int sl = int.Parse(txtSoLuong.Text);
            int dg = int.Parse(txtDonGia.Text);
            int tong = sl * dg;
            txtThanhTien.Text = tong.ToString();
        }

        public void ColorDataGrid()
        {
            dgDSCTHDX.BorderStyle = BorderStyle.None;
            dgDSCTHDX.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgDSCTHDX.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgDSCTHDX.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgDSCTHDX.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgDSCTHDX.BackgroundColor = Color.White;

            dgDSCTHDX.EnableHeadersVisualStyles = false;
            dgDSCTHDX.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgDSCTHDX.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgDSCTHDX.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void frmCTHDXuat_Load(object sender, EventArgs e)
        {
            HienThiLenDataGrid();
            ColorDataGrid();
            HienThiLenComboBox();
            HienThiLenComboBox1();
            HienThiLenComBox2();
            HienThiLenComBox3();
            HienThiLenComBox4();
            HienThiLenComBox5();
            HienThiLenComBox6();
            txtSoHD.Text = this.SoHD;
            cbKH.Text = this.KhachHang;
            cbKH1.Text = this.KhachHang1;
            dtpNgayLap.Text = this.NgayLap;
            txtTenNV.Text = this.NhanVien;
        }
    }
}
