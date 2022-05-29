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
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

namespace QuanLiVLXD
{
    public partial class frmCTHDNhap : Form
    {
        public frmCTHDNhap()
        {
            InitializeComponent();
        }
        private string SoHD, NCC, NhanVien, NgayLap;
        public frmCTHDNhap(string SoHD, string NCC, string NgayLap, string NhanVien)
        {
            InitializeComponent();
            this.SoHD = SoHD;
            this.NCC = NCC;
            this.NgayLap = NgayLap;
            this.NhanVien = NhanVien;
        }
        private void HienThiLenDataGrid()
        {
            List<DTO_CTHDN> lstCTHDN = BUS_CTHDN.LayCTHDN();
            dgDSCTHDN.DataSource = lstCTHDN;
        }
        public void ColorDataGrid()
        {
            dgDSCTHDN.BorderStyle = BorderStyle.None;
            dgDSCTHDN.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgDSCTHDN.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgDSCTHDN.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgDSCTHDN.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgDSCTHDN.BackgroundColor = Color.White;

            dgDSCTHDN.EnableHeadersVisualStyles = false;
            dgDSCTHDN.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgDSCTHDN.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgDSCTHDN.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
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
        private void HienThiLenComboBox()
        {
            List<DTO_Kho> lstHH = BUS_Kho.LayKho();
            cbHH.DataSource = lstHH;
            cbHH.DisplayMember = "MaHH1";
            cbHH.ValueMember = "IDKho1";
        }
        private void HienThiLenComboBox1()
        {
            List<DTO_DonGia> lstDG = BUS_DonGia.LayDG();
            cbHH1.DataSource = lstDG;
            cbHH1.DisplayMember = "TenHH1";
            cbHH1.ValueMember = "DonGia1";
        }
        private void HienThiLenComboBox2()
        {
            List<DTO_HangHoa> lstHH = BUS_HangHoa.LayHH();
            cbHH2.DataSource = lstHH;
            cbHH2.DisplayMember = "TenHH1";
            cbHH2.ValueMember = "DVT1";
        }
        private void HienThiLenComboBox3()
        {
            List<DTO_HangHoa> lstHH = BUS_HangHoa.LayHH();
            cbHH3.DataSource = lstHH;
            cbHH3.DisplayMember = "TenHH1";
            cbHH3.ValueMember = "MaHH1";
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void frmCTHDNhap_Load(object sender, EventArgs e)
        {
            HienThiLenDataGrid();
            ColorDataGrid();
            HienThiLenComboBox();
            HienThiLenComboBox1();
            HienThiLenComboBox2();
            HienThiLenComboBox3();
            txtSoHD.Text = this.SoHD;
            txtNCC.Text = this.NCC;
            dtpNgayLap.Text = this.NgayLap;
            txtNV.Text = this.NhanVien;
            SetHeaderText();
        }

        private void cbHH1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDonGia.Text = cbHH1.SelectedValue.ToString();
        }

        private void cbHH2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDVT.Text = cbHH2.SelectedValue.ToString();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            int sl = int.Parse(txtSoLuong.Text);
            int dg = int.Parse(txtDonGia.Text);
            int tong = sl * dg;
            txtThanhTien.Text = tong.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMain f = new frmMain();
            f.Show();
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtIDKho.Text == "" || txtIDN.Text == "" || txtDonGia.Text == "" || txtSoHD.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã loại hàng có độ dài chuỗi hợp lệ hay không
            if (txtIDN.Text.Length > 3)
            {
                MessageBox.Show("Mã loại hàng tối đa 3 ký tự!");
                return;
            }
            // Kiểm tra mã khách hàng có bị trùng không
            if (BUS_CTHDN.TimTheoMa(txtIDN.Text) != null)
            {
                MessageBox.Show("Mã đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu DTO_KhachHang
            DTO_CTHDN h = new DTO_CTHDN();
            h.ID1 = int.Parse(txtIDN.Text);
            h.IDKho1 = int.Parse(txtIDKho.Text);
            h.MaHH1 = txtMaHH.Text;
            h.SoHDN1 = txtSoHD.Text;
            h.SoLuong1 = int.Parse(txtSoLuong.Text);
            h.ThanhTien1 = int.Parse(txtThanhTien.Text);
            DTO_Kho k = new DTO_Kho();
            k.SoLuongKho1 = int.Parse(txtSoLuong.Text);
            k.MaHH1 = txtMaHH.Text;
            // Thực hiện thêm
            if (BUS_CTHDN.ThemCTHDN(h) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            if (BUS_Kho.nhapkho(k) == false)
            {
                MessageBox.Show("Không update được.");
                return;
            }
            HienThiLenDataGrid();
            MessageBox.Show("Đã thêm.");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtIDKho.Text == "" || txtIDN.Text == "" || txtDonGia.Text == "" || txtSoHD.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã có bị trùng không
            if (BUS_CTHDN.TimTheoMa(txtIDN.Text) == null)
            {
                MessageBox.Show("Mã không tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu DTO_KhachHang
            DTO_CTHDN h = new DTO_CTHDN();
            h.ID1 = int.Parse(txtIDN.Text);
            h.IDKho1 = int.Parse(txtIDKho.Text);
            h.MaHH1 = txtMaHH.Text;
            h.SoHDN1 = txtSoHD.Text;
            h.SoLuong1 = int.Parse(txtSoLuong.Text);
            h.ThanhTien1 = int.Parse(txtThanhTien.Text);
            // Thực hiện thêm
            if (BUS_CTHDN.CapNhatCTHDN(h) == false)
            {
                MessageBox.Show("Không sửa được.");
                return;
            }
            HienThiLenDataGrid();
            MessageBox.Show("Đã sửa.");
        }
        private DTO_TaiKhoan TaiKhoan;
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
                    if (BUS_CTHDN.TimTheoMa(txtIDN.Text) == null)
                    {
                        MessageBox.Show("Mã không tồn tại!");
                        return;
                    }
                    // Gán dữ liệu vào kiểu DTO_CTHDN
                    DTO_CTHDN x = new DTO_CTHDN();
                    x.ID1 = int.Parse(txtIDN.Text);

                    // Thực hiện xóa 
                    if (BUS_CTHDN.XoaCTHDN(x) == false)
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
        

        private void btnIn_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgDSCTHDN, @"D:\LTQL\", "CTHDN");
            MessageBox.Show("Đã xuất file Excel thành công");
        }

        private void btnInPN_Click(object sender, EventArgs e)
        {
            frmPhieuNhap f = new frmPhieuNhap(txtNCC.Text, cbHH1.Text, dtpNgayLap.Text, int.Parse(txtSoLuong.Text), int.Parse(txtThanhTien.Text), txtNV.Text, txtNV.Text);
            this.Hide();
            f.Show();
        }

        private void dgDSCTHDN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            cbHH1.Text = dgDSCTHDN.Rows[i].Cells["TenHH1"].Value.ToString();
            txtSoLuong.Text = dgDSCTHDN.Rows[i].Cells["SoLuong1"].Value.ToString();
            txtDVT.Text = dgDSCTHDN.Rows[i].Cells["DVT1"].Value.ToString();
            txtDonGia.Text = dgDSCTHDN.Rows[i].Cells["DonGia1"].Value.ToString();
            txtMaHH.Text = dgDSCTHDN.Rows[i].Cells["MaHH1"].Value.ToString();
            txtDVT.Text = dgDSCTHDN.Rows[i].Cells["DVT1"].Value.ToString();
            txtThanhTien.Text = dgDSCTHDN.Rows[i].Cells["ThanhTien1"].Value.ToString();
        }
        public void SetHeaderText()
        {
            dgDSCTHDN.Columns["ID1"].HeaderText = "ID";
            dgDSCTHDN.Columns["MaHH1"].HeaderText = "Mã HH";
            dgDSCTHDN.Columns["TenHH1"].HeaderText = "Tên HH";
            dgDSCTHDN.Columns["SoHDN1"].HeaderText ="Số HĐ";
            dgDSCTHDN.Columns["SoLuong1"].HeaderText = "Số lượng";
            dgDSCTHDN.Columns["ThanhTien1"].HeaderText = "Thành tiền";
            dgDSCTHDN.Columns["IDKho1"].HeaderText = "ID Kho";
            dgDSCTHDN.Columns["TenNCC1"].HeaderText = "Tên NCC";
            dgDSCTHDN.Columns["NgayLap1"].HeaderText = "Ngày lập";
            dgDSCTHDN.Columns["TenNV1"].HeaderText = "Tên NV";
            dgDSCTHDN.Columns["DonGia1"].HeaderText = "Đơn giá";
            dgDSCTHDN.Columns["DVT1"].HeaderText = "ĐVT";
        }
        private void cbHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIDKho.Text = cbHH.SelectedValue.ToString();
        }

        private void cbHH1_TextChanged(object sender, EventArgs e)
        {
            cbHH2.Text = cbHH1.Text;
            cbHH3.Text = cbHH1.Text;
        }

        private void cbHH3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbHH.Text = cbHH3.SelectedValue.ToString();
            txtMaHH.Text = cbHH3.SelectedValue.ToString();
        }
    }
}
