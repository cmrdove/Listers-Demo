using AutoMapper;
using Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.MVCWeb.Mappings
{
    public class SelectListItemsMappingProfile : Profile
    {
        public SelectListItemsMappingProfile()
        {
            IMappingExpression<Manufacturer, SelectListItem> manufacturerSelectListMap = CreateMap<Manufacturer, SelectListItem>();
            manufacturerSelectListMap.ForMember(source => source.Text, opt => opt.MapFrom(dest => dest.Name));
            manufacturerSelectListMap.ForMember(source => source.Value, opt => opt.MapFrom(dest => dest.ID));

            IMappingExpression<Model, SelectListItem> modelSelectListMap = CreateMap<Model, SelectListItem>();
            manufacturerSelectListMap.ForMember(source => source.Text, opt => opt.MapFrom(dest => dest.Name));
            manufacturerSelectListMap.ForMember(source => source.Value, opt => opt.MapFrom(dest => dest.ID));
        }
    }
}
