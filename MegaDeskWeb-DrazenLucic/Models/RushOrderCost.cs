using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskWeb_DrazenLucic.Models
{
    public class RushOrderCost
    {
        public int ID { get; set; }
        public int Days { get; set; }
        public int AreaThreshold { get; set; }
        public decimal Cost { get; set; }
    }
}
