using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb_DrazenLucic.Models;

namespace MegaDeskWeb_DrazenLucic.Pages.SurfaceMaterials
{
    public class DetailsModel : PageModel
    {
        private readonly MegaDeskWeb_DrazenLucic.Models.MegaDeskWeb_DrazenLucicContext _context;

        public DetailsModel(MegaDeskWeb_DrazenLucic.Models.MegaDeskWeb_DrazenLucicContext context)
        {
            _context = context;
        }

        public SurfaceMaterial SurfaceMaterial { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SurfaceMaterial = await _context.SurfaceMaterial.FirstOrDefaultAsync(m => m.ID == id);

            if (SurfaceMaterial == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
