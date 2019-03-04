﻿// <auto-generated />
using System;
using MegaDeskWeb_DrazenLucic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MegaDeskWeb_DrazenLucic.Migrations
{
    [DbContext(typeof(MegaDeskWeb_DrazenLucicContext))]
    partial class MegaDeskWeb_DrazenLucicContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MegaDeskWeb_DrazenLucic.Models.DeskQuote", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("BaseDeskPrice");

                    b.Property<string>("Customer");

                    b.Property<decimal>("DrawerSurcharge");

                    b.Property<int>("Length");

                    b.Property<int>("NumberOfDrawers");

                    b.Property<DateTime>("OrderDate");

                    b.Property<int>("ProductionTime");

                    b.Property<decimal>("RushOrderSurcharge");

                    b.Property<decimal>("SurfaceAreaSurcharge");

                    b.Property<int>("SurfaceAreaSurchargeThreshold");

                    b.Property<string>("SurfaceMaterial");

                    b.Property<decimal>("SurfaceMaterialSurcharge");

                    b.Property<int>("Width");

                    b.HasKey("ID");

                    b.ToTable("DeskQuote");
                });

            modelBuilder.Entity("MegaDeskWeb_DrazenLucic.Models.Parameter", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments");

                    b.Property<decimal>("Cost");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Parameter");
                });

            modelBuilder.Entity("MegaDeskWeb_DrazenLucic.Models.RushOrderCost", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AreaThreshold");

                    b.Property<decimal>("Cost");

                    b.Property<int>("Days");

                    b.HasKey("ID");

                    b.ToTable("RushOrderCost");
                });

            modelBuilder.Entity("MegaDeskWeb_DrazenLucic.Models.SurfaceMaterial", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cost");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("SurfaceMaterial");
                });
#pragma warning restore 612, 618
        }
    }
}
