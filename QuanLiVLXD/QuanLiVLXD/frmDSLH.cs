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
    public partial class frmDSLH : Form
    {
        public frmDSLH()
        {
            InitializeComponent();
        }
        public void SetHeaderText()
        {
            dgDSLH.Columns["MaLoai1"].HeaderText = "Mã loại hàng";
            dgDSLH.Columns["MaLoai1"].Width = 350;
            dgDSLH.Columns["TenLoai1"].HeaderText = "Tên loại hàng";
            dgDSLH.Columns["TenLoai1"].Width = 400;
            dgDSLH.Columns["DienGiai1"].HeaderText = "Diễn giải";
            dgDSLH.Columns["DienGiai1"].Width = 400;
            dgDSLH.Columns["TrangThai1"].HeaderText = "Trạng thái";
            dgDSLH.Columns["TrangThai1"].Width = 340;
        }
        public void ColorDataGrid()
        {
            dgDSLH.BorderStyle = BorderStyle.None;
            dgDSLH.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgDSLH.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgDSLH.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgDSLH.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgDSLH.BackgroundColor = Color.White;

            dgDSLH.EnableHeadersVisualStyles = false;
            dgDSLH.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgDSLH.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgDSLH.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        private void HienThiLenDataGrid()
        {
            List<DTO_LoaiHang> lstLoaiHang = BUS_LoaiHang.LayLH();
            dgDSLH.DataSource = lstLoaiHang;
        }

        private void frmDSLH_Load(object sender, EventArgs e)
        {
            HienThiLenDataGrid();
            SetHeaderText();
            ColorDataGrid();
        }
    }
}
