using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAPI.Models.DarlosValley
{
    public class ImageSet
    {
        public Guid ID { get; set; }
        public Guid userID { get; set; }
        public string Image { get; set; }
        public string Caption { get; set; }
        public string Location { get; set; }
        public bool IsPick { get; set; }
    }
}
