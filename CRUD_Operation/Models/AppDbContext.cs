using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Operation.Models
{
    // AppDbContext
    // This class is going to use as the Context
    // This Context inherits from DbContext which is related to EF Core
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // Employees DbSet
        public DbSet<Employee> Employees { get; set; }
    }
}
