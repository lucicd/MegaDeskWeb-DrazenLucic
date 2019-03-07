using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MegaDeskWeb_DrazenLucic.Models
{
    public class RushOrderCostQueries
    {
        private readonly MegaDeskWeb_DrazenLucicContext _context;

        public RushOrderCostQueries(MegaDeskWeb_DrazenLucicContext context)
        {
            _context = context;
        }

        public SelectList ListOfPrdouctionTimes
        {
            get
            {
                IQueryable<int> query = from m in _context.RushOrderCost
                                           orderby m.Days descending
                                           select m.Days;
                return new SelectList(query.Distinct().ToList());
            }
        }

        public decimal GetRushOrderSurcharge(int days, int width, int depth)
        {
            int area = width * depth;
            IQueryable<RushOrderCost> query = from m in _context.RushOrderCost select m;
            query = query.Where(p => p.Days == days && p.AreaThreshold <= area);
            query = query.OrderByDescending(p => p.AreaThreshold);
            var queryResults = query.ToList();
            return queryResults[0].Cost;
        }
    }
}
