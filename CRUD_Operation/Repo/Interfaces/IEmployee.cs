using CRUD_Operation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Operation.Repo.Interfaces
{
    // This is an interface that the Concrete class inhertis from this interface
    // This interface includes some method which is reponsible for the CRUD operation
    public interface IEmployee
    {
        // Create a new employee
        // Async method
        Task<Employee> Add(Employee employee);

        // Update an employee
        // Asycn method
        Task<Employee> Edit(Employee employee);

        // Details an employee
        Employee Details(int id);
        
        // Delete an employee with specific Id
        Employee Delete(int id);

        // List of an Employee 
        // This is an IEnumerable type
        IEnumerable<Employee> List(); 
    }
}
