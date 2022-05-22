using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class BUS_HDXUAT
    {
        public static List<DTO_HDXUAT> LayHDXuat()
        {
            return DAO_HDXUAT.LayHDXuat();
        }
        public static bool ThemHDX(DTO_HDXUAT hdx)
        {
            return DAO_HDXUAT.ThemHDX(hdx);
        }
        public static bool CapNhatHDX(DTO_HDXUAT hdx)
        {
            return DAO_HDXUAT.CapNhatHDX(hdx);
        }
        public static bool XoaHDX(DTO_HDXUAT hdx)
        {
            return DAO_HDXUAT.XoaHDX(hdx);
        }

        public static DTO_HDXUAT TimHDXTheoMa(string ma)
        {
            return DAO_HDXUAT.TimHDXTheoMa(ma);
        }
    }
}
