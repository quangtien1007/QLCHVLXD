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
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

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
            ExportToExcel(dgDSLH, @"D:\LTQL\", "ThongKeLoaiHang");
            MessageBox.Show("Đã xuất file Excel thành công ");
        }
    }
}
