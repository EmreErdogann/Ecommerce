using Ecommerce.Data.Context;
using Ecommerce.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Implementaions
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly EcommerceDataContext _context;
        private readonly EfProductRepository _efProductRepository;
        private readonly EfCategoryRepository _efCategoryRepository;
        private readonly EfCartRepository _efCartRepository;
        public UnitOfWork(EcommerceDataContext context)
        {
            _context = context;
        }

        public IProductRepository Products => _efProductRepository ?? new EfProductRepository(_context);

        public ICategoryRepository Categories => _efCategoryRepository ?? new EfCategoryRepository(_context);
        public ICartRepository Carts => _efCartRepository ?? new EfCartRepository(_context);
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();

        }
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }


    }
}
