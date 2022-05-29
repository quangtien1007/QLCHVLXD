using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class BUS_Kho
    {
        public static List<DTO_Kho> LayKho()
        {
            return DAO_Kho.LayKho();
        }
        public static bool nhapkho(DTO_Kho k)
        {
            return DAO_Kho.nhapkho(k);
        }
        public static bool xuatkho(DTO_Kho k)
        {
            return DAO_Kho.xuatkho(k);
        }
    }
}
