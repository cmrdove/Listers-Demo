using AutoMapper;
using Core.Models;
using System.Collections.Generic;
using Web.ViewModels.Search;

namespace UI.MVCWeb.Mappings
{
    public class IndexViewModelMapping : Profile
    {
        public IndexViewModelMapping()
        {
            IMappingExpression<List<Vehicle>, IndexViewModel> viewModelMap = CreateMap<List<Vehicle>, IndexViewModel>();
            viewModelMap.ForPath(dest => dest.Results, opt => opt.MapFrom(source => source));
            viewModelMap.ForAllOtherMembers(option => option.Ignore());

            IMappingExpression<List<Manufacturer>, IndexViewModel> manufacturesMap = CreateMap<List<Manufacturer>, IndexViewModel>();
            manufacturesMap.ForPath(dest => dest.Manufacturers, opt => opt.MapFrom(source => source));
            manufacturesMap.ForAllOtherMembers(option => option.Ignore());

            IMappingExpression<List<Model>, IndexViewModel> modelsMap = CreateMap<List<Model>, IndexViewModel>();
            modelsMap.ForPath(dest => dest.Models, opt => opt.MapFrom(source => source));
            manufacturesMap.ForAllOtherMembers(option => option.Ignore());
        }
    }
}
