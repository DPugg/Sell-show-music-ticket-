using Band.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Band.Data.Configurations
{
    internal class ShowConfiguration : IEntityTypeConfiguration<Show>
    {
        public void Configure(EntityTypeBuilder<Show> builder)
        {
            builder.ToTable("SHOW");
            builder.HasKey(x => x.IdShow);
            builder.Property(x => x.IdShow).UseIdentityColumn();
            builder.Property(x => x.TenShow).HasMaxLength(255).IsRequired();
            builder.Property(x => x.ThoiDiemBieuDien).IsRequired();
            builder.Property(x => x.ThoiDiemMoBan).IsRequired();
            builder.Property(x => x.DiaDiem).HasMaxLength(255).IsRequired();

            builder.HasOne(x => x.NhomNhac).WithMany(x => x.DsShow).HasForeignKey(x => x.IdNhom).IsRequired();
        }
    }
}