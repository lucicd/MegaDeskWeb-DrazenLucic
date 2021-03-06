﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaDeskWeb_DrazenLucic.Models
{
    public class DeskQuote
    {
        [Display(Name = "Quote#")]
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Customer { get; set; }

        [Display(Name = "Base Desk Price")]
        public decimal BaseDeskPrice { get; set; }

        [Required]
        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [Range(24, 96)]
        public int Width { get; set; }

        [Range(12, 48)]
        public int Depth { get; set; }

        [Display(Name = "Surface Area Surcharge per Unit")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal SurfaceAreaSurcharge { get; set; }
        [Display(Name = "Surface Area Surcharge Threshold")]
        public int SurfaceAreaSurchargeThreshold { get; set; }

        [Display(Name = "Drawers")]
        public int NumberOfDrawers { get; set; }
        [Display(Name = "Drawer Surcharge per Unit")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DrawerSurcharge { get; set; }

        [Required]
        [Display(Name = "Surface Material")]
        public string SurfaceMaterial { get; set; }

        [Display(Name = "Surface Material Surcharge")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal SurfaceMaterialSurcharge { get; set; }

        [Display(Name = "Production Time")]
        public int ProductionTime { get; set; }

        [Display(Name = "Rush Order Surcharge")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal RushOrderSurcharge { get; set; }

        [Display(Name = "Surface Area")]
        public int CalcSurfaceArea
        {
            get
            {
                return Width * Depth;
            }
        }

        [Display(Name = "Surface Area Surcharge")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CalcSurfaceAreaSurcharge
        {
            get
            {
                int surfaceArea = CalcSurfaceArea;
                if (surfaceArea > SurfaceAreaSurchargeThreshold)
                {
                    return (surfaceArea - SurfaceAreaSurchargeThreshold) * SurfaceAreaSurcharge;
                }
                else
                {
                    return 0;
                }
            }
        }

        [Display(Name = "Drawers Surcharge")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CalcDrawersSurcharge
        {
            get
            {
                return NumberOfDrawers * DrawerSurcharge;
            }
        }

        [Display(Name = "Desk Price")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CalcDeskPrice
        {
            get
            {
                return BaseDeskPrice + CalcSurfaceAreaSurcharge + CalcDrawersSurcharge
                    + SurfaceMaterialSurcharge + RushOrderSurcharge;
            }
        }
    }
}
