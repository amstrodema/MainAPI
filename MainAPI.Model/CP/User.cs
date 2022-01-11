using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAPI.Models.CP
{
   public class User
    {
        public Guid ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //  public DateTime LastLogIn { get; set; }
        public bool IsLoggedIn { get; set; }
        public string IP { get; set; }
        public string MAC { get; set; }
        public string SystemDetails { get; set; }
    }
}
