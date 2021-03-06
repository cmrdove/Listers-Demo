using AutoMapper;
using Core.Models;
using Web.ViewModels.Helpers;

namespace UI.MVCWeb.Mappings
{
    public class BasicVehicleViewModelMapping : Profile
    {
        public BasicVehicleViewModelMapping()
        {
            IMappingExpression<Vehicle, BasicVehicleViewModel> map = CreateMap<Vehicle, BasicVehicleViewModel>();
            map.ForMember(dest => dest.Make, opt => opt.MapFrom(source => source.Model.Manufacturer.Name));
            map.ForMember(dest => dest.Model, opt => opt.MapFrom(source => source.Model.Name));
            map.ForMember(dest => dest.Cost, opt => opt.MapFrom(source => source.RetailPrice));
            map.ForMember(dest => dest.Millage, opt => opt.MapFrom(source => source.Millage));
            map.ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}
