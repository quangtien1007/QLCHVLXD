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
    }
}
