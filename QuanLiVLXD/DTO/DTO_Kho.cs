using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Kho
    {
        private string TenHang;
        private string DVT;
        private int SoLuongKho;
        private string XuatXu;
        private string MaLoai;
        private int IDKho;
        private string MaHH;


        public string TenHang1 { get => TenHang; set => TenHang = value; }
        public string DVT1 { get => DVT; set => DVT = value; }
        public int SoLuongKho1 { get => SoLuongKho; set => SoLuongKho = value; }
        public string MaLoai1 { get => MaLoai; set => MaLoai = value; }
        public string XuatXu1 { get => XuatXu; set => XuatXu = value; }
        public int IDKho1 { get => IDKho; set => IDKho = value; }
        public string MaHH1 { get => MaHH; set => MaHH = value; }
    }
}
