using Band.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Band.Data.Configurations
{
    class KhachHangConfiguration : IEntityTypeConfiguration<KhachHang>
    {
        public void Configure(EntityTypeBuilder<KhachHang> builder)
        {
            builder.ToTable("KHACHHANG");
            builder.HasKey(x => x.SDT);
            builder.Property(x => x.Email).HasColumnType("varchar").IsRequired().HasMaxLength(50);
            builder.Property(x => x.TenKhachHang).HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(x => x.SoDu).HasColumnType("numeric").IsRequired().HasDefaultValue(0);
            builder.Property(x => x.SoTaiKhoan).HasColumnType("varchar").IsRequired().HasMaxLength(12);
            builder.Property(x => x.NganHang).HasColumnType("nvarchar").HasMaxLength(50);
            builder.HasIndex(x => x.SDT).IsUnique();

        }
    }

}
