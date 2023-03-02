using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NOTIFICATION.Data
{
    public class Client
    {
        public long Id { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
