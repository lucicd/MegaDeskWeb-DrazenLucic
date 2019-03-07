using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MegaDeskWeb_DrazenLucic.Models
{
    public class ParameterQueries
    {
        private readonly MegaDeskWeb_DrazenLucicContext _context;

        public ParameterQueries(MegaDeskWeb_DrazenLucicContext context)
        {
            _context = context;
        }

        public SelectList ListOfDrawers
        {
            get
            {
                // Use LINQ to get list of drawers.
                IQueryable<Parameter> paramQuery = from m in _context.Parameter select m;
                // Get the Max Drawers parameter and generate the list of possible drawers
                paramQuery = paramQuery.Where(s => s.Name.Equals("Max Drawers"));
                var queryResults = paramQuery.ToList();
                var myList = new List<int>();
                for (int i = 0; i <= queryResults[0].Value; i++)
                {
                    myList.Add(i);
                }
                return new SelectList(myList);
            }
        }

        public decimal GetBaseDeskPrice()
        {
            IQueryable<Parameter> paramQuery = from m in _context.Parameter select m;
            paramQuery = paramQuery.Where(s => s.Name.Equals("Base Desk Price"));
            var queryResults = paramQuery.ToList();
            return queryResults[0].Value;
        }

        public decimal GetSurfaceAreaSurchargePerUnit()
        {
            IQueryable<Parameter> paramQuery = from m in _context.Parameter select m;
            paramQuery = paramQuery.Where(s => s.Name.Equals("Surface Area Surcharge"));
            var queryResults = paramQuery.ToList();
            return queryResults[0].Value;
        }

        public int GetSurfaceAreaSurchargeThreshold()
        {
            IQueryable<Parameter> paramQuery = from m in _context.Parameter select m;
            paramQuery = paramQuery.Where(s => s.Name.Equals("Surface Area Surcharge Threshold"));
            var queryResults = paramQuery.ToList();
            return System.Convert.ToInt32(queryResults[0].Value);
        }

        public decimal GetDrawerCost()
        {
            IQueryable<Parameter> paramQuery = from m in _context.Parameter select m;
            paramQuery = paramQuery.Where(s => s.Name.Equals("Drawer Cost"));
            var queryResults = paramQuery.ToList();
            return queryResults[0].Value;
        }

        public decimal GetMinWidth()
        {
            IQueryable<Parameter> paramQuery = from m in _context.Parameter select m;
            paramQuery = paramQuery.Where(s => s.Name.Equals("Min Width"));
            var queryResults = paramQuery.ToList();
            return queryResults[0].Value;
        }

        public decimal GetMaxWidth()
        {
            IQueryable<Parameter> paramQuery = from m in _context.Parameter select m;
            paramQuery = paramQuery.Where(s => s.Name.Equals("Max Width"));
            var queryResults = paramQuery.ToList();
            return queryResults[0].Value;
        }

        public decimal GetMinDepth()
        {
            IQueryable<Parameter> paramQuery = from m in _context.Parameter select m;
            paramQuery = paramQuery.Where(s => s.Name.Equals("Min Depth"));
            var queryResults = paramQuery.ToList();
            return queryResults[0].Value;
        }

        public decimal GetMaxDepth()
        {
            IQueryable<Parameter> paramQuery = from m in _context.Parameter select m;
            paramQuery = paramQuery.Where(s => s.Name.Equals("Max Depth"));
            var queryResults = paramQuery.ToList();
            return queryResults[0].Value;
        }
    }
}
