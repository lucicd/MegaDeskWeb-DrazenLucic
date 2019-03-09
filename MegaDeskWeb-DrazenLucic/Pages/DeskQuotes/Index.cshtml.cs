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

        public string IDSort { get; set; }
        public string CustomerSort { get; set; }
        public string MaterialSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<DeskQuote> DeskQuote { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            sortOrder = String.IsNullOrEmpty(sortOrder) ? "id_desc" : sortOrder;
            CurrentSort = sortOrder;
            IDSort = sortOrder == "ID" ? "id_desc" : "ID";
            CustomerSort = sortOrder == "Customer" ? "customer_desc" : "Customer";
            MaterialSort = sortOrder == "SurfaceMaterial" ? "surfacematerial_desc" : "SurfaceMaterial";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

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
                case "customer_desc":
                    deskQuotes = deskQuotes.OrderByDescending(s => s.Customer);
                    break;
                case "Customer":
                    deskQuotes = deskQuotes.OrderBy(s => s.Customer);
                    break;
                case "surfacematerial_desc":
                    deskQuotes = deskQuotes.OrderByDescending(s => s.SurfaceMaterial);
                    break;
                case "SurfaceMaterial":
                    deskQuotes = deskQuotes.OrderBy(s => s.SurfaceMaterial);
                    break;
                case "id_desc":
                    deskQuotes = deskQuotes.OrderByDescending(s => s.ID);
                    break;
                default:
                    deskQuotes = deskQuotes.OrderBy(s => s.ID);
                    break;
            }

            int pageSize = 5;
            DeskQuote = await PaginatedList<DeskQuote>.CreateAsync(
                deskQuotes.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
