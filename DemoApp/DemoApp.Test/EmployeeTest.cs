using DemoApp.Controllers;
using DemoApp.Models;
using DemoApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace DemoApp.Test
{
    public class EmployeeTest
    {
        #region Property  
        public Mock<IEmployeeService> mock = new Mock<IEmployeeService>();
        #endregion

        /// <summary>
        /// Verifying the Index method of the MVC application.
        /// </summary>
        [Fact]
        public async void Index()
        {
            //Arrange
            EmployeesController emp = new EmployeesController(mock.Object);

            //Act
            ViewResult result = await emp.Index() as ViewResult;

            //Assert
            Assert.Equal("Indexx", result.ViewName);
        }

        /// <summary>
        /// Verifying the Details method of the MVC application
        /// </summary>
        [Fact]
        public async void Details()
        {
            //Arrange
            EmployeesController emp = new EmployeesController(mock.Object);

            //Act
            ViewResult result = await emp.Details(1) as ViewResult;

            //Assert
            Assert.Equal("Details", result.ViewName);
        }

        /// <summary>
        /// Verifying the Create method like it is returing the create view or not.
        /// </summary>
        [Fact]
        public void Create()
        {
            //Arrange
            EmployeesController emp = new EmployeesController(mock.Object);

            //Act
            ViewResult result = emp.Create() as ViewResult;

            //Assert
            Assert.Equal("Create", result.ViewName);
        }

        /// <summary>
        /// Verifying the create employee method of the MVC application
        /// Mock Database using entity framework.
        /// </summary>
        [Fact]
        public async void CreateEmployee()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "UnitTest").Options;

            //Act
            using (var context = new AppDbContext(options))
            {
                context.Employees.Add(new Employee
                {
                    Name = "Test",
                    Desgination = "User"
                });

                context.SaveChanges();
            }

            //Assert
            using (var context = new AppDbContext(options))
            {
                EmployeeService service = new EmployeeService(context);
                var result = service.GetEmployeebyId(1);

                Assert.Equal("Test", result.Result);
            }
        }
    }
}
