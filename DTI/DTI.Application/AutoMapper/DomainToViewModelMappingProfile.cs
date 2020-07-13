using AutoMapper;
using DTI.Application.ViewModels;
using DTI.Domain.Entities;

namespace DTI.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}
