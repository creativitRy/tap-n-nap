using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TapNap.Models
{
    public class BedRating
    {
        public int BedRatingID { get; set; }

        public int Rating { get; set; }
        public string Review { get; set; }

        public int BedID { get; set; }
        public Bed Bed { get; set; }
    }
}
