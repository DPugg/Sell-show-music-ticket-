using Band.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Band.Data.Configurations
{
    class HoaDonConfiguration : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.ToTable("HOADON");
            builder.HasKey(x => x.IdHoaDon);
            builder.Property(x => x.IdHoaDon).UseIdentityColumn();
            builder.Property(x => x.SoLuong).HasDefaultValue(1).IsRequired();
            builder.Property(x => x.SDT).IsUnicode(false).IsRequired(true).HasMaxLength(10);
            builder.Property(x => x.NgayGiaoDich).IsRequired();
            builder.HasOne(x => x.KhachHang).WithMany(x => x.DsHoaDon).HasForeignKey(x => x.SDT).IsRequired();
        }
    }
}
