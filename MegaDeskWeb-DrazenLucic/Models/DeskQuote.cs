using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskWeb_DrazenLucic.Models
{
    public class DeskQuote
    {
        public int ID { get; set; }
        public string Customer { get; set; }
        public decimal BaseDeskPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        public int Width { get; set; }
        public int Length { get; set; }

        public decimal SurfaceAreaSurcharge { get; set; }
        public int SurfaceAreaSurchargeThreshold { get; set; }

        public int NumberOfDrawers { get; set; }
        public decimal DrawerSurcharge { get; set; }

        public string SurfaceMaterial { get; set; }
        public decimal SurfaceMaterialSurcharge { get; set; }

        public int ProductionTime { get; set; }
        public decimal RushOrderSurcharge { get; set; }
    }
}
