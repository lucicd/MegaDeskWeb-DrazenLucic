using Microsoft.EntityFrameworkCore;

namespace MegaDeskWeb_DrazenLucic.Models
{
    public class MegaDeskWeb_DrazenLucicContext : DbContext
    {
        public MegaDeskWeb_DrazenLucicContext (DbContextOptions<MegaDeskWeb_DrazenLucicContext> options)
            : base(options)
        {
        }

        public DbSet<MegaDeskWeb_DrazenLucic.Models.Parameter> Parameter { get; set; }

        public DbSet<MegaDeskWeb_DrazenLucic.Models.DeskQuote> DeskQuote { get; set; }

        public DbSet<MegaDeskWeb_DrazenLucic.Models.RushOrderCost> RushOrderCost { get; set; }

        public DbSet<MegaDeskWeb_DrazenLucic.Models.SurfaceMaterial> SurfaceMaterial { get; set; }
    }
}
