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
    public class DAO_HangHoa
    {
        static SqlConnection con;
        public static List<DTO_HangHoa> LayHH()
        {
            string sTruyVan = "select * from HANGHOA";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<DTO_HangHoa> lstHangHoa = new List<DTO_HangHoa>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DTO_HangHoa hh = new DTO_HangHoa();
                hh.MaHH1 = dt.Rows[i]["MAHH"].ToString();
                hh.MaLoai1 = dt.Rows[i]["MALOAI"].ToString();
                hh.TenHH1 = dt.Rows[i]["TENHH"].ToString();
                hh.DVT1 = dt.Rows[i]["DONVITINH"].ToString();
                hh.XuatXu1 = dt.Rows[i]["XUATXU"].ToString();
                lstHangHoa.Add(hh);
            }
            DataProvider.DongKetNoi(con);
            return lstHangHoa;
        }
        // Thêm HH
        public static bool ThemHangHoa(DTO_HangHoa hh)
        {
            string sTruyVan = string.Format(@"INSERT INTO HANGHOA VALUES(N'{0}',
                N'{1}',N'{2}',N'{3}','{4}')", hh.MaHH1, hh.MaLoai1, hh.TenHH1, hh.DVT1, hh.XuatXu1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        // Lấy thông tin hàng hóa có mã ma, trả về null nếu không thấy
        public static DTO_HangHoa TimHangHoaTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"SELECT * FROM HANGHOA WHERE MAHH=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            DTO_HangHoa hh = new DTO_HangHoa();
            hh.MaHH1 = dt.Rows[0]["MAHH"].ToString();
            hh.MaLoai1 = dt.Rows[0]["MALOAI"].ToString();
            hh.TenHH1 = dt.Rows[0]["TENHH"].ToString();
            hh.DVT1 = dt.Rows[0]["DONVITINH"].ToString();
            hh.XuatXu1 = dt.Rows[0]["XUATXU"].ToString();
            DataProvider.DongKetNoi(con);
            return hh;
        }
        // Cập nhật thông tin HH
        public static bool CapNhatHangHoa(DTO_HangHoa hh)
        {
            string sTruyVan = string.Format(@"UPDATE HANGHOA SET MALOAI=N'{0}',TENHH=N'{1}',DONVITINH=N'{2}',XUATXU=N'{3}' where MAHH=N'{4}'",
                hh.MaLoai1,hh.TenHH1,hh.DVT1,hh.XuatXu1,hh.MaHH1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        // Xóa thông tin hàng hóa
        public static bool XoaHangHoa(DTO_HangHoa hh)
        {
            string sTruyVan = string.Format(@"DELETE FROM HANGHOA WHERE MAHH=N'{0}'", hh.MaHH1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
