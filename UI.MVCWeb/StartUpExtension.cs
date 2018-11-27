using Core.Models;
using DataStore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Vehicle_Search_Sample
{
    public static class StartUpExtension
    {
        public static IWebHost SeedDatabase(this IWebHost webhost)
        {
            using (IServiceScope scope = webhost.Services.GetService<IServiceScopeFactory>().CreateScope())
            using (VehicleContext context = scope.ServiceProvider.GetRequiredService<VehicleContext>())
            {
                Color red = new Color(1, "Red");
                Color blue = new Color(2, "Blue");
                Color black = new Color(3, "Black");

                Manufacturer ford = new Manufacturer() { Name = "Ford", ID = 1 };
                Manufacturer audi = new Manufacturer() { Name = "audi", ID = 2 };
                Manufacturer bmw = new Manufacturer() { Name = "BMW", ID = 3 };

                Model fiesta = new Model { Name = "Fiesta", ID = 1, ManufacturerID = 1 };
                Model bmw320d = new Model { Name = "320D", ID = 2, ManufacturerID = 2 };
                Model bmwz4 = new Model { Name = "Z4", ID = 3, ManufacturerID = 2 };
                Model a1 = new Model { Name = "A1", ID = 4, ManufacturerID = 3 };
                Model a3 = new Model { Name = "A3", ID = 5, ManufacturerID = 3 };

                Vehicle bmw1 = new Vehicle { Millage = 8829, RegistrationNumber = "bmw1", ID = 1, ModelID = 2, RetailPrice = 9999, ColorID = 1 };
                Vehicle bmw2 = new Vehicle { Millage = 86, RegistrationNumber = "bmw2", ID = 2, ModelID = 2, RetailPrice = 7899, ColorID = 2 };
                Vehicle bmw3 = new Vehicle { Millage = 29187, RegistrationNumber = "bmw3", ID = 3, ModelID = 2, RetailPrice = 1299, ColorID = 1 };
                Vehicle bmw4 = new Vehicle { Millage = 92661, RegistrationNumber = "bmw4", ID = 4, ModelID = 3, RetailPrice = 9999.99m, ColorID = 1 };
                Vehicle audi1 = new Vehicle { Millage = 2341, RegistrationNumber = "audi1", ID = 5, ModelID = 4, RetailPrice = 9999, ColorID = 2 };
                Vehicle audi2 = new Vehicle { Millage = 324234, RegistrationNumber = "audi2", ID = 6, ModelID = 5, RetailPrice = 12000, ColorID = 3 };
                Vehicle audi3 = new Vehicle { Millage = 8923, RegistrationNumber = "audi3", ID = 7, ModelID = 4, RetailPrice = 800, ColorID = 1 };
                Vehicle audi4 = new Vehicle { Millage = 982347, RegistrationNumber = "audi4", ID = 8, ModelID = 4, RetailPrice = 9999, ColorID = 3 };
                Vehicle audi5 = new Vehicle { Millage = 3246, RegistrationNumber = "audi5", ID = 9, ModelID = 5, RetailPrice = 9999, ColorID = 3 };
                Vehicle audi6 = new Vehicle { Millage = 134234, RegistrationNumber = "audi6", ID = 10, ModelID = 5, RetailPrice = 9999, ColorID = 2 };
                Vehicle audi7 = new Vehicle { Millage = 897214, RegistrationNumber = "audi7", ID = 11, ModelID = 5, RetailPrice = 9999, ColorID = 1 };
                Vehicle fiesta1 = new Vehicle { Millage = 86312, RegistrationNumber = "fiesta 1", ID = 12, ModelID = 1, RetailPrice = 10, ColorID = 1 };

                context.Colors.AddRange(red, blue, black);
                context.Manufacturers.AddRange(ford, audi, bmw);
                context.Models.AddRange(fiesta, bmw320d, bmwz4, a1, a3);
                context.Vehicles.AddRange(bmw1, bmw2, bmw3, bmw4, audi1, audi2, audi3, audi4, audi5, audi6, audi7, fiesta1);


                context.SaveChanges();
            }
            return webhost;
        }
    }
}
