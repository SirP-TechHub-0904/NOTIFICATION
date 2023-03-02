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
    public class DetailsModel : PageModel
    {
        private readonly NOTIFICATION.Data.ApplicationDbContext _context;

        public DetailsModel(NOTIFICATION.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
