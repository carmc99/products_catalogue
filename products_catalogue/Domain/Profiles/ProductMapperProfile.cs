using AutoMapper;
using products_catalogue.Application.Product.Command.Request;
using products_catalogue.Domain.Models;

namespace products_catalogue.Domain.Profiles
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<AddProductRequest, Product>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateProductRequest, Product>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}