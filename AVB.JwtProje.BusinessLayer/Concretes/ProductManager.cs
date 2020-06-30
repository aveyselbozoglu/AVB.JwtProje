using System;
using System.Collections.Generic;
using System.Text;
using AVB.JwtProje.BusinessLayer.Interfaces;
using AVB.JwtProje.DataAccessLayer.Interfaces;
using AVB.JwtProje.Entities.Concrete;

namespace AVB.JwtProje.BusinessLayer.Concretes
{
    public class ProductManager : GenericManager<Product> ,IProductService
    {
        public ProductManager(IGenericDal<Product> genericDal) : base(genericDal)
        {
        }
    }
}
