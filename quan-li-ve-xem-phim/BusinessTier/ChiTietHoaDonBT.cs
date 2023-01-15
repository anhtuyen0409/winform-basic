using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBanVeXemPhim.DataContext;
using AppBanVeXemPhim.DataTier;
using AppBanVeXemPhim.DTO;

namespace AppBanVeXemPhim.BusinessTier
{
    class ChiTietHoaDonBT
    {
        private readonly ChiTietHoaDonDT chiTietHoaDonDT;
        public ChiTietHoaDonBT()
        {
            chiTietHoaDonDT = new ChiTietHoaDonDT();
        }

        public bool LuuChiTietHoaDon(CHITIETHOADON chiTietHoaDon, out string error)
        {

            try
            {
                return chiTietHoaDonDT.LuuChiTietHoaDon(chiTietHoaDon, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        internal List<ChiTietHoaDonDTO> LayDanhSachTheoMaHoaDon(int maHoaDonDangChon)
        {
            return chiTietHoaDonDT.LayDanhSachTheoMaHoaDon(maHoaDonDangChon);
        }

        internal List<int> LayDanhSachGheDaMuaTheoNgay(DateTime ngay)
        {
            return chiTietHoaDonDT.LayDanhSachGheDaMuaTheoNgay(ngay);
        }
    }
}
