using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using UI.MVCWeb.ViewModels.Helpers;

namespace UI.MVCWeb.ViewModels.Search
{
    public class IndexViewModel
    {
        public IEnumerable<BasicVehicleViewModel> Results { get; set; }
        public IEnumerable<SelectListItem> Manufacturers { get; set; }
    }
}
