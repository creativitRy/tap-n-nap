using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using TapNap.Models;

namespace TapNap.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the TapNapUser class
    public class TapNapUser : IdentityUser
    {
        public string Name { get; set; }

        public bool IsRenter { get; set; }

        public int SumOfRatings { get; set; }
        public int numRatings { get; set; }

        public IEnumerable<Rented> Renteds { get; set; }

    }
}
