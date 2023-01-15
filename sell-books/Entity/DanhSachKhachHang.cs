using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBanSach.Entity
{
    public class DanhSachKhachHang
    {
        List<KhachHang> danhSachKhachHang = new List<KhachHang>();

        public List<KhachHang> KhachHangs
        {
            get
            {
                return danhSachKhachHang;
            }
        }

        //nếu khách hàng có mua sách thì thêm khách hàng đó vào danh sách
        public void Mua(KhachHang kh)
        {
            danhSachKhachHang.Add(kh);
        }

        public int TongSoKhachHang
        {
            get
            {
                return danhSachKhachHang.Count;
            }
        }

        public int TongSoKhachHangLaSinhVien
        {
            get
            {
                int soSinhVien = 0;
                foreach(KhachHang kh in danhSachKhachHang)
                {
                    if(kh.LaSinhVien == true)
                    {
                        soSinhVien++;
                    }
                }
                return soSinhVien;
            }
        }

        public double TongDoanhThu
        {
            get
            {
                double sum = 0;
                foreach(KhachHang kh in danhSachKhachHang)
                {
                    sum += kh.TinhTien;
                }
                return sum;
            }
        }
    }
}
