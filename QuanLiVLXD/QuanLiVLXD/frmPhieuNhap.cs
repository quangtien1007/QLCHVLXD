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
    public partial class frmPhieuNhap : Form
    {
        public frmPhieuNhap()
        {
            InitializeComponent();
        }
        private string TenNCC, TenHH, NgayLap, TenNV, TenNV1;

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

        private int SoLuong, ThanhTien;
        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            HienThiLenComboBox();
            lblTenNCC.Text = this.TenNCC;
            lblTenHH.Text = this.TenHH;
            lblNgayLap.Text = this.NgayLap;
            lblSoLuong.Text = this.SoLuong.ToString();
            lblThanhTien.Text = this.ThanhTien.ToString();
            lblTenNV1.Text = this.TenNV;
            cbNV.Text = this.TenNV1;
        }
        public frmPhieuNhap(string TenNCC,string TenHH, string NgayLap, int SoLuong, int ThanhTien, string TenNV, string TenNV1)
        {
            InitializeComponent();
            this.TenNCC = TenNCC;
            this.TenHH = TenHH;
            this.NgayLap = NgayLap;
            this.SoLuong = SoLuong;
            this.ThanhTien = ThanhTien;
            this.TenNV = TenNV;
            this.TenNV1 = TenNV1;
        }
        public void HienThiLenComboBox()
        {
            List<DTO_NhanVien> lstNV = BUS_NhanVien.LayNV();
            cbNV.DataSource = lstNV;
            cbNV.DisplayMember = "MaNV1";
            cbNV.ValueMember = "TenNV1";
        }
    }
}
