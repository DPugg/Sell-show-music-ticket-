using Band.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Band.Data.Configurations
{
    internal class ThanhVienVsHinhAnhConfiguration : IEntityTypeConfiguration<ThanhVienVsHinhAnh>
    {
        public void Configure(EntityTypeBuilder<ThanhVienVsHinhAnh> builder)
        {
            builder.ToTable("ANHTHANHVIEN");
            builder.HasKey(x => new { x.IdAnh, x.IdThanhVien });
            builder.HasOne(x => x.ThanhVien).WithMany(th => th.DsThanhVienVsHinhAnh).HasForeignKey(x => x.IdThanhVien);
            builder.HasOne(x => x.HinhAnh).WithMany(th => th.DsThanhVienVsHinhAnh).HasForeignKey(x => x.IdAnh);
        }
    }
}