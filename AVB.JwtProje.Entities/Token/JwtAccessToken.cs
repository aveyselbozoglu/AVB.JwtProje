using System;
using System.Collections.Generic;
using System.Text;
using AVB.JwtProje.Entities.Interfaces;

namespace AVB.JwtProje.Entities.Token
{
    public class JwtAccessToken : IToken
    {
        public string Token { get; set; }

    }
}
