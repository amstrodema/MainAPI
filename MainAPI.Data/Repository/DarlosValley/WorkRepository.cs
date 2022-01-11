using MainAPI.Data.Interface.DarlosValley;
using MainAPI.Models.DarlosValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAPI.Data.Repository.DarlosValley
{
    public class WorkRepository : GenericRepository<Work>, IWork
    {
        public WorkRepository(MainAPIContext db) : base(db) { }
        public async Task<IEnumerable<Work>> GetSelected()
        {
            return await GetBy(x => x.isPick);
        }
    }
}
