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
        public IEnumerable<Employee> MyProperty { get; set; }
    }
}

