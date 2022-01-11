using MainAPI.Data.Interface.DarlosValley;
using MainAPI.Models.DarlosValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAPI.Data.Repository.DarlosValley
{
    public class ImageSetRepository: GenericRepository<ImageSet>, IImageSet
    {
        public ImageSetRepository(MainAPIContext db):base(db) { }
        public async Task<IEnumerable<ImageSet>> GetImageWithLocation(string location)
        {
            return await GetBy(x => x.Location == location);
        }
        public async Task<IEnumerable<ImageSet>> GetImageWithLocationByEditor(string location)
        {
            return await GetBy(x => x.Location == location && x.IsPick);
        }
    }
}
