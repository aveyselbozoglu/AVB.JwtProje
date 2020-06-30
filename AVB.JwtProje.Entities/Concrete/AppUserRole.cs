using System;
using System.Collections.Generic;
using System.Text;
using AVB.JwtProje.Entities.Interfaces;

namespace AVB.JwtProje.Entities.Concrete
{
    public class AppUserRole : ITable
    {

        public int Id { get; set; }


        public int AppRoleId { get; set; }
        public AppRole AppRole { get; set; }


        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
