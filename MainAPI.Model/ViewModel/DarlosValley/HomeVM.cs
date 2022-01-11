using MainAPI.Models.DarlosValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAPI.Models.ViewModel.DarlosValley
{
    public class HomeVM
    {
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<Work> Works { get; set; }
        public IEnumerable<ImageSet> Graphics { get; set; }
        public IEnumerable<Blog> Headlines { get; set; }
    }
}
