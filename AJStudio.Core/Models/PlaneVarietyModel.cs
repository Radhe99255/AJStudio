using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJStudio.Core.Models
{
    public class PlaneVarietyModel
    {
        public long PlaneVariety_Id { get; set; }
        public string? PlaneVariety { get; set; }
    }
}
