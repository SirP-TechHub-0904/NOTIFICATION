using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NOTIFICATION.Data;

namespace NOTIFICATION.Pages.Web
{
    public class DeleteModel : PageModel
    {
        private readonly NOTIFICATION.Data.ApplicationDbContext _context;

        public DeleteModel(NOTIFICATION.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Information Information { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Information = await _context.Information
                .Include(i => i.Client).FirstOrDefaultAsync(m => m.Id == id);

            if (Information == null)
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

            Information = await _context.Information.FindAsync(id);

            if (Information != null)
            {
                _context.Information.Remove(Information);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
