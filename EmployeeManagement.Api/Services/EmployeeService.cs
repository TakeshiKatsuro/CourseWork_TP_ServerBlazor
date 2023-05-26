using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace EmployeeManagement.Api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;
        public EmployeeService(HttpClient httpClient )
        {
            this.httpClient = httpClient;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await httpClient.GetFromJsonAsync<Employee>($"api/employees/{id}");
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            /*
            //создаем новый объект HttpRequestMessage с методом GET и URL-адресом, к-ый хотим вызвать.
            //Затем используем экземпляр httpClient для асинхронной отправки запроса с помощью метода SendAsync.
            var request = new HttpRequestMessage(HttpMethod.Get, "api/employees");
            using var response = await httpClient.SendAsync(request);

            //Если ответ успешен, то читаем содержимое потока ответа как асинхронную операцию
            //с помощью метода ReadAsStreamAsync,
            //а затем десериализуем данные JSON в массив объектов Employee с помощью метода JsonSerializer.DeserializeAsync
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Employee[]>(responseStream);
            }
            throw new Exception($"Failed to retrieve employees: {response.ReasonPhrase}"); */

            return await httpClient.GetFromJsonAsync<Employee[]>($"api/employees");
        }

        public async Task<Employee> UpdateEmployee(Employee updatedEmployee)
        {
            //return await httpClient.PutAsJsonAsync($"api/employees", updatedEmployee);
            var response = await httpClient.PutAsJsonAsync("api/employees", updatedEmployee);
            response.EnsureSuccessStatusCode();
            var employeeResponse = await response.Content.ReadFromJsonAsync<Employee>();
            return employeeResponse;
        }
       
        public async Task<Employee> CreateEmployee(Employee newEmployee)
        {
            var response = await httpClient.PostAsJsonAsync("api/employees", newEmployee);
            response.EnsureSuccessStatusCode();
            var employeeResponse = await response.Content.ReadFromJsonAsync<Employee>();
            return employeeResponse;
        }

        public async Task DeleteEmployee(int id)
        {
            await httpClient.DeleteAsync($"api/employees/{id}");
        }
    }
}
    