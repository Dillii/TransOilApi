using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace TransOilApi.DataBase.Models
{
    /// <summary>
    /// Трансформатор напряжения
    /// </summary>
    [Index(nameof(Number), IsUnique = true)]
    public class VoltageTransformer
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }
        /// <summary>
        /// Номер
        /// </summary>
        [Required(ErrorMessage = "Не задан номер трансформатора напряжения")]
        public string Number { get; set; }
        /// <summary>
        /// Тип трансформатора напряжения
        /// </summary>
        [Required(ErrorMessage = "Не задан тип трансформатора напряжения")]
        public int Type { get; set; }
        /// <summary>
        /// Дата проверки
        /// </summary>
        [Column(TypeName = "timestamp without time zone")]
        [Required(ErrorMessage = "Не задано время проверки трансформатора напряжения")]
        public DateTime CheckingDate { get; set; }
        /// <summary>
        /// Коэффициент трансформации
        /// </summary>
        [Required(ErrorMessage = "Не задан коэффициент трансформации трансформатора напряжения")]
        public double KTN { get; set; }


        public ElectricityMeasurementPoint? ElectricityMeasurementPoint { get; set; }
    }
}
