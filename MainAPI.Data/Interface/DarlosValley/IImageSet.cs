using MainAPI.Models.DarlosValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAPI.Data.Interface.DarlosValley
{
    public interface IImageSet: IGeneric<ImageSet>
    {
        Task<IEnumerable<ImageSet>> GetImageWithLocation(string location);
        Task<IEnumerable<ImageSet>> GetImageWithLocationByEditor(string location);
    }
}
