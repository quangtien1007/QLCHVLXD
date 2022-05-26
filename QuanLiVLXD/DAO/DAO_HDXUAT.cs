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
    public class DAO_HDXUAT
    {
        static SqlConnection con;
        public static List<DTO_HDXUAT> LayHDXuat()
        {
            string sTruyVan = "select n.SO_HD_XUAT,n.MAKH,n.MANV,n.NGAYLAP_XUAT,n.FLAGXUAT,m.TENKH,v.TENNV from HOADON_XUAT n, KHACHHANG m, NHANVIEN v where n.MAKH=m.MAKH and n.MANV=v.MANV";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<DTO_HDXUAT> lstHDXuat = new List<DTO_HDXUAT>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DTO_HDXUAT hdx = new DTO_HDXUAT();
                hdx.SoHDXuat1 = dt.Rows[i]["So_HD_XUAT"].ToString();
                hdx.MaKH1 = dt.Rows[i]["MAKH"].ToString();
                hdx.MaNV1 = dt.Rows[i]["MANV"].ToString();
                hdx.NgayLap1 = dt.Rows[i]["NGAYLAP_XUAT"].ToString();
                hdx.TenKH1 = dt.Rows[i]["TENKH"].ToString();
                hdx.TenNV1 = dt.Rows[i]["TENNV"].ToString();
                hdx.Flag1 = int.Parse(dt.Rows[i]["FLAGXUAT"].ToString());
                lstHDXuat.Add(hdx);
            }
            DataProvider.DongKetNoi(con);
            return lstHDXuat;
        }
        // Thêm HH
        public static bool ThemHDX(DTO_HDXUAT hdx)
        {
            string sTruyVan = string.Format(@"INSERT INTO HOADON_XUAT VALUES(N'{0}',
                N'{1}',N'{2}',N'{3}',{4})", hdx.SoHDXuat1,hdx.MaKH1,hdx.MaNV1,hdx.NgayLap1,hdx.Flag1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        // Lấy thông tin khách hàng có mã ma, trả về null nếu không thấy
        public static DTO_HDXUAT TimHDXTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"SELECT * FROM HOADON_XUAT WHERE So_HD_XUAT=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            DTO_HDXUAT hdx = new DTO_HDXUAT();
            hdx.SoHDXuat1 = dt.Rows[0]["So_HD_XUAT"].ToString();
            hdx.MaKH1 = dt.Rows[0]["MAKH"].ToString();
            hdx.MaNV1 = dt.Rows[0]["MANV"].ToString();
            hdx.NgayLap1 = dt.Rows[0]["NGAYLAP_XUAT"].ToString();
            hdx.Flag1 = int.Parse(dt.Rows[0]["FLAGXUAT"].ToString());
            DataProvider.DongKetNoi(con);
            return hdx;
        }
        // Cập nhật thông tin HDX
        public static bool CapNhatHDX(DTO_HDXUAT hdx)
        {
            string sTruyVan = string.Format(@"UPDATE HOADON_XUAT SET MAKH=N'{0}',MANV=N'{1}',NGAYLAP_XUAT=N'{2}',FLAGXUAT={3} where So_HD_XUAT=N'{4}'",
                hdx.MaKH1,hdx.MaNV1,hdx.NgayLap1,hdx.Flag1,hdx.SoHDXuat1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        // Xóa thông tin HDX
        public static bool XoaHDX(DTO_HDXUAT hdx)
        {
            string sTruyVan = string.Format(@"DELETE FROM HOADON_XUAT WHERE So_HD_XUAT=N'{0}'", hdx.SoHDXuat1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
