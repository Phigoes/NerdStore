using NerdStore.Catalog.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Application.Services
{
    public interface IProductAppService : IDisposable
    {
        Task<IEnumerable<ProductViewModel>> GetByCategory(int codeNumber);
        Task<ProductViewModel> GetById(Guid id);
        Task<IEnumerable<ProductViewModel>> GetAll();
        Task<IEnumerable<CategoryViewModel>> GetCategories();

        Task Add(ProductViewModel product);
        Task Update(ProductViewModel product);

        Task<ProductViewModel> StockDebit(Guid id, int quantity);
        Task<ProductViewModel> StockAdd(Guid id, int quantity);
    }
}
