using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class DAO_KhachHang
    {
        static SqlConnection con;
        public static List<DTO_KhachHang> LayKH()
        {
            string sTruyVan = "select * from KHACHHANG";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<DTO_KhachHang> lstKhachHang = new List<DTO_KhachHang>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DTO_KhachHang kh = new DTO_KhachHang();
                kh.MaKH1 = dt.Rows[i]["MAKH"].ToString();
                kh.TenKH1 = dt.Rows[i]["TENKH"].ToString();
                kh.DiaChi1 = dt.Rows[i]["DIACHI"].ToString();
                kh.SDT1 = dt.Rows[i]["SDT"].ToString();
                lstKhachHang.Add(kh);
            }
            DataProvider.DongKetNoi(con);
            return lstKhachHang;
        }
        // Thêm HH
        public static bool ThemKhachHang(DTO_KhachHang kh)
        {
            string sTruyVan = string.Format(@"INSERT INTO KHACHHANG VALUES(N'{0}',
                N'{1}',N'{2}',N'{3}')", kh.MaKH1, kh.TenKH1, kh.DiaChi1, kh.SDT1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        // Lấy thông tin khách hàng có mã ma, trả về null nếu không thấy
        public static DTO_KhachHang TimKhachHangTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"SELECT * FROM KHACHHANG WHERE MAKH=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            DTO_KhachHang kh = new DTO_KhachHang();
            kh.MaKH1 = dt.Rows[0]["MAKH"].ToString();
            kh.TenKH1 = dt.Rows[0]["TENKH"].ToString();
            kh.DiaChi1 = dt.Rows[0]["DIACHI"].ToString();
            kh.SDT1 = dt.Rows[0]["SDT"].ToString();
            DataProvider.DongKetNoi(con);
            return kh;
        }
        // Cập nhật thông tin KH
        public static bool CapNhatKhachHang(DTO_KhachHang kh)
        {
            string sTruyVan = string.Format(@"UPDATE KHACHHANG SET TENKH=N'{0}',DIACHI=N'{1}',SDT=N'{2}' where MAKH=N'{3}'",
                kh.TenKH1,kh.DiaChi1,kh.SDT1,kh.MaKH1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        // Xóa thông tin khách hàng
        public static bool XoaKhachHang(DTO_KhachHang kh)
        {
            string sTruyVan = string.Format(@"DELETE FROM KHACHHANG WHERE MAKH=N'{0}'", kh.MaKH1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
