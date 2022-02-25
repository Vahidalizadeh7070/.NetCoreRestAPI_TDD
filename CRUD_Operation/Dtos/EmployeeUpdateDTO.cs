using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Operation.Dtos
{
    // EmployeeUpdateDTO
    // This Dto is going to use in Update Action to edit an employee 
    public class EmployeeUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(20)]
        public string FullName { get; set; }
        [Required]
        public string JobCategory { get; set; }
    }
}
