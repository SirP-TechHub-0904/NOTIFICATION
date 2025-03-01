﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NOTIFICATION.Data;

namespace NOTIFICATION.Pages.History
{
    public class EditModel : PageModel
    {
        private readonly NOTIFICATION.Data.ApplicationDbContext _context;

        public EditModel(NOTIFICATION.Data.ApplicationDbContext context)
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
           ViewData["InformationId"] = new SelectList(_context.Information, "Id", "Id");
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

            _context.Attach(RenewHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RenewHistoryExists(RenewHistory.Id))
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

        private bool RenewHistoryExists(long id)
        {
            return _context.RenewHistory.Any(e => e.Id == id);
        }
    }
}
