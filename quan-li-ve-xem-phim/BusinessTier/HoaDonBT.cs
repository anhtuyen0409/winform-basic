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
    class HoaDonBT
    {
        private readonly HoaDonDT hoaDonDT;
        public HoaDonBT()
        {
            hoaDonDT = new HoaDonDT();
        }

        public bool LuuHoaDon(HOADON hoaDon, out string error)
        {
           
            try
            { 
                return hoaDonDT.LuuHoaDon(hoaDon, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        internal List<HoaDonDTO> LayDanhSachHoaDon()
        {
            return hoaDonDT.LayDanhSachHoaDon();
        }
    }
}
