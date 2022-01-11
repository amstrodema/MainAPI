using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAPI.Models.CP
{
    public class LogInParams
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
        public User User { get; set; }
        public Person Person { get; set; }
        public bool IsVerified { get; set; } = false;
    }
}
