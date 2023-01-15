using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBanVeXemPhim.DataContext;
using AppBanVeXemPhim.DTO;

namespace AppBanVeXemPhim.DataTier
{
    class HoaDonDT
    {
        public bool LuuHoaDon(HOADON hoaDon, out string error)
        {
            error = string.Empty;
            try
            {
                using(var dbContext = new AppBanVeModel())
                {
                    dbContext.HOADONs.Add(hoaDon);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        internal List<HoaDonDTO> LayDanhSachHoaDon()
        {
            using (var dbContext = new AppBanVeModel())
            {
                return (from hd in dbContext.HOADONs
                        select new HoaDonDTO()
                        {
                            MaHoaDon = hd.MaHoaDon,
                            NgayMua = hd.NgayMua,
                            TongTien = hd.TongTien
                        }).ToList();
            }
        }
    }
}
