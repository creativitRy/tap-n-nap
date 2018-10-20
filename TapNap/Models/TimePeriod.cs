using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TapNap.Models
{
    public class TimePeriod
    {
        public int TimePeriodID { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int BedID { get; set; }
        public Bed Bed { get; set; }
    }
}