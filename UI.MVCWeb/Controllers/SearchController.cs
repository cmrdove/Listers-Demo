using Core;
using Core.Models;
using DataStore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels.Search;

namespace UI.MVCWeb.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService searchService;
        private readonly VehicleContext vehicleContext;
        private readonly IMappingService mappingService;

        public SearchController(ISearchService searchService, IMappingService mappingService, VehicleContext vehicleContext)
        {
            this.searchService = searchService;
            this.mappingService = mappingService;
            this.vehicleContext = vehicleContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IndexViewModel viewModel = new IndexViewModel();
            Task<IEnumerable<Vehicle>> resultsTask = searchService.Search();
            Task<List<Manufacturer>> manufacturersTask = vehicleContext.Manufacturers.ToAsyncEnumerable().ToList();

            await Task.WhenAll(resultsTask, manufacturersTask);
            await mappingService.Map(viewModel, resultsTask.Result, manufacturersTask.Result);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(IndexViewModel viewModel)
        {
            Task<List<Model>> modelsTask = new List<Model>().ToAsyncEnumerable().ToList();
            SearchFilterOptions searchFilterOptions = new SearchFilterOptions();

            Task<List<Manufacturer>> manufacturersTask = vehicleContext.Manufacturers.ToAsyncEnumerable().ToList();

            if (viewModel.SelectedModelID > 0)
            {
                searchFilterOptions.ModelID = viewModel.SelectedModelID;
            }
            if (viewModel.SelectedManufacturerID > 0)
            {
                modelsTask = vehicleContext.Models.Where(model => model.ManufacturerID == viewModel.SelectedManufacturerID).ToAsyncEnumerable().ToList();
                searchFilterOptions.ManufacturerID = viewModel.SelectedManufacturerID;
            }

            Task<IEnumerable<Vehicle>> resultsTask = searchService.Search(searchFilterOptions);

            await Task.WhenAll(resultsTask, manufacturersTask, modelsTask);
            await mappingService.Map(viewModel, resultsTask.Result, manufacturersTask.Result, modelsTask.Result);

            return View(viewModel);
        }
    }
}
