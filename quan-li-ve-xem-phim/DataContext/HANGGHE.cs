namespace AppBanVeXemPhim.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HANGGHE")]
    public partial class HANGGHE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HANGGHE()
        {
            GHEs = new HashSet<GHE>();
        }

        [Key]
        public int MaHangGhe { get; set; }

        [Required]
        [StringLength(1)]
        public string TenHangGhe { get; set; }

        public double GiaTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GHE> GHEs { get; set; }
    }
}
