using EmployeeManagement.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace CourseWork_TP_ServerBlazor.Models
{
    public class EditEmployeeModel
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "First Name must be provided")]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [CompareProperty("Email", ErrorMessage = "Email and Confirm must match")]
        public string ConfirmEmail { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        [Required]
        public int? DepartmentId { get; set; }
        public string PhotoPath { get; set; }
        //[ValidateComplexType]
        //public Department Department { get; set; } = new Department();
    }
}
