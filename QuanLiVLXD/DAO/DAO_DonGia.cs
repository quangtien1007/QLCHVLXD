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
    public class DAO_DonGia
    {
        static SqlConnection con;
        public static List<DTO_DonGia> LayDG()
        {
            string sTruyVan = "SELECT * FROM DONGIA ";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<DTO_DonGia> lstDG = new List<DTO_DonGia>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DTO_DonGia x = new DTO_DonGia();
                x.MaDG1 = dt.Rows[i]["MADG"].ToString();
                x.DonGia1 = int.Parse(dt.Rows[i]["DONGIA"].ToString());
                x.MaHH1 = dt.Rows[i]["MAHH"].ToString();
                x.TenHH1 = dt.Rows[i]["TENHH"].ToString();
                lstDG.Add(x);
            }
            DataProvider.DongKetNoi(con);
            return lstDG;
        }
    }
}
