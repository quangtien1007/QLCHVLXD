using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_TaiKhoan
    {

        private string sTen;

        public string STen
        {
            get { return sTen; }
            set { sTen = value; }
        }
        private string sMatKhau;

        public string SMatKhau
        {
            get { return sMatKhau; }
            set { sMatKhau = value; }
        }
        private int iQuyen;

        public int IQuyen
        {
            get { return iQuyen; }
            set { iQuyen = value; }
        }
    }
}
