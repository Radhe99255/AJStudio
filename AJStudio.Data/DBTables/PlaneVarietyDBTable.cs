using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJStudio.Data.DBTables
{
    public class PlaneVarietyDBTable
    {
        [Key]
        [Column("PlaneVariety_Id")]
        public long PlaneVariety_Id { get; set; }

        [Column("PlaneVariety")]
        public string? PlaneVariety { get; set; }
    }
}
