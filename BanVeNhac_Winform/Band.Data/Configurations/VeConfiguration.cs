using Band.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Band.Model
{
    public class VeConfiguration : IEntityTypeConfiguration<Ve>
    {
        public void Configure(EntityTypeBuilder<Ve> builder)
        {
            builder.ToTable("VE");
            builder.HasKey(x => x.MaSoVe);
            builder.Property(x => x.MaSoVe).HasMaxLength(25).HasColumnType("varchar").IsRequired();
            builder.HasOne(x => x.ChiTietLoaiVe).WithMany(x => x.DsVe).HasForeignKey(x => x.IdShowVsLoaiVe).HasPrincipalKey(x => x.IdShowVsLoaiVe);            /*builder.HasIndex(x => x.MaSoVe).IsUnique();*/
            builder.HasOne(x => x.HoaDon).WithMany(x => x.DsVe).HasForeignKey(x => x.IdHoaDon).HasPrincipalKey(x => x.IdHoaDon);            /*builder.HasIndex(x => x.MaSoVe).IsUnique();*/


        }
    }
}