namespace MyGroceryStore.DataAccess.Entities
{
    public class OrderItemEntity
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public ProductEntity Product { get; set; } = null!;

    }
}
