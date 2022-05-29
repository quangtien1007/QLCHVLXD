using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class BUS_TaiKhoan
    {
        
        public static DTO_TaiKhoan LayTaiKhoan1(string ten, string matkhau)
        {
            MD5 md5Hash = MD5.Create();
            string matkhauMH = BUS_TaiKhoan.GetMd5Hash(md5Hash, matkhau);
            return DAO_TaiKhoan.LayTaiKhoan(ten, matkhauMH);
        }
        // Hàm mã hóa
        // Tham khảo tại https://msdn.microsoft.com/enus/library/system.security.cryptography.md5.aspx*/
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        public static List<DTO_TaiKhoan> LayTKhoan()
        {
            return DAO_TaiKhoan.LayTKhoan();
        }
        public static bool ThemTaiKhoan(DTO_TaiKhoan tk)
        {
            return DAO_TaiKhoan.ThemTaiKhoan(tk);
        }
        public static bool XoaTaiKhoan(DTO_TaiKhoan tk)
        {
            return DAO_TaiKhoan.XoaTaiKhoan(tk);
        }
        public static bool SuaTaiKhoan(DTO_TaiKhoan tk)
        {
            return DAO_TaiKhoan.SuaTaiKhoan(tk);
        }
    }
}
