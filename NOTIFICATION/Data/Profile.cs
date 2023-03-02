using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NOTIFICATION.Data
{
    public class Profile : IdentityUser
    {
        
        public string Fullname { get; set; }
        public string Address { get; set; }
            
    }
}
