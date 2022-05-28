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
        private string SoHD, NCC, NhanVien , NgayLap;
        public frmCTHDNhap(string SoHD, string NCC, string NgayLap, string NhanVien)
        {
            InitializeComponent();
            this.SoHD = SoHD;
            this.NCC = NCC;
            this.NgayLap = NgayLap;
            this.NhanVien = NhanVien;
        }
        private void HienThiLenDataGrid()
        {
            List<DTO_CTHDN> lstCTHDN = BUS_CTHDN.LayCTHDN();
            dgDSCTHDN.DataSource = lstCTHDN;
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
        private void HienThiLenComboBox()
        {
            List<DTO_Kho> lstHH = BUS_Kho.LayKho();
            cbHH.DataSource = lstHH;
            cbHH.DisplayMember = "MaHH1";
            cbHH.ValueMember = "IDKho1";
        }
        private void HienThiLenComboBox1()
        {
            List<DTO_DonGia> lstDG = BUS_DonGia.LayDG();
            cbHH1.DataSource = lstDG;
            cbHH1.DisplayMember = "TenHH1";
            cbHH1.ValueMember = "DonGia1";
        }
        private void HienThiLenComboBox2()
        {
            List<DTO_HangHoa> lstHH = BUS_HangHoa.LayHH();
            cbHH2.DataSource = lstHH;
            cbHH2.DisplayMember = "TenHH1";
            cbHH2.ValueMember = "DVT1";
        }
        private void HienThiLenComboBox3()
        {
            List<DTO_HangHoa> lstHH = BUS_HangHoa.LayHH();
            cbHH3.DataSource = lstHH;
            cbHH3.DisplayMember = "TenHH1";
            cbHH3.ValueMember = "MaHH1";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgDSCTHDN, @"D:\LTQL\", "ThongKeKhachHang");
            MessageBox.Show("Đã xuất file Excel thành công ");
        }

        private void frmCTHDNhap_Load(object sender, EventArgs e)
        {
            HienThiLenDataGrid();
            ColorDataGrid();
            HienThiLenComboBox();
            HienThiLenComboBox1();
            HienThiLenComboBox2();
            HienThiLenComboBox3();
            txtSoHD.Text = this.SoHD;
            txtNCC.Text = this.NCC;
            dtpNgayLap.Text = this.NgayLap;
            txtNV.Text = this.NhanVien;
        }

        private void cbHH1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDonGia.Text = cbHH1.SelectedValue.ToString();
        }

        private void cbHH2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDVT.Text = cbHH2.SelectedValue.ToString();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            int sl = int.Parse(txtSoLuong.Text);
            int dg = int.Parse(txtDonGia.Text);
            int tong = sl * dg;
            txtThanhTien.Text = tong.ToString();
        }

        private void cbHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIDN.Text = cbHH.SelectedValue.ToString();
        }

        private void cbHH1_TextChanged(object sender, EventArgs e)
        {
            cbHH2.Text = cbHH1.Text;
            cbHH3.Text = cbHH1.Text;
        }

        private void cbHH3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbHH.Text = cbHH3.SelectedValue.ToString();
        }
    }
}
