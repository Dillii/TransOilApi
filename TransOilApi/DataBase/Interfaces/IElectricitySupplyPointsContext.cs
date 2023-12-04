using Microsoft.EntityFrameworkCore;
using TransOilApi.DataBase.Models;

namespace TransOilApi.DataBase.Interfaces
{
    public interface IElectricitySupplyPointsContext : IEditableContext
    {
        /// <summary>
        /// Точки поставки электроэнергии
        /// </summary>
        public DbSet<ElectricitySupplyPoint> ElectricitySupplyPoints { get; set; }
    }
}
