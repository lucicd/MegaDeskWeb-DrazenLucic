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

        public PaginatedList<DeskQuote> DeskQuote { get;set; }

        public async Task OnGetAsync(int? pageIndex)
        {
            var deskQuotes = from m in _context.DeskQuote
                             orderby m.ID descending
                             select m;
            int pageSize = 5;
            DeskQuote = await PaginatedList<DeskQuote>.CreateAsync(
                deskQuotes.AsNoTracking(), pageIndex ?? 1, pageSize);
            //DeskQuote = await deskQuotes.ToListAsync();
        }
    }
}
