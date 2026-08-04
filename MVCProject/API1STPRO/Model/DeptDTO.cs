using System.ComponentModel.DataAnnotations;

namespace API1STPRO.Model
{
    public class DeptDTO
    {
        [Required]
        public int DeptId { get; set; }

        [Required]
        public string DeptName { get; set; } = null!;

        [Required]
        public string DeptLocation { get; set; } = null!;
    }
}
