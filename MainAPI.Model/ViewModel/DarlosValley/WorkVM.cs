using MainAPI.Models.DarlosValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAPI.Models.ViewModel.DarlosValley
{
    public class WorkVM
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string Services { get; set; }
        public DateTime Date { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public string Image { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public bool isPick { get; set; }
        public List<Work> Works { get; set; }
        public IEnumerable<ImageSet> Images { get; set; }
        public Work Work { get; set; }
    }
}
