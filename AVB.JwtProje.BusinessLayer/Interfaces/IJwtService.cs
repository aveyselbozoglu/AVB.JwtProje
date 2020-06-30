using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using AVB.JwtProje.Entities.Concrete;

namespace AVB.JwtProje.BusinessLayer.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(AppUser appUser, List<AppRole> roles);
        
    }
}
