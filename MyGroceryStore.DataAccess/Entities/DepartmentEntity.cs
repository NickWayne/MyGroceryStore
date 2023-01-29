using System.ComponentModel.DataAnnotations;

namespace MyGroceryStore.DataAccess.Entities
{
    public class DepartmentEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public virtual ICollection<ProductEntity> Products { get; set; } = null!;
    }
}
