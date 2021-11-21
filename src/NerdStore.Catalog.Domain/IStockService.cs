using System;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Domain
{
    public interface IStockService : IDisposable
    {
        Task<bool> StockAdd(Guid productId, int quantity);
        Task<bool> StockDebit(Guid productId, int quantity);
    }
}