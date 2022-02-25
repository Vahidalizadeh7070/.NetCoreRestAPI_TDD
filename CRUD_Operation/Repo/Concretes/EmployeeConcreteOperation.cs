using CRUD_Operation.Models;
using CRUD_Operation.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Operation.Repo.Concretes
{
    // Concrete Repository
    // This repo inherits from IEmployee interface that includes CRUD operation
    public class EmployeeConcreteOperation : IEmployee
    {
        // Context object field
        private readonly AppDbContext _dbContext;

        // Constructor
        public EmployeeConcreteOperation(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Add method 
        // This method add a new employee 
        public async Task<Employee> Add(Employee employee)
        {
            // If employee was not null add a new employee
            if (employee != null)
            {
                await _dbContext.Employees.AddAsync(employee);
                await _dbContext.SaveChangesAsync();
                return employee;
            }

            // Return null value 
            return null;
        }

        // Delete method
        // This method delete an employee with specific Id
        public Employee Delete(int id)
        {
            // Find an employee and if it was not null delete that employee
            var row = _dbContext.Employees.Find(id);
            if (row != null)
            {
                _dbContext.Employees.Remove(row);
                _dbContext.SaveChanges();
                return row;
            }

            // If the employee was null return null
            return null;
        }

        // Details method
        // This method display an employee with specific Id 
        public Employee Details(int id)
        {
            return  _dbContext.Employees.FirstOrDefault(x => x.Id == id);
        }

        // Edit method
        // This method is going to edit an employee
        public async Task<Employee> Edit(Employee employee)
        {
            // First of all we should retrieve the data from Employee with specific Id
            // If it was not null execute the block
            var model = _dbContext.Employees.FirstOrDefault(x=>x.Id==employee.Id);
            if(model!=null)
            {
                model.Id = employee.Id;
                model.FullName = employee.FullName;
                model.JobCategory = employee.JobCategory;
                _dbContext.Employees.Update(model);
                await _dbContext.SaveChangesAsync();
                return employee;
            }

            // Return null
            return null;
        }

        // List method
        // This action returns a list of employees
        public IEnumerable<Employee> List()
        {
            return _dbContext.Employees.ToList();
        }
    }
}
