using Band.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Band.Data.Configurations
{
    internal class HinhAnhConfiguration : IEntityTypeConfiguration<HinhAnh>
    {
        public void Configure(EntityTypeBuilder<HinhAnh> builder)
        {
            builder.ToTable("HINHANH");
            builder.HasKey(x => x.IdAnh);
            builder.Property(x => x.IdAnh).UseIdentityColumn();
            builder.Property(x => x.Anh).HasColumnType("image").IsRequired();
            builder.HasOne(x => x.LoaiAnh).WithMany(x => x.DsHinhAnh).HasForeignKey(x => x.IdLoai).IsRequired();
        }
    }
}