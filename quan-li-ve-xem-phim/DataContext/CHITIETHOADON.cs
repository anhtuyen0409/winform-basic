namespace AppBanVeXemPhim.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETHOADON")]
    public partial class CHITIETHOADON
    {
        [Key]
        public int MaChiTietHoaDon { get; set; }

        public int MaGhe { get; set; }

        public int MaHoaDon { get; set; }

        public virtual GHE GHE { get; set; }

        public virtual HOADON HOADON { get; set; }
    }
}
