using Microsoft.EntityFrameworkCore;
using TransOilApi.DataBase.Models;

namespace TransOilApi.DataBase.Interfaces
{
    public interface IConsumptionObjectContext : IElectricityMeasurementPointContext, IElectricitySupplyPointsContext
    {
        /// <summary>
        /// Объекты потребления
        /// </summary>
        public DbSet<ConsumptionObject> ConsumptionObjects { get; set; }

        /// <summary>
        /// Расчётные приборы учёта
        /// </summary>
        public DbSet<CalculationMeter> CalculationMeters { get; set; }
    }
}
