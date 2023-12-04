using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using TransOilApi.DataBase.Interfaces;
using TransOilApi.DataBase.Models;

namespace TransOilApi.DataBase
{
    public class TransOilContext : DbContext, IConsumptionObjectContext, IOrganizationsContext
    {
        /// <summary>
        /// Дочерние организации
        /// </summary>
        public DbSet<ChildOrganization> ChildOrganizations { get; set; }
        /// <summary>
        /// Организации
        /// </summary>
        public DbSet<Organisation> Organizations { get; set; }


        /// <summary>
        /// Объекты потребления
        /// </summary>
        public DbSet<ConsumptionObject> ConsumptionObjects { get; set; }


        /// <summary>
        /// Расчётные приборы учёта
        /// </summary>
        public DbSet<CalculationMeter> CalculationMeters { get; set; }

        /// <summary>
        /// Точки поставки электроэнергии
        /// </summary>
        public DbSet<ElectricitySupplyPoint> ElectricitySupplyPoints { get; set; }


        /// <summary>
        /// Точки измерения электроэнергии
        /// </summary>
        public DbSet<ElectricityMeasurementPoint> ElectricityMeasurementPoints { get; set; }


        /// <summary>
        /// Счётчкики электрической энергии
        /// </summary>
        public DbSet<ElectricEnergyMeter> ElectricEnergyMeters { get; set; }


        /// <summary>
        /// Трансформаторы тока
        /// </summary>
        public DbSet<CurrentTransformer> CurrentTransformers { get; set; }
        /// <summary>
        /// Трансформаторы напряжения
        /// </summary>
        public DbSet<VoltageTransformer> VoltageTransformers { get; set; }



        public TransOilContext() { }

        public TransOilContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TransOilApi");
        }
    }
}
