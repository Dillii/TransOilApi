using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransOilApi.DataBase.Models
{
    /// <summary>
    /// организация
    /// </summary>
    [Index(nameof(Name), nameof(Address), IsUnique = true)]
    public class Organisation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        [Required(ErrorMessage = "Не задано имя организации")]
        public string Name { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        [Required(ErrorMessage = "Не задан адрес организации")]
        public string Address { get; set; }
        /// <summary>
        /// Список дочерних организаций
        /// </summary>
        public List<ChildOrganization> Children { get; set; }
    }
}
