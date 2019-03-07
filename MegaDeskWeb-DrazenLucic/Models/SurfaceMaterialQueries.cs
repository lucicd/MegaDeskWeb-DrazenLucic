using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MegaDeskWeb_DrazenLucic.Models
{
    public class SurfaceMaterialQueries
    {
        private readonly MegaDeskWeb_DrazenLucicContext _context;

        public SurfaceMaterialQueries(MegaDeskWeb_DrazenLucicContext context)
        {
            _context = context;
        }

        public SelectList ListOfMaterials
        {
            get
            {
                IQueryable<string> query = from m in _context.SurfaceMaterial
                                                    orderby m.Name
                                                    select m.Name;
                return new SelectList(query.ToList());
            }
        }

        public decimal GetSurfaceMaterislSurcharge(string material)
        {
            IQueryable<SurfaceMaterial> query = from m in _context.SurfaceMaterial select m;
            query = query.Where(s => s.Name.Equals(material));
            var queryResults = query.ToList();
            return queryResults[0].Cost;
        }
    }
}
