using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class BUS_CTHDN
    {
        public static List<DTO_CTHDN> LayCTHDN()
        {
            return DAO_CTHDN.LayCTHDN();
        }
        public static bool ThemCTHDN(DTO_CTHDN hdn)
        {
            return DAO_CTHDN.ThemCTHDN(hdn);
        }
        public static DTO_CTHDN TimTheoMa(string ma)
        {
            return DAO_CTHDN.TimTheoMa(ma);
        }
        public static bool CapNhatCTHDN(DTO_CTHDN hdn)
        {
            return DAO_CTHDN.CapNhatCTHDN(hdn);
        }
        public static bool XoaCTHDN(DTO_CTHDN hdn)
        {
            return DAO_CTHDN.XoaCTHDN(hdn);
        }
    }
}
