using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class BUS_BCXuat
    {
        public static List<DTO_BCXuat> LayBCX()
        {
            return DAO_BCXuat.LayBCX();
        }
    }
}
