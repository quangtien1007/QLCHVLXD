using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DAO_TaiKhoan
    {
        static SqlConnection con;
        public static List<DTO_TaiKhoan> LayTKhoan()
        {
            string sTruyVan = "select * from taikhoan";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<DTO_TaiKhoan> lstTaiKhoan = new List<DTO_TaiKhoan>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DTO_TaiKhoan tk = new DTO_TaiKhoan();
                tk.STen = dt.Rows[i]["ten"].ToString();
                tk.SMatKhau = dt.Rows[i]["matkhau"].ToString();
                tk.IQuyen = int.Parse(dt.Rows[i]["quyen"].ToString());
                lstTaiKhoan.Add(tk);
            }
                DataProvider.DongKetNoi(con);
                return lstTaiKhoan;
        }
       
        public static DTO_TaiKhoan LayTaiKhoan(string ten, string matkhau)
        {
            string sTruyVan = string.Format("select * from taikhoan where ten='{0}' and matkhau='{1}'", ten, matkhau);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // Trả về thông tin kiểu NguoiDungDTO
            DTO_TaiKhoan nd = new DTO_TaiKhoan();
            nd.STen = dt.Rows[0]["ten"].ToString();
            nd.SMatKhau = dt.Rows[0]["matkhau"].ToString();
            nd.IQuyen = int.Parse(dt.Rows[0]["quyen"].ToString());
            DataProvider.DongKetNoi(con);
            return nd;
        }
        public static bool ThemTaiKhoan(DTO_TaiKhoan tk)
        {
            string truyvan = string.Format(@"insert into taikhoan values('{0}','{1}',{2})", tk.STen, tk.SMatKhau, tk.IQuyen);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(truyvan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool XoaTaiKhoan(DTO_TaiKhoan tk)
        {
            string truyvan = string.Format(@"delete from taikhoan where ten=N'{0}'", tk.STen);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(truyvan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool SuaTaiKhoan(DTO_TaiKhoan tk)
        {
            string sTruyVan = string.Format(@"update taikhoan set matkhau='{0}',quyen={1} where ten='{2}'",tk.SMatKhau, tk.IQuyen,tk.STen);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        
    }
}
