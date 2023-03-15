using MediSmartBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace MediSmartBackEnd.Data
{
    public class EmployeeAPIDbContext : DbContext
    {
        public EmployeeAPIDbContext(DbContextOptions options) : base(options)
        {
        }

       
        public DbSet<Employee> Employees { get; set; }
    }
}
 