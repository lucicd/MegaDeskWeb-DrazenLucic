using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb_DrazenLucic.Models;

namespace MegaDeskWeb_DrazenLucic.Pages.RushOrderCosts
{
    public class EditModel : PageModel
    {
        private readonly MegaDeskWeb_DrazenLucic.Models.MegaDeskWeb_DrazenLucicContext _context;

        public EditModel(MegaDeskWeb_DrazenLucic.Models.MegaDeskWeb_DrazenLucicContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RushOrderCost RushOrderCost { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RushOrderCost = await _context.RushOrderCost.FirstOrDefaultAsync(m => m.ID == id);

            if (RushOrderCost == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RushOrderCost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RushOrderCostExists(RushOrderCost.ID))
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

        private bool RushOrderCostExists(int id)
        {
            return _context.RushOrderCost.Any(e => e.ID == id);
        }
    }
}
