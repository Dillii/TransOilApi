using Microsoft.AspNetCore.Mvc;
using TransOilApi.Services.Interfaces;

namespace TransOilApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganisationController : Controller
    {
        private readonly IOrganisationsService _organisationsService;
        public OrganisationController(IOrganisationsService organisationsService) 
        {
            _organisationsService = organisationsService;
        }
        [HttpGet]
        public IActionResult GetOranisation()
        {
            //реализовывать не стал
            return Ok("Hello");
        }
    }
}
