using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AVB.JwtProje.DataAccessLayer.Concrete.EntityFrameworkCore;
using AVB.JwtProje.DataAccessLayer.Interfaces;
using AVB.JwtProje.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace AVB.JwtProje.DataAccessLayer.Concrete.Repositories
{
    public class EfAppUserRepository : EfGenericRepository<AppUser>,IAppUserDal
    {

        public async Task<List<AppRole>> GetRolesByUserName(string username)
        {
            await using var context = new DatabaseContext();

            return await context.AppUsers.Join(context.AppUserRoles, u => u.Id, ur => ur.AppUserId, (user, userRole) => new
            {
                user= user,
                userRole = userRole
            }).Join(context.AppRoles,two=> two.userRole.AppRoleId,r=> r.Id, (twoTable,role)=> new
            {
                user= twoTable.user,
                userRole = twoTable.userRole,
                role=role
            }).Where(x=> x.user.UserName==username).Select(x=> new AppRole
            {
                Id = x.role.Id,
                Name = x.role.Name
            }).ToListAsync();

        }
    }
}
