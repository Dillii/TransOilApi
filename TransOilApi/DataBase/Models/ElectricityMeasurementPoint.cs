using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TransOilApi.DataBase.Models
{
    /// <summary>
    /// Точка измерения электроэнергии
    /// </summary>
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(CurrentTransformerId), IsUnique = true)]
    [Index(nameof(VoltageTransformerId), IsUnique = true)]
    [Index(nameof(ElectricEnergyMeterId), IsUnique = true)]
    public class ElectricityMeasurementPoint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }


        public long? ConsumptionObjectId { get; set; }

        [ForeignKey(nameof(ConsumptionObjectId))]
        public ConsumptionObject? ConsumptionObject { get; set; }


        [Required(ErrorMessage = "Не задан идентификатор трансформатора тока")]
        public long? CurrentTransformerId { get; set; }
        [Required(ErrorMessage = "Не задан идентификатор трансформатора напряжения")]
        public long? VoltageTransformerId { get; set; }
        [Required(ErrorMessage = "Не задан идентификатор счётчика электрической энергии")]
        public long? ElectricEnergyMeterId { get; set; }


        [ForeignKey(nameof(CurrentTransformerId))]
        public CurrentTransformer CurrentTransformer { get; set; }
        [ForeignKey(nameof(VoltageTransformerId))]
        public VoltageTransformer VoltageTransformer { get; set; }
        [ForeignKey(nameof(ElectricEnergyMeterId))]
        public ElectricEnergyMeter ElectricEnergyMeter { get; set; }
    }
}
