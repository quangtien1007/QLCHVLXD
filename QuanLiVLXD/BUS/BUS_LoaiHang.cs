using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class BUS_LoaiHang
    {
        public static List<DTO_LoaiHang> LayLH()
        {
            return DAO_LoaiHang.LayLH();
        }
        public static bool ThemLoaiHang(DTO_LoaiHang lh)
        {
            return DAO_LoaiHang.ThemLoaiHang(lh);
        }
        public static bool CapNhatLoaiHang(DTO_LoaiHang lh)
        {
            return DAO_LoaiHang.CapNhatLoaiHang(lh);
        }
        public static bool XoaLoaiHang(DTO_LoaiHang lh)
        {
            return DAO_LoaiHang.XoaLoaiHang(lh);
        }

        public static DTO_LoaiHang TimLoaiHangTheoMa(string ma)
        {
            return DAO_LoaiHang.TimLoaiHangTheoMa(ma);
        }
    }
}
