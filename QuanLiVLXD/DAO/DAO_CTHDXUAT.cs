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
    public class DAO_CTHDXUAT
    {
        static SqlConnection con;
        public static List<DTO_CTHDXUAT> LayCTHDXuat()
        {
            string sTruyVan = "SELECT c.SO_HD_XUAT,c.SOLUONG_XUAT,c.DONGIA_XUAT,k.TENKH,k.SDT,h.TENHH,n.TENNV,n.DIACHI," +
                "v.SOLUONG,m.NGAYLAP_XUAT,h.XUATXU from CT_HOADON_XUAT c,KHACHHANG k,NHANVIEN n,KHO v,HOADON_XUAT m,HANGHOA h " +
                "where c.SO_HD_XUAT=m.SO_HD_XUAT and m.MAKH=k.MAKH and m.MANV=n.MANV and v.MAHH=h.MAHH and c.IDKHO=v.IDKHO";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<DTO_CTHDXUAT> lstCTHDXuat = new List<DTO_CTHDXUAT>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DTO_CTHDXUAT hdx = new DTO_CTHDXUAT();
                hdx.SoHDXuat1 = dt.Rows[i]["So_HD_XUAT"].ToString();
                hdx.TenKH1 = dt.Rows[i]["TENKH"].ToString();
                hdx.SDT1 = dt.Rows[i]["SDT"].ToString();
                hdx.NgayLap1 = dt.Rows[i]["NGAYLAP_XUAT"].ToString();
                hdx.DiaChi1 = dt.Rows[i]["DIACHI"].ToString();
                hdx.TenNV1 = dt.Rows[i]["TENNV"].ToString();
                hdx.TenHH1 = dt.Rows[i]["TENHH"].ToString();
                hdx.SoLuongKho1 = int.Parse(dt.Rows[i]["SOLUONG"].ToString());
                hdx.SoLuong1 = int.Parse(dt.Rows[i]["SOLUONG_XUAT"].ToString());
                hdx.DonGia1 = int.Parse(dt.Rows[i]["DONGIA_XUAT"].ToString());
                hdx.XuatXu1 = dt.Rows[i]["XUATXU"].ToString();
                lstCTHDXuat.Add(hdx);
            }
            DataProvider.DongKetNoi(con);
            return lstCTHDXuat;
        }
    }
}
