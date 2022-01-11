using MainAPI.Models;
using MainAPI.Models.CP;
using MainAPI.Models.DarlosValley;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAPI.Data
{
    public class MainAPIContext : DbContext
    {
        public MainAPIContext(DbContextOptions<MainAPIContext> options) : base(options) { }

        public virtual DbSet<Blog> DV_Blogs { get; set; }
        public virtual DbSet<ImageSet> DV_ImageSet { get; set; }
        public virtual DbSet<Work> DV_Work { get; set; }
        public virtual DbSet<User> CP_User { get; set; }
        public virtual DbSet<Person> CP_Person { get; set; }
    }
}
