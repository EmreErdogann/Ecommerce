using Ecommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task Cart(string userId);

        Task<dynamic> GetCarts(Expression<Func<Cart, bool>> predicate, params Expression<Func<Cart, object>>[] includeProperties);
    }
}
