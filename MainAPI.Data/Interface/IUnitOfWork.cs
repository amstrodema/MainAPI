using MainAPI.Data.Interface.CP;
using MainAPI.Data.Interface.DarlosValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAPI.Data.Interface
{
    public interface IUnitOfWork
    {
        Task<int> Commit();
        void Rollback();

  
        IStatusEnum StatusEnums { get; }
        IBlog Blogs { get; }
        IWork Works { get; }
        IImageSet ImageSets { get; }
        Interface.CP.IUser CpUsers { get; }
        IPerson CpPersons { get; }
    }
}
