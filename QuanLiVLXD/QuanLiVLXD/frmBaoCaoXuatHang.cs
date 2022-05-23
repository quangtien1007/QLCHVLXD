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
    public partial class frmBaoCaoXuatHang : Form
    {
        public frmBaoCaoXuatHang()
        {
            InitializeComponent();
        }
        public void SetHeaderText()
        {
            dgBCXH.Columns["MaHH1"].HeaderText = "Mã hàng hàng";
            dgBCXH.Columns["MaHH1"].Width = 300;
            dgBCXH.Columns["TenHH1"].HeaderText = "Tên hàng hóa";
            dgBCXH.Columns["TenHH1"].Width = 300;
            dgBCXH.Columns["DVT1"].HeaderText = "Đơn vị tính";
            dgBCXH.Columns["DVT1"].Width = 300;
            dgBCXH.Columns["SoLuongXuat1"].HeaderText = "Số lượng";
            dgBCXH.Columns["SoLuongXuat1"].Width = 250;
            dgBCXH.Columns["DonGia1"].HeaderText = "Đơn giá";
            dgBCXH.Columns["DonGia1"].Width = 340;
        }
        public void ColorDataGrid()
        {
            dgBCXH.BorderStyle = BorderStyle.None;
            dgBCXH.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgBCXH.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgBCXH.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgBCXH.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgBCXH.BackgroundColor = Color.White;

            dgBCXH.EnableHeadersVisualStyles = false;
            dgBCXH.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgBCXH.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgBCXH.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        private void HienThiLenDataGrid()
        {
            List<DTO_BCXuat> lstBCX = BUS_BCXuat.LayBCX();
            dgBCXH.DataSource = lstBCX;
        }

        private void frmBaoCaoXuatHang_Load(object sender, EventArgs e)
        {
            HienThiLenDataGrid();
            ColorDataGrid();
            SetHeaderText();
        }
    }
}
