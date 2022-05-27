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
        public static bool ThemNhanVien(DTO_NhanVien nv)
        {
            return DAO_NhanVien.ThemNhanVien(nv);
        }
        public static bool CapNhatNhanVien(DTO_NhanVien nv)
        {
            return DAO_NhanVien.CapNhatNhanVien(nv);
        }
        public static bool XoaNhanVien(DTO_NhanVien nv)
        {
            return DAO_NhanVien.XoaNhanVien(nv);
        }

        public static DTO_NhanVien TimNhanVienTheoMa(string ma)
        {
            return DAO_NhanVien.TimNhanVienTheoMa(ma);
        }
    }
}
