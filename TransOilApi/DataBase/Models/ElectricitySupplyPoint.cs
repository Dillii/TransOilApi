using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TransOilApi.DataBase.Models
{
    /// <summary>
    /// Точка поставки электроэнергии
    /// </summary>
    [Index(nameof(Name), IsUnique = true)]
    public class ElectricitySupplyPoint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id {  get; set; }

        /// <summary>
        /// Наименование точки поставки
        /// </summary>
        [Required(ErrorMessage = "Не задано наименование точки поставки")]
        public string Name { get; set; }
        /// <summary>
        /// Максимальная мощность
        /// </summary>
        [Required(ErrorMessage = "Не задана максимальная мощность точки")]
        public int? MaxPower {  get; set; }



    }
}
