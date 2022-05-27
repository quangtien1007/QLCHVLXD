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
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

namespace QuanLiVLXD
{
    public partial class frmBaoCaoKho : Form
    {
        public frmBaoCaoKho()
        {
            InitializeComponent();
        }
        private void ExportToExcel(DataGridView g,string duongdan,string tentaptin)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for(int i = 1; i < g.Columns.Count + 1;i++)
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
        public void SetHeaderText()
        {
            dgKho.Columns["TenHang1"].HeaderText = "Tên hàng hóa";
            dgKho.Columns["TenHang1"].Width = 300;
            dgKho.Columns["DVT1"].HeaderText = "Đơn vị tính";
            dgKho.Columns["DVT1"].Width = 350;
            dgKho.Columns["SoLuongKho1"].HeaderText = "Số lượng";
            dgKho.Columns["SoLuongKho1"].Width = 350;
            dgKho.Columns["MaLoai1"].HeaderText = "Mã loại";
            dgKho.Columns["MaLoai1"].Width = 190;
            dgKho.Columns["XuatXu1"].HeaderText = "Xuất xứ";
            dgKho.Columns["XuatXu1"].Width = 300;
        }
        private void HienThiLenDataGrid()
        {
            List<DTO_Kho> lstKho = BUS_Kho.LayKho();
            dgKho.DataSource = lstKho;
        }
        public void ColorDataGrid()
        {
            dgKho.BorderStyle = BorderStyle.None;
            dgKho.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgKho.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgKho.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgKho.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgKho.BackgroundColor = Color.White;

            dgKho.EnableHeadersVisualStyles = false;
            dgKho.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgKho.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgKho.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void frmBaoCaoKho_Load(object sender, EventArgs e)
        {
            HienThiLenDataGrid();
            ColorDataGrid();
            SetHeaderText();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgKho, @"D:\LTQL\","BaoCaoKho" );
            MessageBox.Show("Đã xuất file Excel thành công");
        }
    }
}
