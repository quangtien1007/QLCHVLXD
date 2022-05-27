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
    public partial class frmCTHDNhap : Form
    {
        public frmCTHDNhap()
        {
            InitializeComponent();
        }
        private void HienThiLenDataGrid()
        {
            List<DTO_CTHDXUAT> lstCTHDX = BUS_CTHDX.LayCTHDXuat();
            dgDSCTHDN.DataSource = lstCTHDX;
        }
        public void ColorDataGrid()
        {
            dgDSCTHDN.BorderStyle = BorderStyle.None;
            dgDSCTHDN.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgDSCTHDN.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgDSCTHDN.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgDSCTHDN.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgDSCTHDN.BackgroundColor = Color.White;

            dgDSCTHDN.EnableHeadersVisualStyles = false;
            dgDSCTHDN.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgDSCTHDN.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgDSCTHDN.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
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
        private void button1_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgDSCTHDN, @"D:\LTQL\", "ThongKeKhachHang");
            MessageBox.Show("Đã xuất file Excel thành công ");
        }
    }
}
