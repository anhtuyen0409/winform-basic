using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AppBanVeXemPhim.DataContext
{
    public partial class AppBanVeModel : DbContext
    {
        public AppBanVeModel()
            : base("name=AppBanVeModel1")
        {
        }

        public virtual DbSet<CHITIETHOADON> CHITIETHOADONs { get; set; }
        public virtual DbSet<GHE> GHEs { get; set; }
        public virtual DbSet<HANGGHE> HANGGHEs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<NGUOI_DUNG> NGUOI_DUNG { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GHE>()
                .HasMany(e => e.CHITIETHOADONs)
                .WithRequired(e => e.GHE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HANGGHE>()
                .Property(e => e.TenHangGhe)
                .IsFixedLength();

            modelBuilder.Entity<HANGGHE>()
                .HasMany(e => e.GHEs)
                .WithRequired(e => e.HANGGHE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOADON>()
                .HasMany(e => e.CHITIETHOADONs)
                .WithRequired(e => e.HOADON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NGUOI_DUNG>()
                .Property(e => e.TaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOI_DUNG>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);
        }
    }
}
