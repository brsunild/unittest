using DemoApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Services
{
    public class EmployeeAPIService : IEmployeeAPIService
    {

        #region Property  
        private readonly AppDbContext _appDbContext;
        #endregion

        #region Constructor  
        public EmployeeAPIService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        #endregion

        public async Task<List<Employee>> GetEmployees()
        {
            return await _appDbContext.Employees.ToListAsync();
        }
    }
}
