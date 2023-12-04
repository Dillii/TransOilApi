using Microsoft.EntityFrameworkCore;
using TransOilApi.DataBase.Models;

namespace TransOilApi.DataBase.Interfaces
{
    public interface IElectricEnergyMeterContext
    {
        /// <summary>
        /// Счётчкики электрической энергии
        /// </summary>
        public DbSet<ElectricEnergyMeter> ElectricEnergyMeters { get; set; }
    }
}
