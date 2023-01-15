using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBanVeXemPhim.DataContext;
using AppBanVeXemPhim.DataTier;

namespace AppBanVeXemPhim.BusinessTier
{
    class GheBT
    {
        private readonly GheDT gheDT;
        public GheBT()
        {
            gheDT = new GheDT();
        }
        public double LayGiaGheTheoSoGhe(int soGhe)
        {
            return gheDT.LayGiaTienTheoSoGhe(soGhe);
        }

        internal GHE LayGheTheoSoGhe(int soGhe)
        {
            return gheDT.LayGheTheoSoGhe(soGhe);
        }
    }
}
