using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskWeb_DrazenLucic.Models;
using MegaDeskWeb_DrazenLucic.Pages.Parameters;

namespace MegaDeskWeb_DrazenLucic.Pages.DeskQuotes
{
    public class CreateModel : PageModel
    {
        private readonly MegaDeskWeb_DrazenLucic.Models.MegaDeskWeb_DrazenLucicContext _context;

        public CreateModel(MegaDeskWeb_DrazenLucic.Models.MegaDeskWeb_DrazenLucicContext context)
        {
            _context = context;
        }

        public SelectList Drawers { get; set; }
        public SelectList Materials { get; set; }
        public SelectList ProductionTimes { get; set; }
        public IActionResult OnGet()
        {
            Drawers = new ParameterQueries(_context).ListOfDrawers;
            Materials = new SurfaceMaterialQueries(_context).ListOfMaterials;
            ProductionTimes = new RushOrderCostQueries(_context).ListOfPrdouctionTimes;
            return Page();
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

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
       
            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Details", new { id = DeskQuote.ID });
        }
    }
}