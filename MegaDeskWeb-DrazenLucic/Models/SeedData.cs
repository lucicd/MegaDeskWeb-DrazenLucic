using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskWeb_DrazenLucic.Models
{
    public class SeedData
    {
        private static void SeedParameters(MegaDeskWeb_DrazenLucicContext context)
        {
            if (context.Parameter.Any())
            {
                return;
            }
            context.Parameter.AddRange(
                new Parameter
                {
                    Name = "Base Desk Cost",
                    Cost = 200,
                    Comments = "each"
                },

                new Parameter
                {
                    Name = "Surface Area Surcharge",
                    Cost = 1,
                    Comments = "per square inch"
                },

                new Parameter
                {
                    Name = "Surface Area Surcharge Threshold",
                    Cost = 1000,
                    Comments = "square inches"
                },

                new Parameter
                {
                    Name = "Drawer Cost",
                    Cost = 50,
                    Comments = "per drawer"
                }
            );
            context.SaveChanges();
        }

        private static void SeedSurfaceMaterials(MegaDeskWeb_DrazenLucicContext context)
        {
            if (context.SurfaceMaterial.Any())
            {
                return;
            }
            context.SurfaceMaterial.AddRange(
                new SurfaceMaterial
                {
                    Name = "Oak",
                    Cost = 200
                },
                new SurfaceMaterial
                {
                    Name = "Laminate",
                    Cost = 100
                },
                new SurfaceMaterial
                {
                    Name = "Pine",
                    Cost = 50
                },
                new SurfaceMaterial
                {
                    Name = "Rosewood",
                    Cost = 300
                },
                new SurfaceMaterial
                {
                    Name = "Veneer",
                    Cost = 125
                }
            );
            context.SaveChanges();
        }

        private static void SeedRushOrderCosts(MegaDeskWeb_DrazenLucicContext context)
        {
            if (context.RushOrderCost.Any())
            {
                return;
            }
            context.RushOrderCost.AddRange(
                new RushOrderCost
                {
                    Days = 3,
                    AreaThreshold = 0,
                    Cost = 60
                },
                 new RushOrderCost
                 {
                     Days = 3,
                     AreaThreshold = 1000,
                     Cost = 70
                 },
                new RushOrderCost
                {
                    Days = 3,
                    AreaThreshold = 2000,
                    Cost = 80
                },
                new RushOrderCost
                {
                    Days = 5,
                    AreaThreshold = 0,
                    Cost = 40
                },
                new RushOrderCost
                {
                    Days = 5,
                    AreaThreshold = 1000,
                    Cost = 50
                },
                new RushOrderCost
                {
                    Days = 5,
                    AreaThreshold = 2000,
                    Cost = 60
                },
                new RushOrderCost
                {
                    Days = 7,
                    AreaThreshold = 0,
                    Cost = 30
                },
                new RushOrderCost
                {
                    Days = 7,
                    AreaThreshold = 1000,
                    Cost = 35
                },
                new RushOrderCost
                {
                    Days = 7,
                    AreaThreshold = 2000,
                    Cost = 40
                },
                new RushOrderCost
                {
                    Days = 14,
                    AreaThreshold = 0,
                    Cost = 0
                }
            );
            context.SaveChanges();
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MegaDeskWeb_DrazenLucicContext(
                serviceProvider.GetRequiredService<DbContextOptions<MegaDeskWeb_DrazenLucicContext>>()))
            {
                SeedParameters(context);
                SeedSurfaceMaterials(context);
                SeedRushOrderCosts(context);
            }
        }
    }
}
