using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NOTIFICATION.Data
{
    public enum AccontStatus
    {
       
        [Description("NONE")]
        NONE = 0,
        [Description("Active")]
        Active = 2,
        [Description("Pending")]
        Pending = 3,
        [Description("Suspended")]
        Suspended = 4,
        [Description("Expired")]
        Expired = 5

    }
    public enum AccontType
    {

        [Description("NONE")]
        NONE = 0,
        [Description("Hosting")]
        Hosting = 2,
        [Description("Domain")]
        Domain = 3,
        [Description("Website")]
        Website = 4,
       
    }


}