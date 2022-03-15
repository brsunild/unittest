using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoApp.Models;
using DemoApp.Services;

namespace DemoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAPIController : ControllerBase
    {
        private readonly IEmployeeAPIService _employeeService;

        public EmployeeAPIController(IEmployeeAPIService employeeService)
        {
            _employeeService = employeeService;
        }


        // GET: api/EmployeeAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _employeeService.GetEmployees();
        }

    }
}
