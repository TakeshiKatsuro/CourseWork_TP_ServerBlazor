using EmployeeManagement.Api.Services;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Threading.Tasks;

namespace CourseWork_TP_ServerBlazor.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        //свойство координаты 
        protected string Coordinates { get; set; }

        protected string ButtonText { get; set; } = "Hide";
        protected string CssClass { get; set; } = null;

        //общедоступное свойство Employee типа Employee
        public Employee Employee { get; set; } = new Employee();

        [Inject] //создали свойство, внедрили службу IEmployee
        public IEmployeeService EmployeeService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
        }

        protected void Mouse_Move(MouseEventArgs e) //метод-обработчик событий 
        {
            Coordinates = $"x: {e.ClientX} y: {e.ClientY}";
        }

        protected void Button_Click()
        {
            if (ButtonText == "Hide")
            {
                ButtonText = "Show";
                CssClass = "HideFooter";
            }
            else
            {
                CssClass = null;
                ButtonText = "Hide";
            }
        }
    }
}
