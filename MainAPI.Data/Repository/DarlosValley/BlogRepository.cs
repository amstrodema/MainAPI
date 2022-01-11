using MainAPI.Data.Interface.DarlosValley;
using MainAPI.Models.DarlosValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAPI.Data.Repository.DarlosValley
{
    public class BlogRepository : GenericRepository<Blog>, IBlog
    {
        public BlogRepository(MainAPIContext db) : base(db) { }
        public async Task<IEnumerable<Blog>> GetSelected()
        {
            return await GetBy(x => x.isPick);
        }
    }
}
