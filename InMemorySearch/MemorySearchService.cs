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

        public async Task<IEnumerable<Vehicle>> Search() =>
            await Search(SearchFilterOptions.None);

        public async Task<IEnumerable<Vehicle>> Search(SearchFilterOptions filterOptions)
        {
            IQueryable<Vehicle> vehicles = dbContext.Vehicles;

            if (filterOptions.ModelID.HasValue)
            {
                vehicles = vehicles.Where(vehicle => vehicle.ModelID == filterOptions.ModelID);
            }
            else if (filterOptions.ManufacturerID.HasValue)
            {
                vehicles = vehicles.Where(vehicle => vehicle.Model.ManufacturerID == filterOptions.ManufacturerID);
            }

            return await vehicles.ToListAsync();
        }
    }
}
