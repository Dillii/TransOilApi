using Microsoft.EntityFrameworkCore;
using TransOilApi.DataBase.Models;

namespace TransOilApi.DataBase.Interfaces
{
    public interface ITransformatorsContext
    {
        /// <summary>
        /// Трансформаторы тока
        /// </summary>
        public DbSet<CurrentTransformer> CurrentTransformers { get; set; }
        /// <summary>
        /// Трансформаторы напряжения
        /// </summary>
        public DbSet<VoltageTransformer> VoltageTransformers { get; set; }
    }
}
