using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NhanVien
    {
        private string MaNV;
        private string TenNV;
        private string GioiTinh;
        private string NgaySinh;
        private string DiaChi;
        private string SDT;
        private string DienGiai;
        private int Flag;

        public string TenNV1 { get => TenNV; set => TenNV = value; }
        public string NgaySinh1 { get => NgaySinh; set => NgaySinh = value; }
        public string GioiTinh1 { get => GioiTinh; set => GioiTinh = value; }
        public string DiaChi1 { get => DiaChi; set => DiaChi = value; }
        public string SDT1 { get => SDT; set => SDT = value; }
        public string DienGiai1 { get => DienGiai; set => DienGiai = value; }
        public int Flag1 { get => Flag; set => Flag = value; }
        public string MaNV1 { get => MaNV; set => MaNV = value; }

    }
}
