using Band.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Band.Data.Configurations
{
    internal class LoaiVeConfiguration : IEntityTypeConfiguration<LoaiVe>
    {
        public void Configure(EntityTypeBuilder<LoaiVe> builder)
        {
            builder.ToTable("LOAIVE");
            builder.HasKey(x => x.IdLoaiVe);
            builder.Property(x => x.IdLoaiVe).UseIdentityColumn();
            builder.Property(x => x.TenLoai).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ChiTiet).HasColumnType("ntext").IsRequired(false);

        }
    }
}