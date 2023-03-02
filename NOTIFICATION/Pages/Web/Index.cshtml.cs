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
    public class IndexModel : PageModel
    {
        private readonly NOTIFICATION.Data.ApplicationDbContext _context;

        public IndexModel(NOTIFICATION.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Information> Information { get;set; }

        public async Task OnGetAsync()
        {
            Information = await _context.Information
                .Include(i => i.Client).ToListAsync();
        }
    }
}
