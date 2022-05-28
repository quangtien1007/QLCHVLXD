﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class DAO_CTHDXUAT
    {
        static SqlConnection con;
        public static List<DTO_CTHDXUAT> LayCTHDXuat()
        {
            string sTruyVan = "SELECT c.SO_HD_XUAT,c.SOLUONG_XUAT,c.IDXUAT,c.DONGIA_XUAT,k.TENKH,k.SDT,h.TENHH,h.MAHH,n.TENNV,n.DIACHI," +
                "v.SOLUONG,m.NGAYLAP_XUAT,h.XUATXU,h.DONVITINH from CT_HOADON_XUAT c,KHACHHANG k,NHANVIEN n,KHO v,HOADON_XUAT m,HANGHOA h " +
                "where c.SO_HD_XUAT=m.SO_HD_XUAT and m.MAKH=k.MAKH and m.MANV=n.MANV and v.MAHH=h.MAHH and c.IDKHO=v.IDKHO";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<DTO_CTHDXUAT> lstCTHDXuat = new List<DTO_CTHDXUAT>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DTO_CTHDXUAT hdx = new DTO_CTHDXUAT();
                hdx.DVT1 = dt.Rows[i]["DONVITINH"].ToString();
                hdx.SoHDXuat1 = dt.Rows[i]["So_HD_XUAT"].ToString();
                hdx.TenKH1 = dt.Rows[i]["TENKH"].ToString();
                hdx.SDT1 = dt.Rows[i]["SDT"].ToString();
                hdx.NgayLap1 = dt.Rows[i]["NGAYLAP_XUAT"].ToString();
                hdx.DiaChi1 = dt.Rows[i]["DIACHI"].ToString();
                hdx.TenNV1 = dt.Rows[i]["TENNV"].ToString();
                hdx.TenHH1 = dt.Rows[i]["TENHH"].ToString();
                hdx.SoLuongKho1 = int.Parse(dt.Rows[i]["SOLUONG"].ToString());
                hdx.SoLuong1 = int.Parse(dt.Rows[i]["SOLUONG_XUAT"].ToString());
                hdx.DonGia1 = int.Parse(dt.Rows[i]["DONGIA_XUAT"].ToString());
                hdx.XuatXu1 = dt.Rows[i]["XUATXU"].ToString();
                hdx.IDXUAT1 = int.Parse(dt.Rows[i]["IDXUAT"].ToString());
                hdx.MaHH1 = dt.Rows[i]["MAHH"].ToString();
                lstCTHDXuat.Add(hdx);
            }
            DataProvider.DongKetNoi(con);
            return lstCTHDXuat;
        }
        
        // Thêm 
        public static bool ThemCTHDX(DTO_CTHDXUAT hdx)
        {
            string sTruyVan = string.Format(@"INSERT INTO CT_HOADON_XUAT VALUES({0},
                {1},N'{2}',{3},{4})",hdx.IDXUAT1,hdx.IDKHO1,hdx.SoHDXuat1,hdx.SoLuong1,hdx.DonGia1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        // Lấy thông tin có mã ma, trả về null nếu không thấy
        public static DTO_CTHDXUAT TimTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"SELECT * FROM CT_HOADON_XUAT WHERE IDXUAT={0}", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            DTO_CTHDXUAT hdx = new DTO_CTHDXUAT();
            hdx.IDXUAT1 = int.Parse(dt.Rows[0]["IDXUAT"].ToString());
            hdx.IDKHO1 = int.Parse(dt.Rows[0]["IDKHO"].ToString());
            hdx.SoHDXuat1 = dt.Rows[0]["SO_HD_XUAT"].ToString();
            hdx.SoLuong1 = int.Parse(dt.Rows[0]["SOLUONG_XUAT"].ToString());
            hdx.DonGia1 = int.Parse(dt.Rows[0]["DONGIA_XUAT"].ToString());
            DataProvider.DongKetNoi(con);
            return hdx;
        }
        // Cập nhật thông tin 
        public bool CapNhatHangHoa(DTO_HangHoa hh)
        {
            string sTruyVan = string.Format(@"UPDATE HANGHOA SET MALOAI=N'{0}',TENHH=N'{1}',DONVITINH=N'{2}',XUATXU=N'{3}' where MAHH=N'{4}'",
                hh.MaLoai1, hh.TenHH1, hh.DVT1, hh.XuatXu1, hh.MaHH1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        // Xóa thông tin 
        public static bool XoaHangHoa(DTO_HangHoa hh)
        {
            string sTruyVan = string.Format(@"DELETE FROM HANGHOA WHERE MAHH=N'{0}'", hh.MaHH1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
