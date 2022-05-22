using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class BUS_KhachHang
    {
        public static List<DTO_KhachHang> LayKH()
        {
            return DAO_KhachHang.LayKH();
        }
        public static bool ThemKhachHang(DTO_KhachHang kh)
        {
            return DAO_KhachHang.ThemKhachHang(kh);
        }
        public static bool CapNhatKhachHang(DTO_KhachHang kh)
        {
            return DAO_KhachHang.CapNhatKhachHang(kh);
        }
        public static bool XoaKhachHang(DTO_KhachHang kh)
        {
            return DAO_KhachHang.XoaKhachHang(kh);
        }

        public static DTO_KhachHang TimKhachHangTheoMa(string ma)
        {
            return DAO_KhachHang.TimKhachHangTheoMa(ma);
        }
    }
}
