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
    public class DAO_CTHDN
    {
        static SqlConnection con;
        public static List<DTO_CTHDN> LayCTHDN()
        {
            string sTruyVan = "SELECT c.ID,c.MAHH,h.TENHH,c.SO_HD_NHAP,c.SOLUONG_NHAP,c.DONGIA_NHAP,p.IDKHO,t.TENNCC,k.NGAYLAP_NHAP,g.TENNV,d.DONGIA,h.DONVITINH from HOADON_NHAP k,NHANVIEN g, NHACUNGCAP t,HANGHOA h,DONGIA d,CT_HOADON_NHAP c,KHO p where h.MAHH=d.MAHH and c.MAHH=h.MAHH and k.SO_HD_NHAP=c.SO_HD_NHAP and k.MANV=g.MANV and t.MANCC=k.MANCC and c.IDKHO = p.IDKHO";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<DTO_CTHDN> lstCTHDN = new List<DTO_CTHDN>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DTO_CTHDN hdn = new DTO_CTHDN();
                hdn.IDKho1 = int.Parse(dt.Rows[i]["IDKHO"].ToString());
                hdn.TenNCC1 = dt.Rows[i]["TENNCC"].ToString();
                hdn.NgayLap1 = dt.Rows[i]["NGAYLAP_NHAP"].ToString();
                hdn.TenNV1 = dt.Rows[i]["TENNV"].ToString();
                hdn.ID1 = int.Parse(dt.Rows[i]["ID"].ToString());
                hdn.SoHDN1 = dt.Rows[i]["SO_HD_NHAP"].ToString();
                hdn.MaHH1 = dt.Rows[i]["MAHH"].ToString();
                hdn.TenHH1 = dt.Rows[i]["TENHH"].ToString();
                hdn.SoLuong1 = int.Parse(dt.Rows[i]["SOLUONG_NHAP"].ToString());
                hdn.DVT1 = dt.Rows[i]["DONVITINH"].ToString();
                hdn.DonGia1 = int.Parse(dt.Rows[i]["DONGIA"].ToString());
                hdn.ThanhTien1 = int.Parse(dt.Rows[i]["DONGIA_NHAP"].ToString());
                lstCTHDN.Add(hdn);
            }
            DataProvider.DongKetNoi(con);
            return lstCTHDN;
        }
        // Thêm 
        public static bool ThemCTHDN(DTO_CTHDN hdn)
        {
            string sTruyVan = string.Format(@"INSERT INTO CT_HOADON_NHAP VALUES({0},
                {1},N'{2}',N'{3}',{4},{5})", hdn.ID1, hdn.IDKho1,hdn.MaHH1, hdn.SoHDN1, hdn.SoLuong1, hdn.ThanhTien1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        // Lấy thông tin có mã ma, trả về null nếu không thấy
        public static DTO_CTHDN TimTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"SELECT * FROM CT_HOADON_NHAP WHERE ID={0}", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            DTO_CTHDN hdn = new DTO_CTHDN();
            hdn.ID1 = int.Parse(dt.Rows[0]["ID"].ToString());
            hdn.IDKho1 = int.Parse(dt.Rows[0]["IDKHO"].ToString());
            hdn.MaHH1 = dt.Rows[0]["MAHH"].ToString();
            hdn.SoHDN1 = dt.Rows[0]["SO_HD_NHAP"].ToString();
            hdn.SoLuong1 = int.Parse(dt.Rows[0]["SOLUONG_NHAP"].ToString());
            hdn.ThanhTien1 = int.Parse(dt.Rows[0]["DONGIA_NHAP"].ToString());
            DataProvider.DongKetNoi(con);
            return hdn;
        }
        // Cập nhật thông tin 
        public static bool CapNhatCTHDN(DTO_CTHDN h)
        {
            string sTruyVan = string.Format(@"UPDATE CT_HOADON_NHAP SET IDKHO={0},MAHH=N'{1}',SO_HD_NHAP=N'{2}',SOLUONG_NHAP={3},DONGIA_NHAP={4} where ID={4}",
                h.IDKho1, h.SoHDN1, h.SoLuong1, h.ThanhTien1, h.ID1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        // Xóa thông tin 
        public static bool XoaCTHDN(DTO_CTHDN h)
        {
            string sTruyVan = string.Format(@"DELETE FROM CT_HOADON_NHAP WHERE ID={0}", h.ID1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
