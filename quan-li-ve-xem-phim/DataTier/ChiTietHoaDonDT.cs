using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBanVeXemPhim.DataContext;
using AppBanVeXemPhim.DTO;

namespace AppBanVeXemPhim.DataTier
{
    class ChiTietHoaDonDT
    {
        public bool LuuChiTietHoaDon(CHITIETHOADON chiTietHoaDon, out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbContext = new AppBanVeModel())
                {
                    dbContext.CHITIETHOADONs.Add(chiTietHoaDon);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        internal List<ChiTietHoaDonDTO> LayDanhSachTheoMaHoaDon(int maHoaDonDangChon)
        {
            using (var dbContext = new AppBanVeModel())
            {
                return (from ct in dbContext.CHITIETHOADONs
                        where ct.MaHoaDon == maHoaDonDangChon
                        select new ChiTietHoaDonDTO()
                        {
                            MaHoaDon = ct.MaHoaDon,
                            SoGhe = ct.GHE.SoGhe,
                            TienGhe = ct.GHE.HANGGHE.GiaTien
                        }).ToList();
            }
        }

        internal List<int> LayDanhSachGheDaMuaTheoNgay(DateTime ngay)
        {
            using (var dbContext = new AppBanVeModel())
            {
                return dbContext.CHITIETHOADONs.Where(ct => EntityFunctions.TruncateTime(ct.HOADON.NgayMua) ==
                 EntityFunctions.TruncateTime(ngay)).Select(ct => ct.GHE.SoGhe).ToList();
            }
        }
    }
}
