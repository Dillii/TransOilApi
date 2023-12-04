using Microsoft.EntityFrameworkCore;
using TransOilApi.DataBase.Models;

namespace TransOilApi.DataBase.Interfaces
{
    public interface IElectricityMeasurementPointContext : IElectricEnergyMeterContext, ITransformatorsContext, IEditableContext
    {
        /// <summary>
        /// Точки измерения электроэнергии
        /// </summary>
        public DbSet<ElectricityMeasurementPoint> ElectricityMeasurementPoints { get; set; }
    }
}
