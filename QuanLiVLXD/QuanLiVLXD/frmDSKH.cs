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
using DAO;

namespace QuanLiVLXD
{
    public partial class frmDSKH : Form
    {
        public frmDSKH()
        {
            InitializeComponent();
        }
        public void SetHeaderText()
        {
            dgDSKH.Columns["MaKH1"].HeaderText = "Mã khách hàng";
            dgDSKH.Columns["MaKH1"].Width = 350;
            dgDSKH.Columns["TenKH1"].HeaderText = "Tên khách hàng";
            dgDSKH.Columns["TenKH1"].Width = 400;
            dgDSKH.Columns["DiaChi1"].HeaderText = "Địa chỉ";
            dgDSKH.Columns["DiaChi1"].Width = 400;
            dgDSKH.Columns["SDT1"].HeaderText = "Số điện thoại";
            dgDSKH.Columns["SDT1"].Width = 340;
        }
        public void ColorDataGrid()
        {
            dgDSKH.BorderStyle = BorderStyle.None;
            dgDSKH.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgDSKH.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgDSKH.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgDSKH.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgDSKH.BackgroundColor = Color.White;

            dgDSKH.EnableHeadersVisualStyles = false;
            dgDSKH.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgDSKH.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgDSKH.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        private void HienThiLenDataGrid()
        {
            List<DTO_KhachHang> lstKhachHang = BUS_KhachHang.LayKH();
            dgDSKH.DataSource = lstKhachHang;
        }

        private void frmDSKH_Load(object sender, EventArgs e)
        {
            HienThiLenDataGrid();
            ColorDataGrid();
            SetHeaderText();
        }
    }
}
