using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class BUS_DonGia
    {
        public static List<DTO_DonGia> LayDG()
        {
            return DAO_DonGia.LayDG();
        }
    }
}
