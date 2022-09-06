using Band.Data.Configurations;
using Band.Data.Entities;
using Band.Model;
using Microsoft.EntityFrameworkCore;

namespace Band.Data.EF
{
    public partial class BandDbContext : DbContext
    { 
        /*public BandDbContext()
            : base("name=BandConnection")
        {
        }*/

        public BandDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<HoaDon> HoaDonDbo { get; set; }
        public virtual DbSet<HinhAnh> HinhAnhDbo { get; set; }
        public virtual DbSet<LoaiAnh> LoaiAnhDbo { get; set; }
        public virtual DbSet<LoaiVe> LoaiVeDbo { get; set; }
        public virtual DbSet<NhomNhac> NhomNhacDbo { get; set; }
        public virtual DbSet<Show> ShowDbo { get; set; }
        public virtual DbSet<ShowVsHinhAnh> ShowVsHinhAnhDbo { get; set; }
        public virtual DbSet<ChiTietLoaiVe> ShowVsLoaiVeDbo { get; set; }
        public virtual DbSet<ThanhVien> ThanhVienDbo { get; set; }
        public virtual DbSet<AnhThanhVien> ThanhVienVsHinhAnhDbo { get; set; }
        public virtual DbSet<ThanhVienVsVaiTro> ThanhVienVsVaiTroDbo { get; set; }
        public virtual DbSet<VaiTro> VaiTroDbo { get; set; }
        public virtual DbSet<Ve> VeDbo { get; set; }
        public virtual DbSet<KhachHang> BankDbo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HoaDonConfiguration());
            modelBuilder.ApplyConfiguration(new ThanhVienConfiguration());
            modelBuilder.ApplyConfiguration(new VaiTroConfiguration());
            modelBuilder.ApplyConfiguration(new ThanhVienVsVaiTroConfiguration());
            modelBuilder.ApplyConfiguration(new HinhAnhConfiguration());
            modelBuilder.ApplyConfiguration(new AnhThanhVienConfiguration());
            modelBuilder.ApplyConfiguration(new NhomNhacConfiguration());
            modelBuilder.ApplyConfiguration(new LoaiAnhConfiguration());
            modelBuilder.ApplyConfiguration(new ShowConfiguration());
            modelBuilder.ApplyConfiguration(new ShowVsHinhAnhConfiguration());
            modelBuilder.ApplyConfiguration(new VeConfiguration());
            modelBuilder.ApplyConfiguration(new LoaiVeConfiguration());
            modelBuilder.ApplyConfiguration(new ChiTietLoaiVeConfiguration());
            modelBuilder.ApplyConfiguration(new KhachHangConfiguration());
        
        //    modelBuilder.Entity<ChiTietHoaDon>().HasNoKey();
        

        //base.OnModelCreating(modelBuilder);


        /*modelBuilder.Entity<ChiTietVeShow>()
            .Property(e => e.GIA)
            .HasPrecision(18, 0);

        modelBuilder.Entity<HoaDon>()
            .Property(e => e.SDT)
            .IsFixedLength()
            .IsUnicode(false);

        modelBuilder.Entity<HoaDon>()
            .HasMany(e => e.Ve)
            .WithRequired(e => e.HoaDon)
            .WillCascadeOnDelete(false);

        modelBuilder.Entity<KhoAnh>()
            .HasMany(e => e.ThanhVien)
            .WithMany(e => e.KhoAnh)
            .Map(m => m.ToTable("AnhThanhVien").MapLeftKey("IDAnh").MapRightKey("IDThanhVien"));

        modelBuilder.Entity<KhoAnh>()
            .HasMany(e => e.Shows)
            .WithMany(e => e.KhoAnh)
            .Map(m => m.ToTable("QuangCaoShow").MapLeftKey("IDAnh").MapRightKey("IDShow"));

        modelBuilder.Entity<LoaiAnh>()
            .HasMany(e => e.KhoAnh)
            .WithRequired(e => e.LoaiAnh)
            .WillCascadeOnDelete(false);

        modelBuilder.Entity<LoaiVe>()
            .Property(e => e.ChiTiet)
            .IsUnicode(false);

        modelBuilder.Entity<LoaiVe>()
            .HasMany(e => e.ChiTietVeShow)
            .WithRequired(e => e.LoaiVe)
            .WillCascadeOnDelete(false);

        modelBuilder.Entity<NhomNhac>()
            .Property(e => e.ChiTiet)
            .IsUnicode(false);

        modelBuilder.Entity<NhomNhac>()
            .Property(e => e.Spotify)
            .IsUnicode(false);

        modelBuilder.Entity<NhomNhac>()
            .Property(e => e.AppleMusic)
            .IsUnicode(false);

        modelBuilder.Entity<NhomNhac>()
            .Property(e => e.Youtube)
            .IsUnicode(false);

        modelBuilder.Entity<Show>()
            .HasMany(e => e.ChiTietVeShow)
            .WithRequired(e => e.Shows)
            .WillCascadeOnDelete(false);

        modelBuilder.Entity<ThanhVien>()
            .Property(e => e.TieuSu)
            .IsUnicode(false);

        modelBuilder.Entity<ThanhVien>()
            .Property(e => e.Instagram)
            .IsUnicode(false);

        modelBuilder.Entity<ThanhVien>()
            .Property(e => e.Twitter)
            .IsUnicode(false);

        modelBuilder.Entity<ThanhVien>()
            .HasMany(e => e.VaiTro)
            .WithMany(e => e.ThanhVien)
            .Map(m => m.ToTable("VaiTroThanhVien").MapLeftKey("IDThanhVien").MapRightKey("IDVaiTro"));*/

    }
       
    }

}