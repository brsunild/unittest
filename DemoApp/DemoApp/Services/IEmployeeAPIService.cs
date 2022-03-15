using DemoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Services
{
    public interface IEmployeeAPIService
    {
        Task<List<Employee>> GetEmployees();
    }
}
