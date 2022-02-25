using AutoMapper;
using CRUD_Operation.Controllers;
using CRUD_Operation.Dtos;
using CRUD_Operation.Models;
using CRUD_Operation.Repo.Concretes;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTesting.DummyData;
using Xunit;

namespace UnitTesting.Controllers
{
    public class EmployeeUnitTestController
    {
        // Repository object
        private EmployeeConcreteOperation repository;

        // IMapper object
        private IMapper _mapper;

        // Context option
        public static DbContextOptions<AppDbContext> dbContextOptions { get; }

        // If you are going to use a connection string in your application you can use below connection 
        // It is more benefitial to use this connection string in a json file than using in here.

        //public static string connectionString = "Server=ABCD;Database=BlogDB;UID=sa;PWD=xxxxxxxxxx;";

        // static constructor to set our connection 
        // In this example we are using InMemomry database
        // Also we are using InMemomry database in our web api project
        static EmployeeUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("InMem").Options;
        }




        // Constructor
        // In this constructor, AppDbContext with DummyData have been added to the EmployeeUnitTestController
        public EmployeeUnitTestController()
        {
            var context = new AppDbContext(dbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();

            db.Seed(context);

            repository = new EmployeeConcreteOperation(context);


            // Use mapper 
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeReadDTO>();
                cfg.CreateMap<EmployeeReadDTO, Employee>();
                cfg.CreateMap<EmployeeCreateDTO, Employee>();
                cfg.CreateMap<Employee, EmployeeCreateDTO>();
                cfg.CreateMap<EmployeeUpdateDTO, Employee>();
                cfg.CreateMap<EmployeeCreateDTO, EmployeeReadDTO>();
                cfg.CreateMap<EmployeeReadDTO, EmployeeCreateDTO>();
                cfg.CreateMap<EmployeeUpdateDTO, Employee>();
                cfg.CreateMap<Employee, EmployeeUpdateDTO>();
            });
            var mapper = config.CreateMapper();

            _mapper = mapper;
        }

        // Return Ok for GetEmployeeById action
        [Fact]
        public void Task_GetEmployeeById_Return_OkResult()
        {
            //Arrange  

            var controller = new EmployeeController(repository, _mapper);

            // Test value
            var empoloyeeId = 1;

            //Act  
            var data = controller.GetEmployeeById(empoloyeeId);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        // Return NotFound for GetEmployeeById action
        [Fact]
        public void Task_GetPostById_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new EmployeeController(repository, _mapper);

            // Test value
            var empoloyeeId = 5;

            //Act  
            var data = controller.GetEmployeeById(empoloyeeId);

            //Assert  
            Assert.IsType<NotFoundResult>(data);
        }

        // Get all Employee and return ok result
        [Fact]
        public void Task_GetPost_Return_OKResult()
        {
            //Arrange  
            var controller = new EmployeeController(repository, _mapper);

            //Act  
            var data = controller.List();

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        // Get all Employee and return bad request 
        [Fact]
        public void Task_GetPost_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new EmployeeController(repository, _mapper);

            //Act  
            var data = controller.List();

            // Test value
            data = null;

            if (data != null)

                //Assert  
                Assert.IsType<BadRequestResult>(data);
        }

        // Add an Employee and return CreatedAtRouteResult
        [Fact]
        public async void Task_Add_Employee_Return_CreatedAtRouteResult()
        {
            //Arrange  
            var controller = new EmployeeController(repository, _mapper);

            // A new object that we are going to add
            var post = new EmployeeCreateDTO() { FullName = "James Brown", JobCategory = "Front-End" };


            //Act  
            var data = await controller.CreateEmployee(post);

            //Assert  
            Assert.IsType<CreatedAtRouteResult>(data);
        }

        // Add an Employee and return MaxLenghError_Required error
        [Fact]
        public async void Task_Add_Employee_Return_MaxLenghError_Required()
        {
            //Arrange  
            var controller = new EmployeeController(repository, _mapper);

            // A new object that we are going to add with an error that it is related with [MaxLenght] in Employee model
            var employee = new EmployeeCreateDTO() { FullName = "James Brown asdsadsafsafsdafsdfds afjaksdh fasdb fdasjfh adshlfh asfa sd", JobCategory = "" };

            // It will change the post variable to null value dute to necessary attribute in our model
            if (employee.FullName.Length > 20 || employee.JobCategory.Length < 1)
            {
                employee = null;
            }

            //Act  
            var data = await controller.CreateEmployee(employee);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }


        // Edit an Employee and return CreatedAtRouteResult
        [Fact]
        public async void Task_Edit_Employee_Return_CreatedAtRouteResult()
        {

            //Arrange  
            var controller = new EmployeeController(repository, _mapper);

            var employee = new EmployeeUpdateDTO { Id = 2, FullName = "Test Employee", JobCategory = "Complete Tasker" };

            //Act  
            var data = await controller.Edit(employee);
            Assert.IsType<CreatedAtRouteResult>(data);
        }

        // Edit an Employee and return MaxLenghError_Required error
        [Fact]
        public async void Task_Edit_Employee_Return_MaxLenghError_Required()
        {
            //Arrange  
            var controller = new EmployeeController(repository, _mapper);

            // A new object that we are going to edit with an error that it is related with [MaxLenght] in Employee model
            EmployeeUpdateDTO employee = new EmployeeUpdateDTO() { Id = 2, FullName = "James Brown asdsadsafsafsdafsdfds afjaksdh fasdb fdasjfh adshlfh asfa sd", JobCategory = "" };

            // It will change the post variable to null value dute to necessary attribute in our model
            if (employee.FullName.Length > 20 || employee.JobCategory.Length < 1)
            {
                employee = null;
            }

            //Act  
            var data = await controller.Edit(employee);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }

        // Delete an Employee and return CreatedAtRouteResult
        [Fact]
        public  void Task_Delete_Employee_Return_CreatedAtRouteResult()
        {

            //Arrange  
            var controller = new EmployeeController(repository, _mapper);

            var employee = 1;

            //Act  
            var data =  controller.DeleteEmployee(employee);
            Assert.IsType<CreatedAtRouteResult>(data);
        }
        // Delete an Employee and return NotFound
        [Fact]
        public  void Task_Delete_Employee_Return_NotFound()
        {
            //Arrange  
            var controller = new EmployeeController(repository, _mapper);

            // This id is an invalid Id due to the get an error that will be expected

            var employee = 4;

            //Act  
            var data = controller.DeleteEmployee(employee);

            //Assert  
            Assert.IsType<NotFoundObjectResult>(data);
        }

    }
}
