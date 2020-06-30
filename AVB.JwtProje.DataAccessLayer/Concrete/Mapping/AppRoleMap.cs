using System;
using System.Collections.Generic;
using System.Text;
using AVB.JwtProje.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AVB.JwtProje.DataAccessLayer.Concrete.Mapping
{
    public class AppRoleMap : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();


            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.HasIndex(x => x.Name);

            builder.HasMany(x => x.AppUserRoles).WithOne(x => x.AppRole).HasForeignKey(x => x.AppRoleId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
