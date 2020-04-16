using System;
using System.Collections.Generic;
using PCTASK.Domain.Models.Product;

namespace PCTASK.Domain.Interfaces
{
    public interface IProductService : IDisposable
    {
        void AddProduct(CreateProductViewModel model);
        void UpdateProduct(UpdateProductViewModel model);
        void RemoveProduct(int id);
        ProductViewModel GetProduct(int id);
        IList<ProductViewModel> GetAllProducts(ProductFilter filter);
    }
}