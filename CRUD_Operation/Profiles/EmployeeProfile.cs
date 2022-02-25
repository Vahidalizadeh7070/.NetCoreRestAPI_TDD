using AutoMapper;
using CRUD_Operation.Dtos;
using CRUD_Operation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Operation.Profiles
{
    // AutoMapper
    // Employee Mapping object
    // This class inherits from Profile which is related to AutoMapper
    public class MappingProfile : Profile
    {
        // Constructor
        // All the CreateMap that are going to use throughout the project
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeReadDTO>();
            CreateMap<EmployeeReadDTO, Employee>();
            CreateMap<EmployeeCreateDTO, Employee>();
            CreateMap<Employee, EmployeeCreateDTO>();
            CreateMap<EmployeeUpdateDTO, Employee>();
            CreateMap<Employee, EmployeeUpdateDTO>();
            CreateMap<EmployeeCreateDTO, EmployeeReadDTO>();
            CreateMap< EmployeeReadDTO, EmployeeCreateDTO>();
        }

    }
}
