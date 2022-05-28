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
            string sTruyVan = "SELECT c.ID,c.MAHH,c.SO_HD_NHAP,c.SOLUONG_NHAP,t.TENNCC,k.NGAYLAP_NHAP,g.TENNV,d.DONGIA,h.DONVITINH from HOADON_NHAP k,NHANVIEN g, NHACUNGCAP t,HANGHOA h,DONGIA d,CT_HOADON_NHAP c,KHO p where h.MAHH=d.MAHH and c.MAHH=h.MAHH and k.SO_HD_NHAP=c.SO_HD_NHAP and k.MANV=g.MANV and t.MANCC=k.MANCC and c.IDKHO = p.IDKHO";
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
                hdn.MaNCC1 = dt.Rows[i]["TENNCC"].ToString();
                hdn.NgayLap1 = dt.Rows[i]["NGAYLAP_NHAP"].ToString();
                hdn.MaNV1 = dt.Rows[i]["TENNV"].ToString();
                hdn.ID1 = int.Parse(dt.Rows[i]["ID"].ToString());
                hdn.SoHDN1 = dt.Rows[i]["SO_HD_NHAP"].ToString();
                hdn.MaHH1 = dt.Rows[i]["MAHH"].ToString();
                hdn.SoLuong1 = int.Parse(dt.Rows[i]["SOLUONG_NHAP"].ToString());
                hdn.DVT1 = dt.Rows[i]["DONVITINH"].ToString();
                hdn.DonGia1 = dt.Rows[i]["DONGIA"].ToString();
                hdn.ThanhTien1 = dt.Rows[i]["DONGIA"].ToString();
                lstCTHDN.Add(hdn);
            }
            DataProvider.DongKetNoi(con);
            return lstCTHDN;
        }
    }
}
