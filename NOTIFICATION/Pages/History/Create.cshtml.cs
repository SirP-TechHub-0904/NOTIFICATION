using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NOTIFICATION.Data;

namespace NOTIFICATION.Pages.History
{
    public class CreateModel : PageModel
    {
        private readonly NOTIFICATION.Data.ApplicationDbContext _context;

        public CreateModel(NOTIFICATION.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["InformationId"] = new SelectList(_context.Information, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public RenewHistory RenewHistory { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RenewHistory.Add(RenewHistory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
