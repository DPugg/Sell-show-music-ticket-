using Band.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Band.Model
{
    public class LoaiAnhConfiguration : IEntityTypeConfiguration<LoaiAnh>
    {
        public void Configure(EntityTypeBuilder<LoaiAnh> builder)
        {
            builder.ToTable("LOAIANH");
            builder.HasKey(x => x.IdLoai);
            builder.Property(x => x.IdLoai).UseIdentityColumn();
            builder.Property(x => x.Loai).HasMaxLength(50).IsRequired();


        }
    }
}