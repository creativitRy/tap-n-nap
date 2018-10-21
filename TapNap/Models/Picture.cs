using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TapNap.Models
{
    public class Picture
    {
        public int PictureID { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string Src { get; set; }

        public int BedID { get; set; }
        public Bed Bed { get; set; }
    }
}
