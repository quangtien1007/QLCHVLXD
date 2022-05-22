using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class DAO_HDNHAP
    {
        static SqlConnection con;
        public static List<DTO_HDNHAP> LayHDNhap()
        {
            string sTruyVan = "SELECT n.SO_HD_NHAP,n.MANCC,n.MANV,n.NGAYLAP_NHAP,m.TENNCC,v.TENNV from HOADON_NHAP n, NHACUNGCAP m, NHANVIEN v where n.MANCC=m.MANCC and n.MANV=v.MANV";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<DTO_HDNHAP> lstHDNhap = new List<DTO_HDNHAP>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DTO_HDNHAP hdn = new DTO_HDNHAP();
                hdn.SoHDNhap1 = dt.Rows[i]["SO_HD_NHAP"].ToString();
                hdn.MaNCC1 = dt.Rows[i]["MANCC"].ToString();
                hdn.MaNV1 = dt.Rows[i]["MANV"].ToString();
                hdn.NgayLap1 = dt.Rows[i]["NGAYLAP_NHAP"].ToString();
                hdn.TenNCC1 = dt.Rows[i]["TENNCC"].ToString();
                hdn.TenNV1 = dt.Rows[i]["TENNV"].ToString();
                lstHDNhap.Add(hdn);
            }
            DataProvider.DongKetNoi(con);
            return lstHDNhap;
        }
        // Thêm HDN
        public static bool ThemHDN(DTO_HDNHAP hdn)
        {
            string sTruyVan = string.Format(@"INSERT INTO HOADON_NHAP VALUES(N'{0}',
                N'{1}',N'{2}',N'{3}')", hdn.SoHDNhap1, hdn.MaNCC1, hdn.MaNV1, hdn.NgayLap1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        // Lấy thông tin khách hàng có mã ma, trả về null nếu không thấy
        public static DTO_HDNHAP TimHDNTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"SELECT * FROM HOADON_NHAP WHERE SO_HD_NHAP=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            DTO_HDNHAP hdn = new DTO_HDNHAP();
            hdn.SoHDNhap1 = dt.Rows[0]["SO_HD_NHAP"].ToString();
            hdn.MaNCC1 = dt.Rows[0]["MANCC"].ToString();
            hdn.MaNV1 = dt.Rows[0]["MANV"].ToString();
            hdn.NgayLap1 = dt.Rows[0]["NGAYLAP_NHAP"].ToString();
            DataProvider.DongKetNoi(con);
            return hdn;
        }
        // Cập nhật thông tin HDX
        public static bool CapNhatHDN(DTO_HDNHAP hdn)
        {
            string sTruyVan = string.Format(@"UPDATE HOADON_XUAT SET MANCC=N'{0}',MANV=N'{1}',NGAYLAP_NHAP=N'{2}' where SO_HD_NHAP=N'{3}'",
                hdn.MaNCC1, hdn.MaNV1, hdn.NgayLap1, hdn.SoHDNhap1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        // Xóa thông tin HDX
        public static bool XoaHDN(DTO_HDNHAP hdn)
        {
            string sTruyVan = string.Format(@"DELETE FROM HOADON_NHAP WHERE SO_HD_NHAP=N'{0}'", hdn.SoHDNhap1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
