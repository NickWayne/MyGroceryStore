using MyGroceryStore.DataAccess.Entities;

namespace MyGroceryStore.BusinessLogic.Interfaces
{
    public interface ICustomerService
    {
        public CustomerEntity? GetCustomererById(int id);
        public ICollection<CustomerEntity> GetAllCustomers();
        public ICollection<OrderEntity> GetOrdersByCustomerID(int id);
        public OrderEntity? GetOrderByID(int orderId); // Not great to have in this service
    }
}
