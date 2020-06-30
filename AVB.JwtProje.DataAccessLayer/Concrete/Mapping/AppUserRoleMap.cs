using System;
using System.Collections.Generic;
using System.Text;
using AVB.JwtProje.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AVB.JwtProje.DataAccessLayer.Concrete.Mapping
{
    public class AppUserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();


            //builder.HasKey(x => new {x.AppUserId, x.AppRoleId});

            builder.HasIndex(x => new {x.AppUserId, x.AppRoleId}).IsUnique();


            builder.HasOne(x => x.AppUser).WithMany(x => x.AppUserRoles).HasForeignKey(x=> x.AppUserId);


            builder.HasOne(x => x.AppRole).WithMany(x => x.AppUserRoles).HasForeignKey(x => x.AppRoleId);
        }
    }
}
