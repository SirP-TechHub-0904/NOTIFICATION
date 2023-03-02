using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NOTIFICATION.Data
{
    public class Information
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string AccountHosted { get; set; }
        public DateTime DateHosted { get; set; }
        public DateTime DateExpiring { get; set; }
        public DateTime DateRenewed { get; set; }
        public DateTime Date { get; set; }
        public DateTime DLastUpdateDate { get; set; }
        public string Description { get; set; }
        public string ClientId { get; set; }
        public Client Client { get; set; }

        public string HostAcccountId { get; set; }
        public HostAcccount HostAcccount { get; set; }


        public int Interval { get; set; }
        public AccontStatus AccontStatus { get; set; }
        public AccontType AccontType { get; set; }

        public ICollection<RenewHistory> RenewHistories { get; set; }
    }
}
