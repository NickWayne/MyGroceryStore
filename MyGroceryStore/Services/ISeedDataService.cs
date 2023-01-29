using MyGroceryStore.DataAccess;

namespace MyGroceryStore.WebAPI.Services
{
    public interface ISeedDataService
    {
        void Initialize(GroceryDbContext context);
    }
}
