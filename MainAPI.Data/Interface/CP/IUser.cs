using MainAPI.Models.CP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MainAPI.Data.Interface.CP
{
    public interface IUser : IGeneric<User>
    {
        Task<IEnumerable<User>> GetBy(Expression<Func<User, bool>> expression);
        Task<User> GetOneBy(Expression<Func<User, bool>> expression);
    }
}
