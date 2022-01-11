using MainAPI.Data.Interface.CP;
using MainAPI.Models.CP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAPI.Data.Repository.CP
{
   public class UserRepository : GenericRepository<User>, IUser
    {
        public UserRepository(MainAPIContext db) : base(db) { }
    }
}
