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
    public partial class frmDSNCC : Form
    {
        public frmDSNCC()
        {
            InitializeComponent();
        }

        private void frmDSNCC_Load(object sender, EventArgs e)
        {
            HienThiLenDataGrid();
            SetHeaderText();
            ColorDataGrid();
        }
        private void HienThiLenDataGrid()
        {
            List<DTO_NCC> lstNCC = BUS_NCC.LayNCC();
            dgDSNCC.DataSource = lstNCC;
        }
        public void ColorDataGrid()
        {
            dgDSNCC.BorderStyle = BorderStyle.None;
            dgDSNCC.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgDSNCC.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgDSNCC.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgDSNCC.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgDSNCC.BackgroundColor = Color.White;

            dgDSNCC.EnableHeadersVisualStyles = false;
            dgDSNCC.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgDSNCC.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgDSNCC.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        public void SetHeaderText()
        {
            dgDSNCC.Columns["MaNCC1"].HeaderText = "Mã Nhà cung cấp";
            dgDSNCC.Columns["MaNCC1"].Width = 350;
            dgDSNCC.Columns["TenNCC1"].HeaderText = "Tên nhà cung cấp";
            dgDSNCC.Columns["TenNCC1"].Width = 400;
            dgDSNCC.Columns["DiaChi1"].HeaderText = "Địa chỉ";
            dgDSNCC.Columns["DiaChi1"].Width = 400;
            dgDSNCC.Columns["SDT1"].HeaderText = "Số điện thoại";
            dgDSNCC.Columns["SDT1"].Width = 340;
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
            ExportToExcel(dgDSNCC, @"D:\LTQL\", "ThongKeNhaCungCap");
            MessageBox.Show("Đã xuất file Excel thành công ");
        }
    }
}
