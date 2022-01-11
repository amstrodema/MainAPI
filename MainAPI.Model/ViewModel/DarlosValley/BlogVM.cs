using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAPI.Models.ViewModel.DarlosValley
{
    public class BlogVM
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string Image { get; set; }
        public DateTime DatePosted { get; set; }
        public string Subject { get; set; }
        public string Post { get; set; }
        public int Like { get; set; }
        public int View { get; set; }
        public bool isVideo { get; set; }
        public string VideoLink { get; set; }
        public bool isPick { get; set; }
    }
}
