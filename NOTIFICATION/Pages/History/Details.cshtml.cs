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
    public class DetailsModel : PageModel
    {
        private readonly NOTIFICATION.Data.ApplicationDbContext _context;

        public DetailsModel(NOTIFICATION.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public RenewHistory RenewHistory { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RenewHistory = await _context.RenewHistory
                .Include(r => r.Information).FirstOrDefaultAsync(m => m.Id == id);

            if (RenewHistory == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
