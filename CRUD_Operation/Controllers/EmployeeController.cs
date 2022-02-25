using AutoMapper;
using CRUD_Operation.Dtos;
using CRUD_Operation.Models;
using CRUD_Operation.Repo.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Operation.Controllers
{

    // The Employee controller is responsible for CRUD operation
    // This controller is an API controller

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // Fields that is going to use throughout the contoller
        private readonly IEmployee employee;
        private readonly IMapper mapper;

        // Constructor
        public EmployeeController(IEmployee employee, IMapper mapper)
        {
            this.employee = employee;
            this.mapper = mapper;
        }

        // GET: List action
        // This action returns all the employee that exist in our context
        [HttpGet]
        public ActionResult List()
        {
            var model = employee.List();

            // Return NotFound if the model count is equal to Zero
            if (model.Count() == 0)
            {
                return NotFound();
            }

            // Return Ok if there are values in the context
            return Ok(model);
        }

        // GET: GetEmployeeById Action
        // This action returns an employee that the Id of employee is equal with the input paramter
        [HttpGet("{id}", Name = "GetEmployeeById")]
        public ActionResult GetEmployeeById(int id)
        {
            // Get an employee 
            var model = employee.Details(id);

            // Return Ok if there is an employee in the context
            if (model != null)
            {
                return Ok(model);
            }

            // Return NotFound if there is not any employee in the context
            return NotFound();
        }

        // POST: CreateEmployee Action
        // This action can add a new employee to the context
        // If it gets the value from a form in front side (React, Angular, etc.)
        // you should use [FromBody] attribute before EmployeeCreateDTO
        [HttpPost]
        public async Task<ActionResult> CreateEmployee(EmployeeCreateDTO employeeDto)
        {
            // Map all the input that we get from employeeDto which it is an input parameter
            var model = mapper.Map<Employee>(employeeDto);

            // It will add the model that mapped due the type of Add method which it will just accepted the Employee Type
            // 
            var returnmodel = await employee.Add(model);

            // If the returnmodel variable was not null then return CreateAtRoute
            if (returnmodel != null)
            {
                return CreatedAtRoute(nameof(GetEmployeeById), new { id = model.Id }, returnmodel);
            }

            // If the returnmodel variable was null then return BadRequest()
            return BadRequest();
        }


        // PUT: Edit Action
        // This action can edit an employee
        // If it gets the value from a form in front side (React, Angular, etc.)
        // you should use [FromBody] attribute before EmployeeCreateDTO
        [HttpPut]
        public async Task<ActionResult> Edit(EmployeeUpdateDTO employeeDto)
        {
            // If the input parameter (employeeDto) was not null then execute the If body
            if (employeeDto != null)
            {
                // Retrieve the specific employees base on their Ids 
                var exist = employee.Details(employeeDto.Id);

                // If there is an employee then execute the If body
                if (exist != null)
                {
                    // Because of the type of Edit method, it should be Mapped the employeeDto that we get from the input parameters
                    // to the Employee object and then pass it to the Edit() method
                    var mapp = mapper.Map<Employee>(employeeDto);

                    // Pass the mapp objcet
                    var returnmodel = await employee.Edit(mapp);

                    // If it was not null then execute the If body
                    if (returnmodel != null)
                    {
                        return CreatedAtRoute(nameof(GetEmployeeById), new { id = employeeDto.Id }, returnmodel);
                    }
                }
            }

            // If the input parameter (employeeDto) was null then return BadRequest
            return BadRequest();
        }


        // DELETE: DeleteEmployee Action
        // This action just get the Id of employee and then remove it from the context
        [HttpDelete("{id:int}")]
        public ActionResult DeleteEmployee(int id)
        {
            try
            {
                // First of all we should retrieve the employee based on its Id
                var Employeedelete = employee.Details(id);

                //  If Employeedelete was null return NotFound
                if (Employeedelete == null)
                {
                    return NotFound($"Employee with id = {id} not found.");
                }

                // Delete the employee with specific Id
                employee.Delete(id);

                // Return CreatedAtRoute 
                return CreatedAtRoute(nameof(GetEmployeeById), new { id = Employeedelete.Id }, Employeedelete);
            }
            catch (Exception)
            {
                // Return BadRequest
                return BadRequest();
            }
        }
    }
}
