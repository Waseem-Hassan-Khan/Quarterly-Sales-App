using System.ComponentModel.DataAnnotations;

namespace Quarterly_Sales_App.Models
{
    public class Sales
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1, 4, ErrorMessage = "Quarter must be between 1 and 4.")]
        public int Quarter { get; set; }

        [Required]
        [Range(2001, int.MaxValue, ErrorMessage = "Year must be after the year 2000.")]
        public int Year { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public long Amount { get; set; }

        [Required(ErrorMessage = "Employee name is required.")]
        public string EmployeeName { get; set; }
    }
}
