using MyGroceryStore.DataAccess;
using MyGroceryStore.WebAPI.Services;

namespace MyGroceryStore.WebAPI.Helpers
{
    public static class SeedDataExtension
    {
        public static void SeedData(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<GroceryDbContext>();
            var seedDataService = scope.ServiceProvider.GetRequiredService<ISeedDataService>();

            seedDataService.Initialize(dbContext);
        }
    }
}
