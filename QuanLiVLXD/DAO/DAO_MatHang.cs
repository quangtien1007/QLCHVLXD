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
    public class DAO_MatHang
    {
        static SqlConnection con;
        
        public static List<DTO_MatHang> LayMatHang()
        {
            string sTruyVan = "select m.*,d.gia,n.mapn,n.manv,n.ngaynhap from mathang m,phieunhaphang n,dongia d where m.mansx=n.mansx and m.mamathang=d.mamathang";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<DTO_MatHang> lstMatHang = new List<DTO_MatHang>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DTO_MatHang cv = new DTO_MatHang();
                cv.SMaPN = dt.Rows[i]["mapn"].ToString();
                cv.SMaNV = dt.Rows[i]["manv"].ToString();
                cv.SNgayNhap = dt.Rows[i]["ngaynhap"].ToString();
                cv.SMaMH = dt.Rows[i]["mamathang"].ToString();
                cv.STenMH = dt.Rows[i]["tenmathang"].ToString();
                cv.SMaNSX = dt.Rows[i]["mansx"].ToString();
                cv.SDonGia = dt.Rows[i]["gia"].ToString();
                cv.SMaLoaiMH = dt.Rows[i]["maloaimathang"].ToString();
                cv.SSoLuong = int.Parse(dt.Rows[i]["soluong"].ToString());
                cv.STinhTrang = dt.Rows[i]["tinhtrang"].ToString();
                cv.SGhiChu = dt.Rows[i]["ghichu"].ToString();
                lstMatHang.Add(cv);
            }
            DataProvider.DongKetNoi(con);
            return lstMatHang;
        }
        /*public static bool NhapHang(DTO_MatHang tk)
        {
            string truyvan = string.Format(@"insert into maphieunhap values('{0}','{1}',{2})", tk.STen, tk.SMatKhau, tk.IQuyen);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(truyvan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }*/
    }
}
