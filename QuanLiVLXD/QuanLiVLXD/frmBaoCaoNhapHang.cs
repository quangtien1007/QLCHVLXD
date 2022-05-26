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
    public partial class frmBaoCaoNhapHang : Form
    {
        public frmBaoCaoNhapHang()
        {
            InitializeComponent();
        }
        public void SetHeaderText()
        {
            dgBCNH.Columns["TenNCC1"].HeaderText = "Tên nhà cung cấp";
            dgBCNH.Columns["TenNCC1"].Width = 250;
            dgBCNH.Columns["TenHH1"].HeaderText = "Tên hàng hóa";
            dgBCNH.Columns["TenHH1"].Width = 250;
            dgBCNH.Columns["DVT1"].HeaderText = "Đơn vị tính";
            dgBCNH.Columns["DVT1"].Width = 200;
            dgBCNH.Columns["SoLuong1"].HeaderText = "Số lượng";
            dgBCNH.Columns["SoLuong1"].Width = 200;
            dgBCNH.Columns["DonGia1"].HeaderText = "Đơn giá";
            dgBCNH.Columns["DonGia1"].Width = 200;
            dgBCNH.Columns["NgayNhap1"].HeaderText = "Ngày nhập";
            dgBCNH.Columns["NgayNhap1"].Width = 290;
        }
        public void ColorDataGrid()
        {
            dgBCNH.BorderStyle = BorderStyle.None;
            dgBCNH.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgBCNH.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgBCNH.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgBCNH.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgBCNH.BackgroundColor = Color.White;

            dgBCNH.EnableHeadersVisualStyles = false;
            dgBCNH.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgBCNH.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgBCNH.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        private void HienThiLenDataGrid()
        {
            List<DTO_BCNhap> lstBCN = BUS_BCNhap.LayBCN();
            dgBCNH.DataSource = lstBCN;
        }
        private void frmBaoCaoNhapHang_Load(object sender, EventArgs e)
        {
            HienThiLenDataGrid();
            ColorDataGrid();
            SetHeaderText();
        }

    }
}
