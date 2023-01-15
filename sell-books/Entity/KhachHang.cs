using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBanSach.Entity
{
    public class KhachHang
    {
        //mỗi cuốn sách đồng giá 20000
        const double GIA = 20000;
        public string TenKhachHang { get; set; }
        public int SoLuongMua { get; set; }
        public bool LaSinhVien { get; set; }
        public double TinhTien
        {
            get
            {
                if(LaSinhVien == true)
                {
                    return GIA * SoLuongMua * 0.95;
                }
                else
                {
                    return GIA * SoLuongMua;
                }
            }
        }
    }
}
