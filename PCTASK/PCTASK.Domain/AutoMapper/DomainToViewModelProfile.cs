using AutoMapper;
using PCTASK.Data.Entities;
using PCTASK.Domain.Models.Product;

namespace PCTASK.Domain.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}