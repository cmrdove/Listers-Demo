using AutoMapper;
using Core;
using Core.Models;
using DataStore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.MVCWeb.ViewModels.Search;

namespace UI.MVCWeb.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService searchService;
        private readonly IMapper mapper;
        private readonly VehicleContext vehicleContext;

        public SearchController(ISearchService searchService, IMapper mapper, VehicleContext vehicleContext)
        {
            this.searchService = searchService;
            this.mapper = mapper;
            this.vehicleContext = vehicleContext;
        }

        public async Task<IActionResult> Index()
        {
            Task<IEnumerable<Vehicle>> resultsTask = searchService.Search();
            IAsyncEnumerable<SelectListItem> manufacturersTask = vehicleContext.Manufacturers.Select(man => new SelectListItem() { Text = man.Name, Value = man.ID.ToString() }).ToAsyncEnumerable();

            IndexViewModel viewModel = mapper.Map<IndexViewModel>(await resultsTask);
            mapper.Map(await manufacturersTask.ToList(), viewModel);

            return View(viewModel);
        }
    }
}
