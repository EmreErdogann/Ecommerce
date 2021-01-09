using Ecommerce.Data.Interfaces;
using Ecommerce.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Data.Implementaions
{
    public class EfProductRepository : EfRepository<Product>, IProductRepository
    {
        public EfProductRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
