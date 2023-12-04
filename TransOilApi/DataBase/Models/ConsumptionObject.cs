using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace TransOilApi.DataBase.Models
{
    /// <summary>
    /// Объект потребления
    /// </summary>
    [Index(nameof(ObjectName), nameof(Address), IsUnique = true)]
    public class ConsumptionObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }
        /// <summary>
        /// Наименование объекта
        /// </summary>
        [Required(ErrorMessage = "Не задано наименование объекта")]
        public string ObjectName { get; set; }
        /// <summary>
        /// Адрес объекта
        /// </summary>
        [Required(ErrorMessage = "Не задан адрес объекта")]
        public string Address {  get; set; }


        [Required(ErrorMessage = "Не задан идентификатор дочерней организации")]
        public long? ChildOrganizationId { get; set; }


        [ForeignKey(nameof(ChildOrganizationId))]
        public ChildOrganization ChildOrganization {  get; set; }

        public List<ElectricityMeasurementPoint> ElectricityMeasurementPoints { get; set; }

    }
}
