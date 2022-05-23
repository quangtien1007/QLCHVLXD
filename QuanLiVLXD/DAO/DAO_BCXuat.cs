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
    public class DAO_BCXuat
    {
        static SqlConnection con;
        public static List<DTO_BCXuat> LayBCX()
        {
            string sTruyVan = "SELECT h.MAHH,h.TENHH,h.DONVITINH,x.SOLUONG_XUAT,x.DONGIA_XUAT FROM HANGHOA h, CT_HOADON_XUAT x,KHO k WHERE k.IDKHO=x.IDKHO and k.MAHH=h.MAHH ";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<DTO_BCXuat> lstBCX = new List<DTO_BCXuat>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DTO_BCXuat x = new DTO_BCXuat();
                x.MaHH1 = dt.Rows[i]["MAHH"].ToString();
                x.TenHH1 = dt.Rows[i]["TENHH"].ToString();
                x.DVT1 = dt.Rows[i]["DONVITINH"].ToString();
                x.SoLuongXuat1 = dt.Rows[i]["SOLUONG_XUAT"].ToString();
                x.DonGia1 = int.Parse(dt.Rows[i]["DONGIA_XUAT"].ToString());
                lstBCX.Add(x);
            }
            DataProvider.DongKetNoi(con);
            return lstBCX;
        }
    }
}
