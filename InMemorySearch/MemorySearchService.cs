using Core;
using Core.Models;
using DataStore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InMemorySearch
{
    public class EntityFrameworkSearch : ISearchService
    {
        private readonly VehicleContext dbContext;

        public EntityFrameworkSearch(VehicleContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Vehicle>> Search()
        {
            return (await dbContext.Vehicles.ToListAsync()).Cast<Vehicle>();
        }
    }
}
