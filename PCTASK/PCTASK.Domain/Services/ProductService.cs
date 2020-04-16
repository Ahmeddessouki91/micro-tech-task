using System;
using System.Collections.Generic;
using AutoMapper;
using PCTASK.Data;
using PCTASK.Data.Entities;
using PCTASK.Data.Interfaces;
using PCTASK.Domain.Interfaces;
using PCTASK.Domain.Models.Product;

namespace PCTASK.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public ProductService(IProductRepository repo, IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
            _repo = repo;
        }

        public void AddProduct(CreateProductViewModel model)
        {
            var product = _mapper.Map<Product>(model);
            product.CreatedAt = DateTime.UtcNow;

            _repo.Add(product);
            _uow.Commit();
        }

        public IList<ProductViewModel> GetAllProducts(ProductFilter filter)
        {
            var products = _repo.GetAllProducts(filter.StartPrice, filter.EndPrice, filter.Name);

            return _mapper.Map<IList<ProductViewModel>>(products);
        }

        public ProductViewModel GetProduct(int id)
        {
            var product = _repo.GetById(id);

            return _mapper.Map<ProductViewModel>(product);
        }

        public void UpdateProduct(UpdateProductViewModel model)
        {
            var dbProduct = _repo.GetById(model.Id);

            dbProduct.Name = model.Name;
            dbProduct.Photo = model.Photo;
            dbProduct.Price = model.Price;
            dbProduct.UpdatedAt = DateTime.UtcNow;

            _uow.Commit();
        }

        public void RemoveProduct(int id)
        {
            _repo.Remove(id);
            _uow.Commit();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}