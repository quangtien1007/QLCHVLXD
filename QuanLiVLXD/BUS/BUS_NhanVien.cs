using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class BUS_NhanVien
    {
        public static List<DTO_NhanVien> LayNV()
        {
            return DAO_NhanVien.LayNV();
        }
    }
}
