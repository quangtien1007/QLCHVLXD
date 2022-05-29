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
    public partial class frmPhieuXuat : Form
    {
        private string TenKH, DiaChi, SDT, TenHH,NgayLap,TenNV,TenNV1;

        private void cbNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTenNV.Text = cbNV.SelectedValue.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMain f = new frmMain();
            this.Hide();
            f.Show();
        }

        private void frmPhieuXuat_Load(object sender, EventArgs e)
        {
            HienThiLenComboBox();
            lblTenKH.Text= this.TenKH;
            lblDiaChi.Text= this.DiaChi;
            lblSDT.Text= this.SDT;
            lblTenHH.Text= this.TenHH ;
            lblNgayLap.Text = this.NgayLap;
            lblSoLuong.Text= this.SoLuong.ToString();
            lblThanhTien.Text = this.ThanhTien.ToString();
            lblTenNV1.Text = this.TenNV;
            cbNV.Text = this.TenNV1;
        }

        private int SoLuong,ThanhTien;
        public frmPhieuXuat()
        {
            InitializeComponent();
        }
        public void HienThiLenComboBox()
        {
            List<DTO_NhanVien> lstNV = BUS_NhanVien.LayNV();
            cbNV.DataSource = lstNV;
            cbNV.DisplayMember = "MaNV1";
            cbNV.ValueMember = "TenNV1";
        }
        public frmPhieuXuat(string TenKH, string DiaChi, string SDT, string TenHH, string NgayLap,int SoLuong ,int ThanhTien,string TenNV,string TenNV1)
        {
            InitializeComponent();
            this.TenKH = TenKH;
            this.DiaChi = DiaChi;
            this.SDT = SDT;
            this.TenHH = TenHH;
            this.NgayLap = NgayLap;
            this.SoLuong = SoLuong;
            this.ThanhTien = ThanhTien;
            this.TenNV = TenNV;
            this.TenNV1 = TenNV1;
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
