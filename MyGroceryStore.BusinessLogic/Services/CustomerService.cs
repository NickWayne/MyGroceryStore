using MyGroceryStore.BusinessLogic.Interfaces;
using MyGroceryStore.DataAccess;
using MyGroceryStore.DataAccess.Entities;

namespace MyGroceryStore.BusinessLogic.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly GroceryDbContext _dbContext;

        public CustomerService(GroceryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<CustomerEntity> GetAllCustomers()
        {
            return _dbContext.Customer.ToList();
        }

        public CustomerEntity? GetCustomererById(int id)
        {
            return _dbContext.Customer.Where(c => c.Id == id).FirstOrDefault();
        }

        public OrderEntity? GetOrderByID(int orderId)
        {
            return _dbContext.Order.Where(o => o.Id == orderId).FirstOrDefault();
        }

        public ICollection<OrderEntity> GetOrdersByCustomerID(int id)
        {
            return _dbContext.Order.Where(o => o.Customer.Id == id).ToList();
        }
    }
}
