using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace TransOilApi.DataBase.Models
{
    /// <summary>
    /// Дочерняя организация
    /// </summary>
    [Index(nameof(Name), nameof(Address), IsUnique = true)]
    public class ChildOrganization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        [Required(ErrorMessage = "Не задано имя дочерней организации")]
        public string Name { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        [Required(ErrorMessage = "Не задан адрес дочерней организации")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Не задан идентификатор родительской организации")]
        public long? OrganisationId { get; set; }

        [ForeignKey(nameof(OrganisationId))]

        public Organisation Organisation { get; set; }

        public List<ConsumptionObject> ConsumptionObjects { get; set; }
    }
}
