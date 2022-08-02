using Band.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Band.Data.Configurations
{
    internal class NhomNhacConfiguration : IEntityTypeConfiguration<NhomNhac>
    {
        public void Configure(EntityTypeBuilder<NhomNhac> builder)
        {
            builder.ToTable("NHOMNHAC");
            builder.HasKey(x => x.IdNhom);
            builder.Property(x => x.IdNhom).UseIdentityColumn();
            builder.Property(x => x.TenNhom).HasMaxLength(50).IsRequired().HasColumnType("nvarchar");
            builder.Property(x => x.DebutDate).HasColumnType("date");
            builder.Property(x => x.CongTy).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ChiTiet).HasColumnType("ntext");
            builder.Property(x => x.Spotify).HasColumnType("varchar").HasMaxLength(500);
            builder.Property(x => x.AppleMusic).HasColumnType("varchar").HasMaxLength(500);
            builder.Property(x => x.Youtube).HasColumnType("varchar").HasMaxLength(500);
            builder.Property(x => x.Logo).HasColumnType("image").IsRequired();

        }
    }
}