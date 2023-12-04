using Microsoft.EntityFrameworkCore;
using TransOilApi.DataBase.Models;

namespace TransOilApi.DataBase.Interfaces
{
    public interface IOrganizationsContext : IEditableContext
    {
        /// <summary>
        /// Дочерние организации
        /// </summary>
        public DbSet<ChildOrganization> ChildOrganizations { get; set; }
        /// <summary>
        /// Организации
        /// </summary>
        public DbSet<Organisation> Organizations { get; set; }
    }
}
