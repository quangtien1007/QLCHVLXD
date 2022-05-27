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
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

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
        private void ExportToExcel(DataGridView g, string duongdan, string tentaptin)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for (int i = 1; i < g.Columns.Count + 1; i++)
            {
                obj.Cells[1, i] = g.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < g.Rows.Count; i++)
            {
                for (int j = 0; j < g.Columns.Count; j++)
                {
                    if (g.Rows[i].Cells[j].Value != null)
                        obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString();
                }
            }
            obj.ActiveWorkbook.SaveCopyAs(duongdan + tentaptin + ".xlsx");
            obj.ActiveWorkbook.Saved = true;
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgBCXH, @"D:\LTQL\", "BaoCaoXuatHang");
            MessageBox.Show("Đã xuất file Excel thành công ");
        }
    }
}
