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
    public class DeleteModel : PageModel
    {
        private readonly NOTIFICATION.Data.ApplicationDbContext _context;

        public DeleteModel(NOTIFICATION.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RenewHistory = await _context.RenewHistory.FindAsync(id);

            if (RenewHistory != null)
            {
                _context.RenewHistory.Remove(RenewHistory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
