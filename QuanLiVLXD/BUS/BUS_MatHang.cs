using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class BUS_MatHang
    {
        public static List<DTO_MatHang> LayMatHang()
        {
            return DAO_MatHang.LayMatHang();
        }
       
    }
}
