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
    public class DAO_Kho
    {
        static SqlConnection con;
        public static List<DTO_Kho> LayKho()
        {
            string sTruyVan = "SELECT h.MALOAI,h.TENHH,h.DONVITINH,h.XUATXU,h.MAHH,k.SOLUONG,k.IDKHO from HANGHOA h, KHO k WHERE k.MAHH=h.MAHH";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<DTO_Kho> lstKho = new List<DTO_Kho>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DTO_Kho k = new DTO_Kho();
                k.MaLoai1 = dt.Rows[i]["MALOAI"].ToString();
                k.TenHang1 = dt.Rows[i]["TENHH"].ToString();
                k.MaHH1 = dt.Rows[i]["MAHH"].ToString();
                k.DVT1 = dt.Rows[i]["DONVITINH"].ToString();
                k.SoLuongKho1 = int.Parse(dt.Rows[i]["SOLUONG"].ToString());
                k.IDKho1 = int.Parse(dt.Rows[i]["IDKHO"].ToString());
                k.XuatXu1 = dt.Rows[i]["XUATXU"].ToString();
                lstKho.Add(k);
            }
            DataProvider.DongKetNoi(con);
            return lstKho;
        }
        
    }
}
