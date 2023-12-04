using TransOilApi.DataBase.Interfaces;
using TransOilApi.Services.Interfaces;

namespace TransOilApi.Services.Classes
{
    /// <summary>
    /// Сервис организаций
    /// (Оставльные не задействованные в задании создавать лень)
    /// </summary>
    public class OrganisationsSerivce : IOrganisationsService
    {
        private IOrganizationsContext _context;
        public OrganisationsSerivce(IOrganizationsContext organizationsContext) 
        {
            _context = organizationsContext;
        }
    }
}
