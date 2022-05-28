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

namespace QuanLiVLXD
{
    public partial class frmCTHDXuat : Form
    {
        private string SoHD, KhachHang,KhachHang1,NhanVien,NgayLap;
        public frmCTHDXuat()
        {
            InitializeComponent();
        }
        public frmCTHDXuat(string SoHD,string KhachHang,string KhachHang1, string NgayLap,string NhanVien)
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
        private void btnThem_Click(object sender, EventArgs e)
        {

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
            txtSoHD.Text = this.SoHD;
            cbKH.Text = this.KhachHang;
            cbKH1.Text = this.KhachHang1;
            dtpNgayLap.Text = this.NgayLap;
            txtTenNV.Text = this.NhanVien;
        }
    }
}
