using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class BUS_NCC
    {
        public static List<DTO_NCC> LayNCC()
        {
            return DAO_NCC.LayNCC();
        }
        public static bool ThemNCC(DTO_NCC ncc)
        {
            return DAO_NCC.ThemNCC(ncc);
        }
        public static bool CapNhatNCC(DTO_NCC ncc)
        {
            return DAO_NCC.CapNhatNCC(ncc);
        }
        public static bool XoaNCC(DTO_NCC ncc)
        {
            return DAO_NCC.XoaNCC(ncc);
        }

        public static DTO_NCC TimNCCTheoMa(string ma)
        {
            return DAO_NCC.TimNCCTheoMa(ma);
        }

    }
}

