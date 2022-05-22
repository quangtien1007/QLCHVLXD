using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QuanLiVLXD
{
    public partial class frmNhapHang : Form
    {
        public frmNhapHang()
        {
            InitializeComponent();
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            HienThiMatHangLenDataGrid();
            dgDSMH.BorderStyle = BorderStyle.None;
            dgDSMH.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgDSMH.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgDSMH.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgDSMH.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgDSMH.BackgroundColor = Color.White;

            dgDSMH.EnableHeadersVisualStyles = false;
            dgDSMH.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgDSMH.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgDSMH.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            SetHeaderText();
        }
        public void SetHeaderText()
        {
            dgDSMH.Columns["SMaPN"].HeaderText = "Mã phiếu nhập";
            dgDSMH.Columns["SMaNV"].HeaderText = "Mã nhân viên";
            dgDSMH.Columns["SMaMH"].HeaderText = "Mã mặt hàng";
            dgDSMH.Columns["STenMH"].HeaderText = "Tên mặt hàng";
            dgDSMH.Columns["SMaLoaiMH"].HeaderText = "Mã loại mặt hàng";
            dgDSMH.Columns["SDonGia"].HeaderText = "Đơn giá";
            dgDSMH.Columns["SMaNSX"].HeaderText = "Nhà sản xuất";
            dgDSMH.Columns["SSoLuong"].HeaderText = "Số lượng";
            dgDSMH.Columns["SNgayNhap"].HeaderText = "Ngày nhập";
            dgDSMH.Columns["STinhTrang"].HeaderText = "Tình trạng";
            dgDSMH.Columns["SGhiChu"].HeaderText = "Ghi chú";
        }
        private void HienThiMatHangLenDataGrid()
        {
            List<DTO_MatHang> lstMatHang = BUS_MatHang.LayMatHang();
            dgDSMH.DataSource = lstMatHang;
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgDSMH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtMaPhieuNhap.Text = dgDSMH.Rows[i].Cells["SMaPN"].Value.ToString();
            txtMaNV.Text = dgDSMH.Rows[i].Cells["SMaNV"].Value.ToString();
            txtMaMH.Text = dgDSMH.Rows[i].Cells["SMaMH"].Value.ToString();
            txtTenMH.Text = dgDSMH.Rows[i].Cells["STenMH"].Value.ToString();
            txtMaLoaiMH.Text = dgDSMH.Rows[i].Cells["SMaLoaiMH"].Value.ToString();
            txtDonGia.Text = dgDSMH.Rows[i].Cells["SDonGia"].Value.ToString();
            txtNSX.Text = dgDSMH.Rows[i].Cells["SMaNSX"].Value.ToString();
            txtSoLuong.Text = dgDSMH.Rows[i].Cells["SSoLuong"].Value.ToString();
            dtpNgayNhap.Text = dgDSMH.Rows[i].Cells["SNgayNhap"].Value.ToString();
            txtTinhTrang.Text = dgDSMH.Rows[i].Cells["STinhTrang"].Value.ToString();
            txtGhiChu.Text = dgDSMH.Rows[i].Cells["SGhiChu"].Value.ToString();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtTinhTrang_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {

        }
    }
}
