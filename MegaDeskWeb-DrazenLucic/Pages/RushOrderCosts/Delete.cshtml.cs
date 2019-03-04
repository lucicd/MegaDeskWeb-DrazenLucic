using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb_DrazenLucic.Models;

namespace MegaDeskWeb_DrazenLucic.Pages.RushOrderCosts
{
    public class DeleteModel : PageModel
    {
        private readonly MegaDeskWeb_DrazenLucic.Models.MegaDeskWeb_DrazenLucicContext _context;

        public DeleteModel(MegaDeskWeb_DrazenLucic.Models.MegaDeskWeb_DrazenLucicContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RushOrderCost = await _context.RushOrderCost.FindAsync(id);

            if (RushOrderCost != null)
            {
                _context.RushOrderCost.Remove(RushOrderCost);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
