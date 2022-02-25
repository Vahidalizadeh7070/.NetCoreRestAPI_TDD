using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Operation.Dtos
{
    // EmployeeReadDTO
    // This Dto is going to use in List and GetEmployeeById Actions to demonstrate employees
    public class EmployeeReadDTO
    {
        public string FullName { get; set; }
        public string JobCategory { get; set; }
    }
}
