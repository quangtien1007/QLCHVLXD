using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class BUS_HangHoa
    {
        public static List<DTO_HangHoa> LayHH()
        {
            return DAO_HangHoa.LayHH();
        }
        public static bool ThemHangHoa(DTO_HangHoa hh)
        {
            return DAO_HangHoa.ThemHangHoa(hh);
        }
        public static bool CapNhatHangHoa(DTO_HangHoa hh)
        {
            return DAO_HangHoa.CapNhatHangHoa(hh);
        }
        public static bool XoaHangHoa(DTO_HangHoa hh)
        {
            return DAO_HangHoa.XoaHangHoa(hh);
        }

        public static DTO_HangHoa TimHangHoaTheoMa(string ma)
        {
            return DAO_HangHoa.TimHangHoaTheoMa(ma);
        }

    }
}
