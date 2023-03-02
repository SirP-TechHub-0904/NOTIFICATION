using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NOTIFICATION.Data;

namespace NOTIFICATION.Pages.History
{
    public class IndexModel : PageModel
    {
        private readonly NOTIFICATION.Data.ApplicationDbContext _context;

        public IndexModel(NOTIFICATION.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<RenewHistory> RenewHistory { get;set; }

        public async Task OnGetAsync()
        {
            RenewHistory = await _context.RenewHistory
                .Include(r => r.Information).ToListAsync();
        }
    }
}
