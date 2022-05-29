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
    public class DAO_NhanVien
    {
        static SqlConnection con;

        public static List<DTO_NhanVien> LayNV()
        {
            string sTruyVan = "select * from NHANVIEN";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<DTO_NhanVien> lstNhanVien = new List<DTO_NhanVien>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String.Format("{0:MM/dd/yyyy}", dt.Rows[i]["NGAYSINH"]);
                DTO_NhanVien nv = new DTO_NhanVien();
                nv.MaNV1 = dt.Rows[i]["MANV"].ToString();
                nv.TenNV1 = dt.Rows[i]["TENNV"].ToString();
                nv.GioiTinh1 = dt.Rows[i]["GIOITINH"].ToString();
                nv.NgaySinh1 = dt.Rows[i]["NGAYSINH"].ToString();
                nv.DiaChi1 = dt.Rows[i]["DIACHI"].ToString();
                nv.SDT1 = dt.Rows[i]["SDT"].ToString();
                nv.DienGiai1 = dt.Rows[i]["DIENGIAI"].ToString();
                nv.Flag1 = int.Parse(dt.Rows[i]["FLAG"].ToString());
                lstNhanVien.Add(nv);
            }
            DataProvider.DongKetNoi(con);
            return lstNhanVien;
        }
        // Thêm NV
        public static bool ThemNhanVien(DTO_NhanVien nv)
        {
            string sTruyVan = string.Format(@"INSERT INTO NHANVIEN VALUES(N'{0}',
                N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',{7})",nv.MaNV1,nv.TenNV1,nv.GioiTinh1,nv.NgaySinh1,nv.DiaChi1,nv.SDT1,nv.DienGiai1,nv.Flag1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        // Lấy thông tin có mã ma, trả về null nếu không thấy
        public static DTO_NhanVien TimNhanVienTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"SELECT * FROM NHANVIEN WHERE MANV = N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            DTO_NhanVien nv = new DTO_NhanVien();
            nv.MaNV1 = dt.Rows[0]["MANV"].ToString();
            nv.TenNV1 = dt.Rows[0]["TENNV"].ToString();
            nv.GioiTinh1 = dt.Rows[0]["GIOITINH"].ToString();
            nv.NgaySinh1 = dt.Rows[0]["NGAYSINH"].ToString();
            nv.DiaChi1 = dt.Rows[0]["DIACHI"].ToString();
            nv.SDT1 = dt.Rows[0]["SDT"].ToString();
            nv.DienGiai1 = dt.Rows[0]["DIENGIAI"].ToString();
            nv.Flag1 = int.Parse(dt.Rows[0]["FLAG"].ToString());
            DataProvider.DongKetNoi(con);
            return nv;
        }
        // Cập nhật thông tin NV
        public static bool CapNhatNhanVien(DTO_NhanVien nv)
        {
            string sTruyVan = string.Format(@"UPDATE NHANVIEN SET TENNV=N'{0}',GIOITINH=N'{1}',NGAYSINH=N'{2}',DIACHI=N'{3}', SDT=N'{4}', DIENGIAI=N'{5}',FLAG={6} where MANV=N'{7}'",
                 nv.TenNV1, nv.GioiTinh1, nv.NgaySinh1, nv.DiaChi1, nv.SDT1, nv.DienGiai1, nv.Flag1, nv.MaNV1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        // Xóa thông tin NV
        public static bool XoaNhanVien(DTO_NhanVien nv)
        {
            string sTruyVan = string.Format(@"DELETE FROM NHANVIEN WHERE MANV=N'{0}'", nv.MaNV1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
