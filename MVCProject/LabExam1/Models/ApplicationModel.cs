using System.ComponentModel.DataAnnotations;

namespace LabExam1.Models
{
    public class ApplicationModel
    {
        [Required(ErrorMessage ="Applicant's name is required")]
        [StringLength(60, ErrorMessage = "Name must be between 3 and 60 characters")]
        public string ApplicantName { get; set; }


        [Required(ErrorMessage = "Applicant's email is required")]
        [EmailAddress(ErrorMessage = "Enter valid email address")]
        public string ApplicantEmail { get; set; }


        [Required(ErrorMessage = "Destination country is required")]
        [StringLength(50, ErrorMessage = "Destination country must be in 50 characters")]
        public string DestinationCountry { get; set; }


        [Required(ErrorMessage = "Duration must me between 1 to 90 days")]
        [Range(1, 90, ErrorMessage = "Duration must be between 1 and 90 days")]
        public int Duration { get; set; }


        [Required(ErrorMessage = "Travel date is required")]
        public DateTime TravelDate { get; set; }
    }
}
