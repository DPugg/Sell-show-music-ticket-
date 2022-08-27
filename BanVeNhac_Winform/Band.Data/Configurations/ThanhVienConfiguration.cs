using Band.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Band.Data.Configurations
{
    public class ThanhVienConfiguration : IEntityTypeConfiguration<ThanhVien>
    {
        public void Configure(EntityTypeBuilder<ThanhVien> builder)
        {
            builder.ToTable("THANHVIEN");
            builder.HasKey(x => x.IdThanhVien);
            builder.Property(x => x.IdThanhVien).UseIdentityColumn();
            builder.Property(x => x.NgheDanh).HasMaxLength(50).IsRequired();
            builder.Property(x => x.TenKhaiSinh).HasMaxLength(50).IsRequired();
            builder.Property(x => x.NgaySinh).HasColumnType("date").IsRequired();
            builder.Property(x => x.QuocTich).HasMaxLength(50).IsRequired();
            builder.Property(x => x.DebutDate).HasColumnType("date").IsRequired();
            builder.Property(x => x.TieuSu).HasColumnType("ntext");
            builder.Property(x => x.Instagram).HasMaxLength(500);
            builder.Property(x => x.Twitter).HasMaxLength(500);
            builder.Property(x => x.TrangThai).HasMaxLength(50);

        }
    }
}
