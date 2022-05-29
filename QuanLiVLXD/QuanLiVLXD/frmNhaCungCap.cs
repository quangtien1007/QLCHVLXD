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

namespace QuanLiVLXD
{
    public partial class frmNhaCungCap : Form
    {
        public frmNhaCungCap()
        {
            InitializeComponent();
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

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            HienThiLenDataGrid();
            SetHeaderText();
            ColorDataGrid();
        }
        private void dgDSNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtMaNCC.Text = dgDSNCC.Rows[i].Cells["MaNCC1"].Value.ToString();
            txtTenNCC.Text = dgDSNCC.Rows[i].Cells["TenNCC1"].Value.ToString();
            txtDiaChi.Text = dgDSNCC.Rows[i].Cells["DiaChi1"].Value.ToString();
            txtSDT.Text = dgDSNCC.Rows[i].Cells["SDT1"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaNCC.Text == "" || txtTenNCC.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã hàng hóa có độ dài chuỗi hợp lệ hay không
            if (txtMaNCC.Text.Length > 8)
            {
                MessageBox.Show("Mã NCC tối đa 8 ký tự!");
                return;
            }
            if (txtSDT.Text.Length < 10)
            {
                MessageBox.Show("Số điện thoại ít nhất 10 số!!!", "Thông báo");
                return;
            }
            // Kiểm tra mã hàng hóa có bị trùng không
            if (BUS_NCC.TimNCCTheoMa(txtMaNCC.Text) != null)
            {
                MessageBox.Show("Mã NCC đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu DTO_HangHoa
            DTO_NCC ncc = new DTO_NCC();
            ncc.MaNCC1 = txtMaNCC.Text;
            ncc.TenNCC1 = txtTenNCC.Text;
            ncc.DiaChi1 = txtDiaChi.Text;
            ncc.SDT1 = txtSDT.Text;
            // Thực hiện thêm
            if (BUS_NCC.ThemNCC(ncc) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            HienThiLenDataGrid();
            MessageBox.Show("Đã thêm NCC.");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaNCC.Text == "" || txtTenNCC.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã hàng hóa có độ dài chuỗi hợp lệ hay không
            if (txtMaNCC.Text.Length > 8)
            {
                MessageBox.Show("Mã NCC tối đa 8 ký tự!");
                return;
            }
            if (txtSDT.Text.Length < 10)
            {
                MessageBox.Show("Số điện thoại ít nhất 10 số!!!", "Thông báo");
                return;
            }
            // Kiểm tra mã hàng hóa có bị trùng không
            if (BUS_NCC.TimNCCTheoMa(txtMaNCC.Text) == null)
            {
                MessageBox.Show("Mã NCC đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu DTO_HangHoa
            DTO_NCC ncc = new DTO_NCC();
            ncc.MaNCC1 = txtMaNCC.Text;
            ncc.TenNCC1 = txtTenNCC.Text;
            ncc.DiaChi1 = txtDiaChi.Text;
            ncc.SDT1 = txtSDT.Text;
            // Thực hiện thêm
            if (BUS_NCC.CapNhatNCC(ncc) == false)
            {
                MessageBox.Show("Không sửa được.");
                return;
            }
            HienThiLenDataGrid();
            MessageBox.Show("Đã sửa NCC.");
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
                        // Kiểm tra mã NCC có tồn tại không
                        if (BUS_NCC.TimNCCTheoMa(txtMaNCC.Text) == null)
                        {
                            MessageBox.Show("Mã NCC không tồn tại!");
                            return;
                        }
                        // Gán dữ liệu vào kiểu DTO_NCC
                        DTO_NCC ncc = new DTO_NCC();
                        ncc.MaNCC1 = txtMaNCC.Text;

                        // Thực hiện xóa 
                        if (BUS_NCC.XoaNCC(ncc) == false)
                        {
                            MessageBox.Show("Không xóa được.");
                            return;
                        }
                        HienThiLenDataGrid();
                        MessageBox.Show("Đã xóa NCC.");
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
                List<DTO_NCC> lh = BUS_NCC.LayNCC();
                List<DTO_NCC> kq = (from ten in lh
                                         where ten.TenNCC1.Contains(txtTim.Text)
                                         select ten).ToList();
                dgDSNCC.DataSource = kq;
            }
            else if (rdMa.Checked == true)
            {
                List<DTO_NCC> hh = BUS_NCC.LayNCC();
                List<DTO_NCC> kq = (from ma in hh
                                         where ma.MaNCC1.Contains(txtTim.Text)
                                         select ma).ToList();
                dgDSNCC.DataSource = kq;
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Không được nhập chữ!!");
            }
        }
    
    }
}
