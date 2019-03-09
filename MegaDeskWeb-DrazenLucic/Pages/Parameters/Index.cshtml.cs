using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb_DrazenLucic.Models;

namespace MegaDeskWeb_DrazenLucic.Pages.Parameters
{
    public class IndexModel : PageModel
    {
        private readonly MegaDeskWeb_DrazenLucic.Models.MegaDeskWeb_DrazenLucicContext _context;

        public IndexModel(MegaDeskWeb_DrazenLucic.Models.MegaDeskWeb_DrazenLucicContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }

        public PaginatedList<Parameter> Parameter { get;set; }

        public async Task OnGetAsync(string sortOrder, int? pageIndex)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var parameters = from m in _context.Parameter
                             select m;

            switch (sortOrder)
            {
                case "name_desc":
                    parameters = parameters.OrderByDescending(s => s.Name);
                    break;
                default:
                    parameters = parameters.OrderBy(s => s.Name);
                    break;
            }


            int pageSize = 5;
            ParameterQueries = await PaginatedList<DeskQuote>.CreateAsync(
                parameters.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
