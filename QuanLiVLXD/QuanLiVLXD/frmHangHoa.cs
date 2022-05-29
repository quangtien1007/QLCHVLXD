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

namespace QuanLiVLXD
{
    public partial class frmHangHoa : Form
    {
        public frmHangHoa()
        {
            InitializeComponent();
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
        private void HienThiLenCombobox()
        {
            List<DTO_LoaiHang> lstHangHoa = BUS_LoaiHang.LayLH();
            cbMaLoai.DataSource = lstHangHoa;
            cbMaLoai.DisplayMember = "MaLoai1";
            cbMaLoai.ValueMember = "MaLoai1";
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

        private void dgDSHH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtMaHH.Text = dgDSHH.Rows[i].Cells["MaHH1"].Value.ToString();
            cbMaLoai.Text = dgDSHH.Rows[i].Cells["MaLoai1"].Value.ToString();
            txtTenHH.Text = dgDSHH.Rows[i].Cells["TenHH1"].Value.ToString();
            txtDVT.Text = dgDSHH.Rows[i].Cells["DVT1"].Value.ToString();
            txtXuatXu.Text = dgDSHH.Rows[i].Cells["XuatXu1"].Value.ToString();
        }

        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            HienThiLenCombobox();
            HienThiLenDataGrid();
            SetHeaderText();
            ColorDataGrid();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaHH.Text == "" || cbMaLoai.Text == "" || txtTenHH.Text == "" || txtDVT.Text == "" || txtXuatXu.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã hàng hóa có độ dài chuỗi hợp lệ hay không
            if (txtMaHH.Text.Length > 5)
            {
                MessageBox.Show("Mã hàng hóa tối đa 5 ký tự!");
                return;
            }
            // Kiểm tra mã hàng hóa có bị trùng không
            if (BUS_HangHoa.TimHangHoaTheoMa(txtMaHH.Text) != null)
            {
                MessageBox.Show("Mã hàng hóa đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu DTO_HangHoa
            DTO_HangHoa hh = new DTO_HangHoa();
            hh.MaHH1 = txtMaHH.Text;
            hh.MaLoai1 = cbMaLoai.SelectedValue.ToString();
            hh.TenHH1 = txtTenHH.Text;
            hh.DVT1 = txtDVT.Text;
            hh.XuatXu1 = txtXuatXu.Text;
            // Thực hiện thêm
            if (BUS_HangHoa.ThemHangHoa(hh) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            HienThiLenDataGrid();
            MessageBox.Show("Đã thêm nhân viên.");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaHH.Text == "" || cbMaLoai.Text == "" || txtTenHH.Text == "" || txtDVT.Text == "" || txtXuatXu.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã hàng hóa có độ dài chuỗi hợp lệ hay không
            if (txtMaHH.Text.Length > 5)
            {
                MessageBox.Show("Mã hàng hóa tối đa 5 ký tự!");
                return;
            }
            // Kiểm tra mã hàng hóa có bị tồn tại không
            if (BUS_HangHoa.TimHangHoaTheoMa(txtMaHH.Text) == null)
            {
                MessageBox.Show("Mã hàng hóa không tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu DTO_HangHoa
            DTO_HangHoa hh = new DTO_HangHoa();
            hh.MaHH1 = txtMaHH.Text;
            hh.MaLoai1 = cbMaLoai.SelectedValue.ToString();
            hh.TenHH1 = txtTenHH.Text;
            hh.DVT1 = txtDVT.Text;
            hh.XuatXu1 = txtXuatXu.Text;
            // Thực hiện sửa
            if (BUS_HangHoa.CapNhatHangHoa(hh) == false)
            {
                MessageBox.Show("Không sửa được.");
                return;
            }
            HienThiLenDataGrid();
            MessageBox.Show("Đã sửa nhân viên.");
        }
        public DTO_TaiKhoan TaiKhoan;
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int quyen;
            if (TaiKhoan == null)
                quyen = 0;
            else
                quyen = TaiKhoan.IQuyen;
            switch (quyen) {
                case 1:
                    // Kiểm tra mã hàng hóa có tồn tại không
                    if (BUS_HangHoa.TimHangHoaTheoMa(txtMaHH.Text) == null)
                    {
                        MessageBox.Show("Mã hàng hóa không tồn tại!");
                        return;
                    }
                    // Gán dữ liệu vào kiểu DTO_HangHoa
                    DTO_HangHoa hh = new DTO_HangHoa();
                    hh.MaHH1 = txtMaHH.Text;

                    // Thực hiện xóa 
                    if (BUS_HangHoa.XoaHangHoa(hh) == false)
                    {
                        MessageBox.Show("Không xóa được.");
                        return;
                    }
                    HienThiLenDataGrid();
                    MessageBox.Show("Đã xóa hàng hóa.");
                    break;
                case 2:
                    btnXoa.Enabled = false;
                    break;
                 }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (rdTen.Checked == true)
            {
                List<DTO_HangHoa> hh = BUS_HangHoa.LayHH();
                List<DTO_HangHoa> kq = (from ten in hh
                                        where ten.TenHH1.Contains(txtTim.Text)
                                        select ten).ToList();
                dgDSHH.DataSource = kq;
            }
            else if(rdMa.Checked == true)
            {
                List<DTO_HangHoa> hh = BUS_HangHoa.LayHH();
                List<DTO_HangHoa> kq = (from ma in hh
                                        where ma.MaHH1.Contains(txtTim.Text)
                                        select ma).ToList();
                dgDSHH.DataSource = kq;
            }
        }
    }
}
