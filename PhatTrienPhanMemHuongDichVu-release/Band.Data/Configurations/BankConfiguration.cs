using Band.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Band.Data.Configurations
{
    class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.ToTable("NGANHANG");
            builder.HasKey(x => x.IdTaiKhoan);
            builder.Property(x => x.IdTaiKhoan).HasColumnType("varchar").HasMaxLength(15);
            builder.Property(x => x.MatKhau).HasColumnType("varchar").IsRequired().HasMaxLength(330);
            builder.Property(x => x.SoDu).HasColumnType("numeric").IsRequired().HasDefaultValue(0);
            builder.HasIndex(x => x.IdTaiKhoan).IsUnique();

        }
    }

}
