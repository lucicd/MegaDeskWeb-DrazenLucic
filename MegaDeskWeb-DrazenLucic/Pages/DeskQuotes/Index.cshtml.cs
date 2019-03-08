using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb_DrazenLucic.Models;

namespace MegaDeskWeb_DrazenLucic.Pages.DeskQuotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDeskWeb_DrazenLucic.Models.MegaDeskWeb_DrazenLucicContext _context;

        public IndexModel(MegaDeskWeb_DrazenLucic.Models.MegaDeskWeb_DrazenLucicContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string MaterialSort { get; set; }
        public string CurrentFilter { get; set; }

        public PaginatedList<DeskQuote> DeskQuote { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString, int? pageIndex)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            MaterialSort = sortOrder == "material" ? "material_desc" : "material";
            CurrentFilter = searchString;

            var deskQuotes = from m in _context.DeskQuote
                             select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                deskQuotes = deskQuotes.Where(s => s.Customer.Contains(searchString)
                                       || s.SurfaceMaterial.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    deskQuotes = deskQuotes.OrderByDescending(s => s.Customer);
                    break;
                case "material_desc":
                    deskQuotes = deskQuotes.OrderByDescending(s => s.SurfaceMaterial);
                    break;
                case "material":
                    deskQuotes = deskQuotes.OrderBy(s => s.SurfaceMaterial);
                    break;
                default:
                    deskQuotes = deskQuotes.OrderBy(s => s.Customer);
                    break;
            }

            int pageSize = 5;
            DeskQuote = await PaginatedList<DeskQuote>.CreateAsync(
                deskQuotes.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
