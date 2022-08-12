using Band.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Band.Data.Configurations
{
    class VaiTroConfiguration : IEntityTypeConfiguration<VaiTro>
    {
        public void Configure(EntityTypeBuilder<VaiTro> builder)
        {
            builder.ToTable("VAITRO");
            builder.HasKey(x => x.IdVaiTro);
            builder.Property(x => x.IdVaiTro).UseIdentityColumn();
            builder.Property(x => x.TenVaiTro).IsRequired();
            builder.HasAlternateKey(x => x.TenVaiTro);
        }
    }
}
