using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;
        public EmployeeService(HttpClient httpClient )
        {
            this.httpClient = httpClient;
        }

        public Task<IEnumerable<Employee>> GetEmployees()
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<Employee>> GetEmployees()
        //{
        //    return await httpClient.GetJsonAsync<Employee[]>("api/employees");
        //}
    }
}
    