using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskWeb_DrazenLucic.Models;

namespace MegaDeskWeb_DrazenLucic.Pages.SurfaceMaterials
{
    public class CreateModel : PageModel
    {
        private readonly MegaDeskWeb_DrazenLucic.Models.MegaDeskWeb_DrazenLucicContext _context;

        public CreateModel(MegaDeskWeb_DrazenLucic.Models.MegaDeskWeb_DrazenLucicContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SurfaceMaterial SurfaceMaterial { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SurfaceMaterial.Add(SurfaceMaterial);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}