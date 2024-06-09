using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJStudio.Core.Models
{
    public class ContactUsModel
    {
        public long Customer_Id { get; set; }

        [Required(ErrorMessage = "*First Name is Required")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "*First Name must be within 3 to 15 character")]
        [DataType(DataType.Text)]
        public string? First_Name { get; set; } = null;

		[DataType(DataType.Text)]
		public string? Last_Name { get; set; } = null;

        [Required(ErrorMessage = "*Mobile Number is Required")]
        [DataType(DataType.Text)]
        [MaxLength(10)]
        [RegularExpression("^\\d{10}$", ErrorMessage = "Mobile Number must have 10 digits")]
        public string? Mobile_Number { get; set; } = null;

        [Required(ErrorMessage = "*Email is Required")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; } = null;

        [Required(ErrorMessage = "*Please Select the State")]
        public string? State { get; set; } = null;

        [Required(ErrorMessage = "*Please Select the City")]
        public string? City { get; set; } = null;

        [Required(ErrorMessage = "*Please Select the Plane")]
        public string? Customer_Selected_Plane { get; set; } = null;

        [Required(ErrorMessage = "*Please Select Who Suggest You?")]
        public string? Suggested { get; set; } = null;

        [Required(ErrorMessage = "*Please Enter Your Address")]
        [DataType(DataType.Text)]
        public string? Address { get; set; } = null;
        public string? Customer_Comment { get; set; } = null;
    }
}
