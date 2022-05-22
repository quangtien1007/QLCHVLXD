using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_LoaiHang
    {
        private string MaLoai;
        private string TenLoai;
        private string DienGiai;
        private string TrangThai;

        public string MaLoai1 { get => MaLoai; set => MaLoai = value; }
        public string TenLoai1 { get => TenLoai; set => TenLoai = value; }
        public string DienGiai1 { get => DienGiai; set => DienGiai = value; }
        public string TrangThai1 { get => TrangThai; set => TrangThai = value; }
    }
}
