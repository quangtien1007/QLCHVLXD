using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class BUS_CTHDX
    {
        public static List<DTO_CTHDXUAT> LayCTHDXuat()
        {
            return DAO_CTHDXUAT.LayCTHDXuat();
        }
        public static bool ThemCTHDX(DTO_CTHDXUAT hdx)
        {
            return DAO_CTHDXUAT.ThemCTHDX(hdx);
        }
        public static DTO_CTHDXUAT TimTheoMa(string ma)
        {
            return DAO_CTHDXUAT.TimTheoMa(ma);
        }
        public static bool CapNhatCTHDX(DTO_CTHDXUAT x)
        {
            return DAO_CTHDXUAT.CapNhatCTHDX(x);
        }
        public static bool XoaCTHDX(DTO_CTHDXUAT x)
        {
            return DAO_CTHDXUAT.XoaCTHDX(x);
        }
    }
}
