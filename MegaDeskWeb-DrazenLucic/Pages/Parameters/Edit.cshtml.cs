using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb_DrazenLucic.Models;

namespace MegaDeskWeb_DrazenLucic.Pages.Parameters
{
    public class EditModel : PageModel
    {
        private readonly MegaDeskWeb_DrazenLucic.Models.MegaDeskWeb_DrazenLucicContext _context;

        public EditModel(MegaDeskWeb_DrazenLucic.Models.MegaDeskWeb_DrazenLucicContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Parameter Parameter { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Parameter = await _context.Parameter.FirstOrDefaultAsync(m => m.ID == id);

            if (Parameter == null)
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

            _context.Attach(Parameter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParameterExists(Parameter.ID))
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

        private bool ParameterExists(int id)
        {
            return _context.Parameter.Any(e => e.ID == id);
        }
    }
}
