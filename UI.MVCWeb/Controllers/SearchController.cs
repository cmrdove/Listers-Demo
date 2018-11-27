using AutoMapper;
using Core;
using Core.Models;
using DataStore;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            Task<IEnumerable<Vehicle>> resultsTask = searchService.Search();
            IAsyncEnumerable<Manufacturer> manufacturersTask = vehicleContext.Manufacturers.ToAsyncEnumerable();

            IndexViewModel viewModel = mapper.Map<IndexViewModel>(await resultsTask);
            mapper.Map(await manufacturersTask.ToList(), viewModel);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(IndexViewModel viewModel)
        {
            IAsyncEnumerable<Model> modelsTask = new List<Model>().ToAsyncEnumerable();
            SearchFilterOptions searchFilterOptions = new SearchFilterOptions();

            IAsyncEnumerable<Manufacturer> manufacturersTask = vehicleContext.Manufacturers.ToAsyncEnumerable();

            if (viewModel.SelectedModelID > 0)
            {
                searchFilterOptions.ModelID = viewModel.SelectedModelID;
            }
            if (viewModel.SelectedManufacturerID > 0)
            {
                modelsTask = vehicleContext.Models.Where(model => model.ManufacturerID == viewModel.SelectedManufacturerID).ToAsyncEnumerable();
                searchFilterOptions.ManufacturerID = viewModel.SelectedManufacturerID;
            }

            Task<IEnumerable<Vehicle>> resultsTask = searchService.Search(searchFilterOptions);
            mapper.Map(await resultsTask, viewModel);
            mapper.Map(await manufacturersTask.ToList(), viewModel);
            mapper.Map(await modelsTask.ToList(), viewModel);

            return View(viewModel);
        }
    }
}
