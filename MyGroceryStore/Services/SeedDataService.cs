using Bogus;
using MyGroceryStore.DataAccess;
using MyGroceryStore.DataAccess.Entities;

namespace MyGroceryStore.WebAPI.Services
{
    public class SeedDataService : ISeedDataService
    {
        public void Initialize(GroceryDbContext context)
        {
            var random = new Random();
            Randomizer.Seed = new Random(1337);

            var baseDepartmentAndFood = new Dictionary<string, List<string>>
            {
                {
                    "Meat",
                    new()
                    {
                        "Steak",
                        "Chicken",
                        "Ground Beef",
                        "Sausage"
                    }
                },
                {
                    "Dairy",
                    new()
                    {
                        "Milk",
                        "Shredded Cheese",
                        "Yogurt",
                        "Butter",
                        "Cream"

                    }
                },
                {
                    "Bread",
                    new()
                    {
                        "White Bread",
                        "Wheat Bread",
                        "French Bread",
                        "Pumpernickel Bread",
                        "Naan"
                    }
                },
                {
                    "Pasta",
                    new()
                    {
                        "Spaghetti",
                        "Penne",
                        "Orzo",
                        "Rigatoni",
                        "Red Sauce",
                        "White Sauce",
                        "Pesto"
                    }
                }
            };

            foreach (var department in baseDepartmentAndFood)
            {
                var departmentEntity = new DepartmentEntity()
                {
                    Name = department.Key,
                    Description = "Too Lazy"
                };
                context.Add(departmentEntity);

                foreach (var product in department.Value)
                {
                    var productEntity = new ProductEntity()
                    {
                        Name = product,
                        Description = "Too lazy",
                        Quantity = random.Next(100),
                        Price = random.Next(10),
                        Department = departmentEntity

                    };
                    context.Add(productEntity);
                }
            }

            context.SaveChanges();
        }
    }
}
