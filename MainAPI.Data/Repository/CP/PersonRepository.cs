using MainAPI.Data.Interface.CP;
using MainAPI.Models.CP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAPI.Data.Repository.CP
{
    public class PersonRepository : GenericRepository<Person>, IPerson
    {
        public PersonRepository(MainAPIContext db) : base(db) { }
    }
}
