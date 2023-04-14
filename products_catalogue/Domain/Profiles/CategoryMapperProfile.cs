using AutoMapper;
using products_catalogue.Application.Category.Command.Request;
using products_catalogue.Domain.Models;

namespace products_catalogue.Domain.Profiles
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<AddCategoryRequest, Category>()
              .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}