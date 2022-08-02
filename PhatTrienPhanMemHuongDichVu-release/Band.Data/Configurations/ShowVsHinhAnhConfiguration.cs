using Band.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Band.Data.Configurations
{
    public class ShowVsHinhAnhConfiguration : IEntityTypeConfiguration<ShowVsHinhAnh>
    {
        public void Configure(EntityTypeBuilder<ShowVsHinhAnh> builder)
        {
            builder.ToTable("SHOW_HINHANH");
            builder.HasKey(x => new { x.IdAnh, x.IdShow });
            builder.HasOne(x => x.Show).WithMany(sh => sh.DsShowVsHinhAnh).HasForeignKey(x => x.IdShow);
            builder.HasOne(x => x.HinhAnh).WithMany(sh => sh.DsShowVsHinhAnh).HasForeignKey(x => x.IdAnh);
        }
    }
}