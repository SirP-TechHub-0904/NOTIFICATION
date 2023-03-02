using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NOTIFICATION.Data
{
    public class RenewHistory
    {
        public long Id { get; set; }
        public string DateExpired { get; set; }
        public string DateRenewed { get; set; }
        public Decimal Amount { get; set; }

        public long InformationId { get; set; }
        public Information Information { get; set; }
    }
}
