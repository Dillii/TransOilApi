using Microsoft.AspNetCore.Mvc;
using TransOilApi.DTO;
using TransOilApi.Services.Interfaces;

namespace TransOilApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectricityMeasurmentPointController : Controller
    {
        private readonly IElectricityMeasurmentPointService _electricityMeasurmentPointService;

        public ElectricityMeasurmentPointController(IElectricityMeasurmentPointService electricityMeasurmentPointService)
        {
            _electricityMeasurmentPointService = electricityMeasurmentPointService;
        }


        /// <summary>
        /// Создаёт новую точку измерения 
        /// </summary>
        /// <param name="pointDTO">Данные для создания</param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult CreatePoint([FromBody] ElectricityMeasurmentPointInputDTO pointDTO)
        {
            var result = _electricityMeasurmentPointService.CreateElectricityMeasurmentPoint(pointDTO).ToOutputDTO();
            return Ok(result);
        }
    }
}
