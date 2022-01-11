using MainAPI.Models.DarlosValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAPI.Data.Interface.DarlosValley
{
    public interface IWork : IGeneric<Work>
    {
        Task<IEnumerable<Work>> GetSelected();
    }
}
