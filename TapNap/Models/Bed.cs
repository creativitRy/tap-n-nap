using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TapNap.Areas.Identity.Data;

namespace TapNap.Models
{
    public class Bed
    {
        public int BedID { get; set; }

        [Required]
        public string Address { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string Description { get; set; }
        
        [Column(TypeName = "decimal(7, 2)")]
        public decimal PricePerHour { get; set; }
        
        public string UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public TapNapUser User { get; set; }

        public IEnumerable<BedRating> BedRatings { get; set; }
        public IEnumerable<TimePeriod> TimePeriods { get; set; }
        public IEnumerable<Rented> Renteds { get; set; }
        public IEnumerable<Picture> Pictures { get; set; }

    }
}
