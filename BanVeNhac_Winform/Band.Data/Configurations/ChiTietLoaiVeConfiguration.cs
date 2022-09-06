using Band.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Band.Data.Configurations
{
    public class ChiTietLoaiVeConfiguration : IEntityTypeConfiguration<ChiTietLoaiVe>
    {
        public void Configure(EntityTypeBuilder<ChiTietLoaiVe> builder)
        {
            builder.ToTable("CHITIETLOAIVE");
            builder.HasKey(x => new { x.IdLoaiVe, x.IdShow});
            builder.HasOne(x => x.LoaiVe).WithMany(sv => sv.DsChiTietLoaiVe).HasForeignKey(x => x.IdLoaiVe);
            builder.HasOne(x => x.Show).WithMany(sv => sv.DsChiTietLoaiVe).HasForeignKey(x => x.IdShow);
            builder.Property(x => x.Gia).HasColumnType("numeric").IsRequired();
            builder.Property(x => x.SoLuongBanRa).IsRequired();
            builder.Property(x => x.ConLai).IsRequired();
            builder.Property(x => x.IdShowVsLoaiVe).UseIdentityColumn();
        }
    }
}