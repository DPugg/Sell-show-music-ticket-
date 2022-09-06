using Band.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Band.Data.Configurations
{
    internal class AnhThanhVienConfiguration : IEntityTypeConfiguration<AnhThanhVien>
    {
        public void Configure(EntityTypeBuilder<AnhThanhVien> builder)
        {
            builder.ToTable("ANHTHANHVIEN");
            builder.HasKey(x => new { x.IdAnh, x.IdThanhVien });
            builder.HasOne(x => x.ThanhVien).WithMany(th => th.DsAnhThanhVien).HasForeignKey(x => x.IdThanhVien);
            builder.HasOne(x => x.HinhAnh).WithMany(th => th.DsAnhThanhVien).HasForeignKey(x => x.IdAnh);
        }
    }
}