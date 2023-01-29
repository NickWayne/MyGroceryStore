using System.ComponentModel.DataAnnotations;

namespace MyGroceryStore.DataAccess.Entities
{
    public class CustomerEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
