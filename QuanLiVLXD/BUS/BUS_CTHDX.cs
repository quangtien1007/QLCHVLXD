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
    }
}
