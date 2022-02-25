using CRUD_Operation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.DummyData
{
    // This class provides the Dummy data that is appropriate for the test
    // These datas prepare a test for our application until we do the test implementation on these dummy datas
    // These values are going to use in Employee Crud operation
    public class DummyDataDBInitializer
    {
        public DummyDataDBInitializer()
        {
        }

        // Seed method
        public void Seed(AppDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.ChangeTracker.AutoDetectChangesEnabled = false;
            context.Employees.AddRange(
                new Employee() { Id = 1, FullName = "James Brown", JobCategory = "Front-End" },
                new Employee() { Id = 2, FullName = "Martin Liam", JobCategory = "Back-End" },
                new Employee() { Id = 3, FullName = "Liza Andrew", JobCategory = "Administrator" }
            );
            
            context.SaveChanges();
        }
    }
}
