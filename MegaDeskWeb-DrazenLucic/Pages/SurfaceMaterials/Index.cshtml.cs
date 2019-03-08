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
    public class IndexModel : PageModel
    {
        private readonly MegaDeskWeb_DrazenLucic.Models.MegaDeskWeb_DrazenLucicContext _context;

        public IndexModel(MegaDeskWeb_DrazenLucic.Models.MegaDeskWeb_DrazenLucicContext context)
        {
            _context = context;
        }

        public PaginatedList<SurfaceMaterial> SurfaceMaterial { get;set; }
        public string NameSort { get; set; }
        public string CostSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
     

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            CostSort = String.IsNullOrEmpty(sortOrder) ? "cost_desc" : "";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<SurfaceMaterial> materialIQ = from s in _context.SurfaceMaterial
                                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                materialIQ = materialIQ.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    materialIQ = materialIQ.OrderByDescending(s => s.Name);
                    break;
                case "cost_desc":
                    materialIQ = materialIQ.OrderByDescending(s => s.Cost);
                    break;
                default:
                    materialIQ = materialIQ.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 3;
            SurfaceMaterial = await PaginatedList<SurfaceMaterial>.CreateAsync(
                materialIQ.AsNoTracking(), pageIndex ?? 1, pageSize);


        }
    }
}
