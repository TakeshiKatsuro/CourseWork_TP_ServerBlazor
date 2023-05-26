using EmployeeManagement.Api;
using EmployeeManagement.Api.Services;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace CourseWork_TP_ServerBlazor.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {
        [Parameter]
        public Employee Employee { get; set; }

        [Parameter]
        public bool ShowFooter { get; set; }

        [Parameter]
        public EventCallback<bool> OnEmployeesSelection { get; set; }

        [Parameter]
        public EventCallback<int> OnEmployeesDeleted { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        /*protected ConfirmBase DeleteConfirmation { get; set; }

        protected void Delete_Click()
        {
            DeleteConfirmation.Show();
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await EmployeeService.DeleteEmployee(Employee.EmployeeId);
                await OnEmployeesDeleted.InvokeAsync(Employee.EmployeeId);
            }
        } */

        protected async Task Delete_Click()
        {
            await EmployeeService.DeleteEmployee(Employee.EmployeeId);
            await OnEmployeesDeleted.InvokeAsync(Employee.EmployeeId);
        }

        protected async Task CheckBoxChanged(ChangeEventArgs e)
        {
            await OnEmployeesSelection.InvokeAsync((bool)e.Value);
        }
    }
}
