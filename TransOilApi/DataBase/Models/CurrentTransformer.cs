using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TransOilApi.DataBase.Models
{
    /// <summary>
    /// трансформатор тока
    /// </summary>
    [Index(nameof(Number), IsUnique = true)]
    public class CurrentTransformer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }
        /// <summary>
        /// Номер
        /// </summary>
        [Required(ErrorMessage = "Не задан номер трансформатора тока")]
        public string Number { get; set; }
        /// <summary>
        /// Тип трансформатора тока
        /// </summary>
        [Required(ErrorMessage = "Не задан тип трансформатора тока")]
        public int Type { get; set; }
        /// <summary>
        /// Дата проверки
        /// </summary>
        [Column(TypeName = "timestamp without time zone")]
        [Required(ErrorMessage = "Не задано время проверки трансформатора тока")]
        public DateTime CheckingDate { get; set; }
        /// <summary>
        /// Коэффициент трансформации
        /// </summary>
        [Required(ErrorMessage = "Не задан коэффициент трансформации трансформатора тока")]
        public double KTT {  get; set; }



        public ElectricityMeasurementPoint? ElectricityMeasurementPoint { get; set; }
    }
}
