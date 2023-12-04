using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransOilApi.DataBase.Models
{
    /// <summary>
    /// Счетчик электрической энергии
    /// </summary>
    [Index(nameof(Number), IsUnique = true)]
    public class ElectricEnergyMeter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id {  get; set; }
        /// <summary>
        /// Номер
        /// </summary>
        [Required(ErrorMessage = "Не задан номер счётчика электроэнергии")]
        public string Number { get; set; }
        /// <summary>
        /// Тип счётчика
        /// </summary>
        [Required(ErrorMessage = "Не задан тип счётчика электроэнергии")]
        public int Type { get; set; }
        /// <summary>
        /// Дата проверки
        /// </summary>
        [Column(TypeName = "timestamp without time zone")]
        [Required(ErrorMessage = "Не задано время проверки счётчика электроэнергии")]
        public DateTime CheckingDate { get; set; }

        public ElectricityMeasurementPoint? ElectricityMeasurementPoint { get; set; }
    }
}
