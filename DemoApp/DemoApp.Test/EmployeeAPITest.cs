using DemoApp;
using DemoApp.Controllers;
using DemoApp.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DemoApp.Test
{
    public class EmployeeAPITest
    {
        #region Property  
        public Mock<IEmployeeAPIService> mock = new Mock<IEmployeeAPIService>();
        #endregion

        /// <summary>
        /// Unit test for the GetEmployees API.
        /// It will check this API is workin or not.
        /// </summary>
        [Fact]
        public async void GetEmployees()
        {
            //Arrange
            EmployeeAPIController emp = new EmployeeAPIController(mock.Object);

            //Act
            var result = await emp.GetEmployees();

            //Assert
            Assert.NotNull(result);
        }
    }
}
