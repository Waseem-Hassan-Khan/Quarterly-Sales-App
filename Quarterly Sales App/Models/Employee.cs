using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Quarterly_Sales_App.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [MinLength(3,ErrorMessage ="Name must be atleast 3 digits long.")]
        [DisplayName("First Name")]
        [MaxLength(30, ErrorMessage = "First Name is too long.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [MinLength(3, ErrorMessage = "Last Name must be atleast 3 digits long.")]
        [DisplayName("Last Name")]
        [MaxLength(30, ErrorMessage = "Name is too long.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]

        [DisplayName("Date Of Birth")]
        public DateTime DOB {  get; set; }

        [Required(ErrorMessage = "Date of hiring is required")]
        [DateNotLessThan1995(ErrorMessage = "Date should not be less than January 1, 1995")]
        [DisplayName("Date Of Hiring")]
        public DateTime DateOfHiring { get; set; }

        [DisplayName("Manager")]
        public string ManagerName {  get; set; }

        public class DateNotLessThan1995Attribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                if (value is DateTime date)
                {
                    return date >= new DateTime(1995, 1, 1);
                }
                return true;
            }
        }


    }
}
