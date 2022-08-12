using Band.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Band.Data.Configurations
{
    public class ThanhVienVsVaiTroConfiguration : IEntityTypeConfiguration<ThanhVienVsVaiTro>
    {
        public void Configure(EntityTypeBuilder<ThanhVienVsVaiTro> builder)
        {
            builder.ToTable("THANHVIEN_VAITRO");
            builder.HasKey(x => new { x.IdThanhVien, x.IdVaiTro });
            builder.HasOne(x => x.ThanhVien).WithMany(tv => tv.DsThanhVienVsVaiTro).HasForeignKey(tv => tv.IdThanhVien);
            builder.HasOne(x => x.VaiTro).WithMany(tv => tv.DsThanhVienVsVaiTro).HasForeignKey(tv => tv.IdVaiTro);
        }
    }
}
