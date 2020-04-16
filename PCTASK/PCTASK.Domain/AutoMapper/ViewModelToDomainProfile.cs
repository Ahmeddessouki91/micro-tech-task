using System;
using AutoMapper;
using PCTASK.Data.Entities;
using PCTASK.Domain.Models.Product;

namespace PCTASK.Domain.AutoMapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<CreateProductViewModel, Product>();

            CreateMap<UpdateProductViewModel, Product>();

            CreateMap<ProductViewModel, Product>();
        }
    }
}