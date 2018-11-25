using Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace UI.MVCWeb.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        public async Task<IActionResult> Index()
        {
            await searchService.Search();

            return View();
        }
    }
}
