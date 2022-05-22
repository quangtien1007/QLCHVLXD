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
        public frmCTHDXuat()
        {
            InitializeComponent();
        }
        private void HienThiLenDataGrid()
        {
            List<DTO_CTHDXUAT> lstCTHDX = BUS_CTHDX.LayCTHDXuat();
            dgDSCTHDX.DataSource = lstCTHDX;
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
        }
    }
}
