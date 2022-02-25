using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Operation.Dtos
{
    // EmployeeCreateDTO
    // This Dto is going to use in Create Action to add a new record to the employee 
    public class EmployeeCreateDTO
    {
        [MaxLength(20)]
        public string FullName { get; set; }
        [Required]
        public string JobCategory { get; set; }
    }
}
