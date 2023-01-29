using Microsoft.EntityFrameworkCore;
using MyGroceryStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroceryStore.DataAccess
{
    public class GroceryDbContext : DbContext
    {
        public GroceryDbContext(DbContextOptions<GroceryDbContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeeEntity> Employee { get; set; } = null!;
        public DbSet<ProductEntity> Product { get; set; } = null!;
        public DbSet<DepartmentEntity> Department { get; set; } = null!;
        public DbSet<CustomerEntity> Customer { get; set; } = null!;
        public DbSet<OrderEntity> Order { get; set; } = null!;
    }
}
