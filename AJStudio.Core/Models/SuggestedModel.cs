using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJStudio.Core.Models
{
    public class SuggestedModel
    {
        public long Suggested_Id { get; set; }
        public string? Suggested { get; set; } = null;
    }
}
