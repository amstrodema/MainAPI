using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAPI.Models.DarlosValley
{
    public class Work
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Services { get; set; }
        public DateTime Date { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public int Stars { get; set; }
        public string Image { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public bool isPick { get; set; }
    }
}
