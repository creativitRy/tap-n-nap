using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public int? BedID { get; set; }
        public Bed Bed { get; set; }
        
        public string UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public TapNapUser User { get; set; }
    }
}
