using Microsoft.EntityFrameworkCore;
using NerdStore.Catalog.Domain;
using NerdStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogContext _catalogContext;

        public ProductRepository(CatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public IUnitOfWork UnitOfWork => _catalogContext;

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _catalogContext.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetById(Guid id)
        {
            return await _catalogContext.Products.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Product>> GetByCategory(int codeNumber)
        {
            return await _catalogContext.Products.AsNoTracking().Include(p => p.Category).Where(c => c.Category.CodeNumber == codeNumber).ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _catalogContext.Categories.AsNoTracking().ToListAsync();
        }

        public void Add(Product product)
        {
            _catalogContext.Products.Add(product);
        }

        public void Update(Product product)
        {
            _catalogContext.Products.Update(product);
        }

        public void Add(Category category)
        {
            _catalogContext.Categories.Add(category);
        }

        public void Update(Category category)
        {
            _catalogContext.Categories.Update(category);
        }

        public void Dispose()
        {
            _catalogContext?.Dispose();
        }
    }
}
