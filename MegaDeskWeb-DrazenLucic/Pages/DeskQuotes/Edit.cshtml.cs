using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb_DrazenLucic.Models;

namespace MegaDeskWeb_DrazenLucic.Pages.DeskQuotes
{
    public class EditModel : PageModel
    {
        private readonly MegaDeskWeb_DrazenLucic.Models.MegaDeskWeb_DrazenLucicContext _context;

        public EditModel(MegaDeskWeb_DrazenLucic.Models.MegaDeskWeb_DrazenLucicContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        public SelectList Drawers { get; set; }
        public SelectList Materials { get; set; }
        public SelectList ProductionTimes { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeskQuote = await _context.DeskQuote.FirstOrDefaultAsync(m => m.ID == id);

            if (DeskQuote == null)
            {
                return NotFound();
            }
            Drawers = new ParameterQueries(_context).ListOfDrawers;
            Materials = new SurfaceMaterialQueries(_context).ListOfMaterials;
            ProductionTimes = new RushOrderCostQueries(_context).ListOfPrdouctionTimes;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var parameterQueries = new ParameterQueries(_context);
            DeskQuote.BaseDeskPrice = parameterQueries.GetBaseDeskPrice();
            DeskQuote.SurfaceAreaSurcharge = parameterQueries.GetSurfaceAreaSurchargePerUnit();
            DeskQuote.SurfaceAreaSurchargeThreshold = parameterQueries.GetSurfaceAreaSurchargeThreshold();
            DeskQuote.DrawerSurcharge = parameterQueries.GetDrawerCost();

            DeskQuote.SurfaceMaterialSurcharge = new SurfaceMaterialQueries(_context)
                .GetSurfaceMaterislSurcharge(DeskQuote.SurfaceMaterial);

            DeskQuote.RushOrderSurcharge = new RushOrderCostQueries(_context)
                .GetRushOrderSurcharge(DeskQuote.ProductionTime, DeskQuote.Width, DeskQuote.Depth);

            _context.Attach(DeskQuote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeskQuoteExists(DeskQuote.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Details", new { id = DeskQuote.ID });
        }

        private bool DeskQuoteExists(int id)
        {
            return _context.DeskQuote.Any(e => e.ID == id);
        }
    }
}
