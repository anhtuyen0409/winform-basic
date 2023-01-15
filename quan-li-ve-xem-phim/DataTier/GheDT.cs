using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBanVeXemPhim.DataContext;

namespace AppBanVeXemPhim.DataTier
{
    class GheDT
    {
        public double LayGiaTienTheoSoGhe(int soGhe)
        {
            using (var dbContext = new AppBanVeModel())
            {
                return dbContext.GHEs.Where(s => s.SoGhe == soGhe).FirstOrDefault().HANGGHE.GiaTien;
            }
        }

        internal GHE LayGheTheoSoGhe(int soGhe)
        {
            using (var dbContext = new AppBanVeModel())
            {
                return dbContext.GHEs.Include("HANGGHE").Where(s => s.SoGhe == soGhe).FirstOrDefault();
            }
        }
    }
}
