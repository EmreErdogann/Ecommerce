using Ecommerce.Data.Interfaces;
using Ecommerce.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Implementaions
{
    public class EfCartRepository : EfRepository<Cart>, ICartRepository
    {
        public EfCartRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task Cart(string userId)
        {
            await _dbContext.AddAsync(new Cart
            {
                UserId = userId,
            });
        }

        public async Task<dynamic> GetCarts(Expression<Func<Cart, bool>> predicate, params Expression<Func<Cart, object>>[] includeProperties)
        {
            Cart firstResult = await GetAsync(predicate,includeProperties);
            return firstResult;
        }
    }
}
