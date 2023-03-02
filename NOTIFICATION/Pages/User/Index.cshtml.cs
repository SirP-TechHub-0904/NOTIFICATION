using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NOTIFICATION.Data;

namespace NOTIFICATION.Pages.User
{
    public class IndexModel : PageModel
    {
        private readonly NOTIFICATION.Data.ApplicationDbContext _context;
        private readonly UserManager<Data.Profile> _userManager;

        public IndexModel(NOTIFICATION.Data.ApplicationDbContext context, UserManager<Profile> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Profile> Users { get; set; }

        public async Task OnGetAsync()
        {
            var users = _userManager.Users.AsQueryable();
            TempData["result"] = users;
        }
    }
}
