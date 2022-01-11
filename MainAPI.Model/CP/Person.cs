using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAPI.Models.CP
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
    }
}
