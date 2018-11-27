using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core
{
    public interface ISearchService
    {
        Task<IEnumerable<Vehicle>> Search();
    }
}
