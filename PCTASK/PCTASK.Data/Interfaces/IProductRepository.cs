using System.Collections.Generic;
using System.Linq;
using PCTASK.Data.Entities;

namespace PCTASK.Data.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IQueryable<Product> GetAllProducts(double? startPrice = null, double? endPrice = null, string name = null);
    }
}