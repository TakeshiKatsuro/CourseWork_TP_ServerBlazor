using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWork_TP_ServerBlazor.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        public IEnumerable<Employee> Employees { get; set; }

        //protected override Task OnInitializedAsync()
        protected override async Task OnInitializedAsync()
        {
            await Task.Run(LoadEmployees);
            //LoadEmployees();
            //return base.OnInitializedAsync();
        }

        private void LoadEmployees()
        {
            System.Threading.Thread.Sleep(3000);
            Employee e1 = new Employee
            {
                EmployeeId = 1,
                FirstName = "John",
                LastName = "Hastings",
                Email = "David@pragimtech.com",
                DateOfBirth = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/john.png"
            };

            Employee e2 = new Employee
            {
                EmployeeId = 2,
                FirstName = "Sam",
                LastName = "Galloway",
                Email = "Sam@pragimtech.com",
                DateOfBirth = new DateTime(1981, 12, 22),
                Gender = Gender.Male,
                DepartmentId = 2,
                PhotoPath = "images/sam.jpg"
            };

            Employee e3 = new Employee
            {
                EmployeeId = 3,
                FirstName = "Mary",
                LastName = "Smith",
                Email = "mary@pragimtech.com",
                DateOfBirth = new DateTime(1979, 11, 11),
                Gender = Gender.Female,
                DepartmentId = 3,
                PhotoPath = "images/mary.png"
            };

            Employee e4 = new Employee
            {
                EmployeeId = 3,
                FirstName = "Sara",
                LastName = "Longway",
                Email = "sara@pragimtech.com",
                DateOfBirth = new DateTime(1982, 9, 23),
                Gender = Gender.Female,
                DepartmentId = 4,
                PhotoPath = "images/sara.png"
            };

            Employees = new List<Employee> { e1, e2, e3, e4 };
        }
    }
}

