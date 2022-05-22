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
                nv.DienGiai1 = dt.Rows[i]["DIENGIAI"].ToString();
                nv.Flag1 = int.Parse(dt.Rows[i]["FLAG"].ToString());
                lstNhanVien.Add(nv);
            }
            DataProvider.DongKetNoi(con);
            return lstNhanVien;
        }
    }
}
