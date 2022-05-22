using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class BUS_HDNHAP
    {
        public static List<DTO_HDNHAP> LayHDNhap()
        {
            return DAO_HDNHAP.LayHDNhap();
        }
        public static bool ThemHDN(DTO_HDNHAP hdn)
        {
            return DAO_HDNHAP.ThemHDN(hdn);
        }
        public static bool CapNhatHDN(DTO_HDNHAP hdn)
        {
            return DAO_HDNHAP.CapNhatHDN(hdn);
        }
        public static bool XoaHDN(DTO_HDNHAP hdn)
        {
            return DAO_HDNHAP.XoaHDN(hdn);
        }

        public static DTO_HDNHAP TimHDNTheoMa(string ma)
        {
            return DAO_HDNHAP.TimHDNTheoMa(ma);
        }
    }
}
