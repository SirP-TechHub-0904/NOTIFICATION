using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NOTIFICATION.Data;

namespace NOTIFICATION.Pages.Web
{
    public class EditModel : PageModel
    {
        private readonly NOTIFICATION.Data.ApplicationDbContext _context;

        public EditModel(NOTIFICATION.Data.ApplicationDbContext context)
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
            ViewData["ProfileId"] = new SelectList(_context.Clients, "Id", "Fullname");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Information).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InformationExists(Information.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InformationExists(long id)
        {
            return _context.Information.Any(e => e.Id == id);
        }
    }
}
