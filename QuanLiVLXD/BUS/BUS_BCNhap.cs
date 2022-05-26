using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class BUS_BCNhap
    {
        public static List<DTO_BCNhap> LayBCN()
        {
            return DAO_BCNhap.LayBCN();
        }
    }
}
