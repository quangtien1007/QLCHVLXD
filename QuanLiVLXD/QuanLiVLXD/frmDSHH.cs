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
    public partial class frmDSHH : Form
    {
        public frmDSHH()
        {
            InitializeComponent();
        }
        public void ColorDataGrid()
        {
            dgDSHH.BorderStyle = BorderStyle.None;
            dgDSHH.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgDSHH.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgDSHH.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgDSHH.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgDSHH.BackgroundColor = Color.White;

            dgDSHH.EnableHeadersVisualStyles = false;
            dgDSHH.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgDSHH.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgDSHH.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        public void SetHeaderText()
        {
            dgDSHH.Columns["MaHH1"].HeaderText = "Mã hàng hóa";
            dgDSHH.Columns["MaHH1"].Width = 300;
            dgDSHH.Columns["MaLoai1"].HeaderText = "Mã loại";
            dgDSHH.Columns["MaLoai1"].Width = 290;
            dgDSHH.Columns["TenHH1"].HeaderText = "Tên hàng hóa";
            dgDSHH.Columns["TenHH1"].Width = 300;
            dgDSHH.Columns["DVT1"].HeaderText = "Đơn vị tính";
            dgDSHH.Columns["DVT1"].Width = 300;
            dgDSHH.Columns["XuatXu1"].HeaderText = "Xuất xứ";
            dgDSHH.Columns["XuatXu1"].Width = 300;
        }
        private void HienThiLenDataGrid()
        {
            List<DTO_HangHoa> lstHangHoa = BUS_HangHoa.LayHH();
            dgDSHH.DataSource = lstHangHoa;
        }

        private void frmDSHH_Load(object sender, EventArgs e)
        {
            HienThiLenDataGrid();
            SetHeaderText();
            ColorDataGrid();
        }
    }
}
