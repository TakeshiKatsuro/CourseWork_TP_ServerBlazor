using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly;
using System.Net.Http.Json;
using System.Text.Json;

namespace EmployeeManagement.Api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;
        public EmployeeService(HttpClient httpClient )
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            //return await httpClient.GetJsonAsync<Employee[]>("api/employees");

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

            throw new Exception($"Failed to retrieve employees: {response.ReasonPhrase}");
        }
    }
}
    