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

            IMappingExpression<Manufacturer, IndexViewModel> manufacturesMap = CreateMap<Manufacturer, IndexViewModel>();
            viewModelMap.ForPath(dest => dest., opt => opt.MapFrom(source => source));
        }
    }

    public class SelectListItemsMappingProfile : Profile
    {
        public SelectListItemsMappingProfile()
        {
            CreateMap<Manufacturer, SelectListItem>();

        }

    }
}
