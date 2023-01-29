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
                context.SaveChanges();

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
                    context.SaveChanges();
                }
            }

            var customerIds = 1;
            var employeeIds = 1;
            var orderIds = 1;
            var orderItemIds = 1;
            var departments = context.Department.ToList();
            var defaultCustomers = new Faker<CustomerEntity>()
                                            .StrictMode(true)
                                            .RuleFor(c => c.Id, f => customerIds++)
                                            .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                                            .RuleFor(c => c.LastName, f => f.Name.LastName())
                                            .RuleFor(c => c.Address, f => f.Address.FullAddress())
                                            .RuleFor(c => c.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName));

            var defaultEmployees = new Faker<EmployeeEntity>()
                                            .StrictMode(true)
                                            .RuleFor(e => e.Id, f => employeeIds++)
                                            .RuleFor(e => e.FirstName, f => f.Name.FirstName())
                                            .RuleFor(e => e.LastName, f => f.Name.LastName())
                                            .RuleFor(e => e.PhoneNumber, f => f.Phone.PhoneNumberFormat(1))
                                            .RuleFor(e => e.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                                            .RuleFor(e => e.Department, (f, u) => f.PickRandom(departments));

            context.AddRange(defaultCustomers.Generate(20));
            context.AddRange(defaultEmployees.Generate(5));
            context.SaveChanges();

            var customers = context.Customer.ToList();
            var products = context.Product.ToList();

            var defaultOrderItem = new Faker<OrderItemEntity>()
                                            .StrictMode(true)
                                            .RuleFor(o => o.Id, f => orderItemIds++)
                                            .RuleFor(o => o.Quantity, f => f.Random.Int(1, 10))
                                            .RuleFor(o => o.Product, f => f.PickRandom(products));

            var defaultOrders = new Faker<OrderEntity>()
                                            .StrictMode(true)
                                            .RuleFor(o => o.Id, f => orderIds++)
                                            .RuleFor(o => o.Customer, f => f.PickRandom(customers))
                                            .RuleFor(o => o.OrderItems, f => defaultOrderItem.Generate(f.Random.Int(1, 10)));

            context.AddRange(defaultOrders.Generate(10));
            context.SaveChanges();
        }
    }
}
