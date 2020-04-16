using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PCTASK.Data.Entities;
using PCTASK.Data.Interfaces;

namespace PCTASK.Data.Services
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ProductContext _context;
        public ProductRepository(ProductContext context)
            : base(context)
        {
            _context = context;
        }

        public IQueryable<Product> GetAllProducts(double? startPrice = null, double? endPrice = null, string name = null)
        {
            return _context.Products.Where(q => (string.IsNullOrWhiteSpace(name) || q.Name.Contains(name)) &&
                                                      (!startPrice.HasValue || q.Price >= startPrice) &&
                                                      (!endPrice.HasValue || q.Price <= endPrice)).AsQueryable();
        }
    }

}
