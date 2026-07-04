using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using FirstMVCApp.Validations;

namespace MVCProject.Models
{
    public class StudentRegisterModel
    {
        [Required(ErrorMessage ="Student ID is required")]
        [StringLength(10, ErrorMessage = "Student ID cannot be longer than 10 characters")]
        public string StudentId { get; set; }

        
        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, ErrorMessage = "Name cannot be longer than 20 characters")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Age is required")]
        [Range(18, 40, ErrorMessage = "Age must be between 18 and 40")]
        public int Age { get; set; }


        [Required(ErrorMessage = "Date of birth is required")]
        [MinimumAge(18, ErrorMessage = "Student must be at least 18 years old")]
        public DateTime DateOfBirth { get; set; }


        [Required(ErrorMessage = "GPA is required")]
        [Range(0.0, 4.0, ErrorMessage = "GPA must be between 0.0 and 4.0")]
        public double GPA { get; set; }
    }
}
