using System.ComponentModel.DataAnnotations;

namespace MyGroceryStore.DataAccess.Entities
{
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }
        public CustomerEntity Customer { get; set; } = null!;
        public ICollection<OrderItemEntity> OrderItems { get; set; } = new List<OrderItemEntity>();
    }
}
