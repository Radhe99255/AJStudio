using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJStudio.Data.DBTables
{
    public class ContactUsDBTable
    {
        [Key]
        [Column("Customer_Id")]
        public long Customer_Id { get; set; }

        [Column("First_Name")]
        public string? First_Name { get; set; } = null;
        
        [Column("Last_Name")]
        public string? Last_Name { get; set; } = null;

        [Column("Mobile_Number")]
        public string? Mobile_Number { get; set; } = null;

        [Column("Email")]
        public string? Email { get; set; } = null;

        [Column("State")]
        public string? State { get; set; } = null;

        [Column("City")]
        public string? City { get; set; } = null;

        [Column("Customer_Selected_Plane")]
        public string? Customer_Selected_Plane { get; set; } = null;

        [Column("Suggested")]
        public string? Suggested { get; set; } = null;

        [Column("Address")]
        public string? Address { get; set; } = null;

        [Column("Customer_Comment")]
        public string? Customer_Comment { get; set; } = null;
    }
}
