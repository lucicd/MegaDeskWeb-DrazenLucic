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

        public string IDSort{ get; set;}
        public string NameSort { get; set; }
        public string ValueSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Parameter> Parameter { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            sortOrder = String.IsNullOrEmpty(sortOrder) ? "id_desc" : sortOrder;
            CurrentSort = sortOrder;
            IDSort = sortOrder == "ID" ? "id_desc" : "ID";
            NameSort = sortOrder == "Name" ? "name_desc" : "Name";
            ValueSort = sortOrder == "Value" ? "value_desc" : "Value";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            var parameters = from m in _context.DeskQuote
                             select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                parameters = parameters.Where(s => s.Customer.Contains(searchString)
                                       || s.SurfaceMaterial.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    parameters = parameters.OrderByDescending(s => s.Customer);
                    break;
                case "Name":
                    parameters = parameters.OrderBy(s => s.Customer);
                    break;
                case "value_desc":
                    parameters = parameters.OrderByDescending(s => s.SurfaceMaterial);
                    break;
                case "Value":
                    parameters = parameters.OrderBy(s => s.SurfaceMaterial);
                    break;
                case "id_desc":
                    parameters = parameters.OrderByDescending(s => s.ID);
                    break;
                default:
                    parameters = parameters.OrderBy(s => s.ID);
                    break;
            }

            int pageSize = 5;
            Parameter = await PaginatedList<Parameter>.CreateAsync(
                parameters.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
