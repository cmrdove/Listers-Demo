using AutoMapper;
using Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using UI.MVCWeb.ViewModels.Search;

namespace UI.MVCWeb.Mappings
{
    public class SearchIndexMapping : Profile
    {
        public SearchIndexMapping()
        {
            IMappingExpression<List<Vehicle>, IndexViewModel> viewModelMap = CreateMap<List<Vehicle>, IndexViewModel>();
            viewModelMap.ForPath(dest => dest.Results, opt => opt.MapFrom(source => source));

            IMappingExpression<List<Manufacturer>, IndexViewModel> manufacturesMap = CreateMap<List<Manufacturer>, IndexViewModel>();
            manufacturesMap.ForPath(dest => dest.Manufacturers, opt => opt.MapFrom(source => source));

            IMappingExpression<List<Model>, IndexViewModel> modelsMap = CreateMap<List<Model>, IndexViewModel>();
            modelsMap.ForPath(dest => dest.Models, opt => opt.MapFrom(source => source));
        }
    }

    public class SelectListItemsMappingProfile : Profile
    {
        public SelectListItemsMappingProfile()
        {
            IMappingExpression<Manufacturer, SelectListItem> manufacturerMap = CreateMap<Manufacturer, SelectListItem>();
            manufacturerMap.ForMember(dest => dest.Text, opt => opt.MapFrom(source => source.Name));
            manufacturerMap.ForMember(dest => dest.Value, opt => opt.MapFrom(source => source.ID));
            manufacturerMap.ForAllOtherMembers(m => m.Ignore());

            IMappingExpression<Model, SelectListItem> modelMap = CreateMap<Model, SelectListItem>();
            modelMap.ForMember(dest => dest.Text, opt => opt.MapFrom(source => source.Name));
            modelMap.ForMember(dest => dest.Value, opt => opt.MapFrom(source => source.ID));
            modelMap.ForAllOtherMembers(m => m.Ignore());
        }

    }
}

