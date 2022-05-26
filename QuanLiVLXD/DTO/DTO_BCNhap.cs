using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_BCNhap
    {
        private string TenNCC;
        private string TenHH;
        private string DVT;
        private int SoLuong;
        private int DonGia;
        private DateTime NgayNhap;

        public string TenNCC1 { get => TenNCC; set => TenNCC = value; }
        public string TenHH1 { get => TenHH; set => TenHH = value; }
        public string DVT1 { get => DVT; set => DVT = value; }
        public int SoLuong1 { get => SoLuong; set => SoLuong = value; }
        public int DonGia1 { get => DonGia; set => DonGia = value; }
        public DateTime NgayNhap1 { get => NgayNhap; set => NgayNhap = value; }
    }
}
