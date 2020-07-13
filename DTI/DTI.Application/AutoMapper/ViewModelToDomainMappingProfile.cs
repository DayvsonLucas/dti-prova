using AutoMapper;
using DTI.Application.ViewModels;
using DTI.Domain.Entities;

namespace DTI.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductViewModel, Product>();
        }
    }
}
