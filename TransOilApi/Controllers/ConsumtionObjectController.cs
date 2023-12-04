using Microsoft.AspNetCore.Mvc;
using TransOilApi.DTO;
using TransOilApi.Services.Interfaces;

namespace TransOilApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumtionObjectController : Controller
    {
        private readonly IConsumptionObjectService _consumptionObjectService;

        public ConsumtionObjectController(IConsumptionObjectService consumptionObjectService)
        {
            _consumptionObjectService = consumptionObjectService;
        }

        [HttpGet("CalculationMeters/{startDate}/{endDate}")]
        public IActionResult GetCalculationMetersInPeriod(DateTime startDate, DateTime endDate)
        {
            var result = _consumptionObjectService.GetCalculationMetersInPeriod(startDate, endDate).ToOutputDTOs();
            return Ok(result);
        }




        [HttpGet("AllOverdueElectricEnergyMeters/{consumptionObjectName}")]
        public IActionResult GetAllOverdueElectricEnergyMeters(string consumptionObjectName)
        {
            var result = _consumptionObjectService.GetAllOverdueElectricEnergyMeters(consumptionObjectName).ToOutputDTOs();
            return Ok(result);
        }
        [HttpGet("AllOverdueCurrentTransformers/{consumptionObjectName}")]
        public IActionResult GetAllOverdueCurrentTransformers(string consumptionObjectName)
        {
            var result = _consumptionObjectService.GetAllOverdueCurrentTransformers(consumptionObjectName).ToOutputDTOs();
            return Ok(result);
        }
        [HttpGet("AllOverdueVoltageTransformers/{consumptionObjectName}")]
        public IActionResult GetAllOverdueVoltageTransformers(string consumptionObjectName)
        {
            var result = _consumptionObjectService.GetAllOverdueVoltageTransformers(consumptionObjectName).ToOutputDTOs();
            return Ok(result);
        }
    }
}
