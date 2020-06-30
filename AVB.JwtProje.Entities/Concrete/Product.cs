using System;
using System.Collections.Generic;
using System.Text;
using AVB.JwtProje.Entities.Interfaces;

namespace AVB.JwtProje.Entities.Concrete
{
    public class Product :ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
