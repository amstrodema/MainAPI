using MainAPI.Data.Interface;
using MainAPI.Data.Interface.CP;
using MainAPI.Data.Interface.DarlosValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAPI.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainAPIContext _db;


        public UnitOfWork(IStatusEnum statusEnums, IBlog blogs, IWork works, Interface.CP.IUser cpUsers, IPerson cpPersons, IImageSet imageSets, MainAPIContext db)
        {
            _db = db;
            StatusEnums = statusEnums;
            Blogs = blogs;
            Works = works;
            CpUsers = cpUsers;
            CpPersons = cpPersons;
            ImageSets = imageSets;
        }

    
        public IStatusEnum StatusEnums { get; }
        public IBlog Blogs { get; }
        public IWork Works { get; }
        public Interface.CP.IUser CpUsers { get; }
        public IPerson CpPersons { get; }
        public IImageSet ImageSets { get; }

        public async Task<int> Commit() =>
            await _db.SaveChangesAsync();

        public void Rollback() => Dispose();

        public void Dispose() =>
            _db.DisposeAsync();
    }
}
