using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Operation.Models
{
    // Employee Class
    // This class is a concrete object and all Dtos is a copy of this class
    // The Employee is a main class that we are going to use in the repository
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(20)]
        public string FullName { get; set; }
        [Required]
        public string JobCategory { get; set; }

    }
}
