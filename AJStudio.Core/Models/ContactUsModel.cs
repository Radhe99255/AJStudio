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
        public string? First_Name { get; set; } = null;
        public string? Last_Name { get; set; } = null;
        public string? Mobile_Number { get; set; } = null;
        public string? Email { get; set; } = null;
        public string? State { get; set; } = null;
        public string? City { get; set; } = null;
        public string? Customer_Selected_Plane { get; set; } = null;
        public string? Suggested { get; set; } = null;
        public string? Address { get; set; } = null;
        public string? Customer_Comment { get; set; } = null;
    }
}
