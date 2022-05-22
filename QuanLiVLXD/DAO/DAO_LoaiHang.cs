using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace DAO
{
    public class DAO_LoaiHang
    {
        static SqlConnection con;
        public static List<DTO_LoaiHang> LayLH()
        {
            
            string sTruyVan = "select * from LOAIHANG";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<DTO_LoaiHang> lstLoaiHang = new List<DTO_LoaiHang>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DTO_LoaiHang lh = new DTO_LoaiHang();
                lh.MaLoai1 = dt.Rows[i]["MALOAI"].ToString();
                lh.TenLoai1 = dt.Rows[i]["TENLOAI"].ToString();
                lh.DienGiai1 = dt.Rows[i]["DIENGIAI"].ToString();
                lh.TrangThai1 = dt.Rows[i]["TRANGTHAI"].ToString();
                lstLoaiHang.Add(lh);
            }
            DataProvider.DongKetNoi(con);
            return lstLoaiHang;
        }
        // Thêm LH
        public static bool ThemLoaiHang(DTO_LoaiHang lh)
        {
            string sTruyVan = string.Format(@"INSERT INTO LOAIHANG VALUES(N'{0}',
                N'{1}',N'{2}',N'{3}')", lh.MaLoai1, lh.TenLoai1, lh.DienGiai1, lh.TrangThai1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        // Lấy thông tin loại hàng có mã ma, trả về null nếu không thấy
        public static DTO_LoaiHang TimLoaiHangTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"SELECT * FROM LOAIHANG WHERE MALOAI=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            DTO_LoaiHang lh = new DTO_LoaiHang();
            lh.MaLoai1 = dt.Rows[0]["MALOAI"].ToString();
            lh.TenLoai1 = dt.Rows[0]["TENLOAI"].ToString();
            lh.DienGiai1 = dt.Rows[0]["DIENGIAI"].ToString();
            lh.TrangThai1 = dt.Rows[0]["TrangThai"].ToString();
            DataProvider.DongKetNoi(con);
            return lh;
        }
        // Cập nhật thông tin KH
        public static bool CapNhatLoaiHang(DTO_LoaiHang lh)
        {
            string sTruyVan = string.Format(@"UPDATE LOAIHANG SET TENLOAI=N'{0}',DIENGIAI=N'{1}',TRANGTHAI=N'{2}' where MALOAI=N'{3}'",
                lh.TenLoai1, lh.DienGiai1, lh.TrangThai1, lh.MaLoai1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        // Xóa thông tin khách hàng
        public static bool XoaLoaiHang(DTO_LoaiHang lh)
        {
            string sTruyVan = string.Format(@"DELETE FROM LOAIHANG WHERE MALOAI=N'{0}'", lh.MaLoai1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
