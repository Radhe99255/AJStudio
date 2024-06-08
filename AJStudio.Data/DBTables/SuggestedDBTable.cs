using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJStudio.Data.DBTables
{
    public class SuggestedDBTable
    {
        [Key]
        [Column("Suggested_Id")]
        public long Suggested_Id { get; set; }

        [Column("Suggested")]
        public string? Suggested { get; set; } = null;
    }
}
