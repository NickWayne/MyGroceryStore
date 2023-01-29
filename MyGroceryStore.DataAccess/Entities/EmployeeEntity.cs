using System.ComponentModel.DataAnnotations;

namespace MyGroceryStore.DataAccess.Entities
{
    public class EmployeeEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DepartmentEntity Department { get; set; } = null!;

    }
}
