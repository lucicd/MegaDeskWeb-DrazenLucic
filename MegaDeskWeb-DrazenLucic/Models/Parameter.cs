using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaDeskWeb_DrazenLucic.Models
{
    public class Parameter
    {
        
        public int ID { get; set; }

        [Display(Name = "Parameter#")]
        public string Name { get; set; }

        [Display(Name = "Value")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Value { get; set; }

        [Display(Name = "Comments")]
        public string Comments { get; set; }
    }
}
