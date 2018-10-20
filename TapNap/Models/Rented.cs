using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TapNap.Areas.Identity.Data;

namespace TapNap.Models
{
    public class Rented
    {
        public int RentedID { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int BedID { get; set; }
        public Bed Bed { get; set; }

        [Required]
        public string UserID { get; set; }
        public TapNapUser User { get; set; }
    }
}
