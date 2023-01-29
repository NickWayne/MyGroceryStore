using System.ComponentModel.DataAnnotations;

namespace MyGroceryStore.DataAccess.Entities
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; } = decimal.Zero;
        public decimal Discount { get; set; } = decimal.Zero;
        public DepartmentEntity Department { get; set; } = null!;
    }
}
