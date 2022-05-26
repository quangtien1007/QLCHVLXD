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
    public class DAO_BCNhap
    {
        static SqlConnection con;
        public static List<DTO_BCNhap> LayBCN()
        {
            string sTruyVan = "SELECT n.TENNCC,h.TENHH,h.DONVITINH,i.SOLUONG_NHAP,i.DONGIA_NHAP,c.NGAYLAP_NHAP from HANGHOA h,NHACUNGCAP n,HOADON_NHAP c,CT_HOADON_NHAP i where h.MAHH=i.MAHH and i.SO_HD_NHAP=c.SO_HD_NHAP and c.MANCC=n.MANCC";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<DTO_BCNhap> lstBCN= new List<DTO_BCNhap>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DTO_BCNhap n = new DTO_BCNhap();
                n.TenNCC1 = dt.Rows[i]["TENNCC"].ToString();
                n.TenHH1 = dt.Rows[i]["TENHH"].ToString();
                n.DVT1 = dt.Rows[i]["DONVITINH"].ToString();
                n.SoLuong1 = int.Parse(dt.Rows[i]["SOLUONG_NHAP"].ToString());
                n.DonGia1 = int.Parse(dt.Rows[i]["DONGIA_NHAP"].ToString());
                n.NgayNhap1 = DateTime.Parse(dt.Rows[i]["NGAYLAP_NHAP"].ToString()); 
                lstBCN.Add(n);
            }
            DataProvider.DongKetNoi(con);
            return lstBCN;
        }
    }
}
