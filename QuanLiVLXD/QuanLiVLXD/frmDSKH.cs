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
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

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
            ExportToExcel(dgDSKH, @"D:\LTQL\", "ThongKeKhachHang");
            MessageBox.Show("Đã xuất file Excel thành công ");
        }
    }
}
