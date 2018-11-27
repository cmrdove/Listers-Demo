using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core
{
    public interface ISearchService
    {
        Task<IEnumerable<Vehicle>> Search();
        Task<IEnumerable<Vehicle>> Search(SearchFilterOptions filterOptions);
    }

    public class SearchFilterOptions
    {
        public int? ModelID { get; set; }
        public int? ManufacturerID { get; set; }

        public static SearchFilterOptions None { get { return new SearchFilterOptions(); } }
    }
}
