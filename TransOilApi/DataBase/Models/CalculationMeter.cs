using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransOilApi.DataBase.Models
{
    /// <summary>
    /// Расчетный прибор учета
    /// </summary>
    [Index(nameof(ElectricityMeasurementPointId), nameof(ElectricitySupplyPointId), IsUnique = true)]
    public class CalculationMeter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }

        /// <summary>
        /// Время начала, когда ТИ расчётная
        /// </summary>
        [Required(ErrorMessage = "Не задано Время конца, когда ТИ расчётная")]
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// Время конца, когда ТИ расчётная
        /// </summary>
        [Required(ErrorMessage = "Не задано время конца, когда ТИ расчётная")]
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? EndDate {  get; set; }

        [Required(ErrorMessage = "Не задан идентификатор точки измерения электроэнергии")]
        public long? ElectricityMeasurementPointId { get; set; }
        [Required(ErrorMessage = "Не задан идентификатор точки поставки электроэнергии")]
        public long? ElectricitySupplyPointId { get; set; }


        /// <summary>
        /// Точка измерения электроэнергии
        /// </summary>
        [ForeignKey(nameof(ElectricityMeasurementPointId))]
        public ElectricityMeasurementPoint ElectricityMeasurementPoint { get; set; }

        /// <summary>
        /// Точка поставки электроэнергии
        /// </summary>
        [ForeignKey(nameof(ElectricitySupplyPointId))]
        public ElectricitySupplyPoint ElectricitySupplyPoint { get; set; }
    }
}
