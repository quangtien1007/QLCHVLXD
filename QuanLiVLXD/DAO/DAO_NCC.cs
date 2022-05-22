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
    public class DAO_NCC
    {
        static SqlConnection con;
        public static List<DTO_NCC> LayNCC()
        {
            string sTruyVan = "select * from NHACUNGCAP";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<DTO_NCC> lstNCC = new List<DTO_NCC>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DTO_NCC ncc = new DTO_NCC();
                ncc.MaNCC1 = dt.Rows[i]["MANCC"].ToString();
                ncc.TenNCC1 = dt.Rows[i]["TENNCC"].ToString();
                ncc.DiaChi1 = dt.Rows[i]["DIACHI"].ToString();
                ncc.SDT1 = dt.Rows[i]["SDT"].ToString();
                lstNCC.Add(ncc);
            }
            DataProvider.DongKetNoi(con);
            return lstNCC;
        }
        // Thêm HH
        public static bool ThemNCC(DTO_NCC ncc)
        {
            string sTruyVan = string.Format(@"INSERT INTO NHACUNGCAP VALUES(N'{0}',
                N'{1}',N'{2}',N'{3}')",ncc.MaNCC1,ncc.TenNCC1,ncc.DiaChi1,ncc.SDT1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        
        // Cập nhật thông tin NCC
        public static bool CapNhatNCC(DTO_NCC ncc)
        {
            string sTruyVan = string.Format(@"UPDATE NHACUNGCAP SET TENNCC=N'{0}',DIACHI=N'{1}',SDT=N'{2}' WHERE MANCC=N'{3}'",
                ncc.TenNCC1,ncc.DiaChi1,ncc.SDT1,ncc.MaNCC1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        // Xóa thông tin NCC
        public static bool XoaNCC(DTO_NCC ncc)
        {
            string sTruyVan = string.Format(@"DELETE FROM NHACUNGCAP WHERE MANCC=N'{0}'", ncc.MaNCC1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        // Lấy thông tin NCC có mã ma, trả về null nếu không thấy
        public static DTO_NCC TimNCCTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"SELECT * FROM NHACUNGCAP WHERE MANCC=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            DTO_NCC ncc = new DTO_NCC();
            ncc.MaNCC1 = dt.Rows[0]["MANCC"].ToString();
            ncc.TenNCC1 = dt.Rows[0]["TENNCC"].ToString();
            ncc.DiaChi1 = dt.Rows[0]["DIACHI"].ToString();
            ncc.SDT1 = dt.Rows[0]["SDT"].ToString();
            DataProvider.DongKetNoi(con);
            return ncc;
        }
    }
}
