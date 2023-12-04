using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using TransOilApi.DataBase;
using TransOilApi.DataBase.Models;

namespace TransOilApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestDataController : Controller
    {
        private readonly TransOilContext _context;

        public TestDataController(TransOilContext context)
        {
            _context = context;
        }

        /// <summary>
        /// бардак, но это нужно только чтобы тестовыми данными забить
        /// Сделано без привязки к Id
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult FillTestData()
        {
            var rand = new Random(345);
            var orgCount = rand.Next(1, 10);
            var count = 0;
            var counter = 0;
            var organisations = new List<Organisation>();
            var childOrganisations = new List<ChildOrganization>();
            for (var i = 0; i < orgCount; i++)
            {
                var organisation = new Organisation()
                {
                    Address = $"какой-то адрес {i}",
                    Name = $"Какая-то организация {i}"
                };
                organisations.Add(organisation);
            }
            _context.Organizations.AddRange(organisations);
            _context.SaveChanges();

            foreach (var organisation in _context.Organizations)
            {
                count = rand.Next(1, 5);
                for (var j = 0; j < count; j++)
                {
                    counter++;
                    childOrganisations.Add(new ChildOrganization()
                    {
                        Address = $"Какой-то дочерний адрес {counter}",
                        Name = $"Какая-то дочерняя организация {counter}",
                        OrganisationId = organisation.Id
                    });
                }
            }



            _context.ChildOrganizations.AddRange(childOrganisations);
            _context.SaveChanges();


            count = rand.Next(1, 5);

            counter = 0;
            var consObjects = new List<ConsumptionObject>();
            foreach (var childOrg in _context.ChildOrganizations)
            {
                for (var i = 0; i < count; i++)
                {
                    counter++;
                    consObjects.Add(new ConsumptionObject()
                    {
                        Address = $"Какой-то адрес объекта потребления {counter}",
                        ChildOrganizationId = childOrg.Id,
                        ObjectName = $"Какое-то название объекта потребления {counter}"
                    });
                }
            }
            _context.ConsumptionObjects.AddRange(consObjects);
            _context.SaveChanges();


            count = rand.Next(1, 10);

            var electricEnergyMeters = new List<ElectricEnergyMeter>();
            var voltageTransformers = new List<VoltageTransformer>();
            var currentTransformers = new List<CurrentTransformer>();
            var electricityMeasurementPoints = new List<ElectricityMeasurementPoint>();
            counter = 0;

            for (var i = 0; i < count * consObjects.Count(); i++)
            {
                counter++;
                var electricMeter = new ElectricEnergyMeter()
                {
                    CheckingDate = DateTime.Now,
                    Number = $"Какой-то номер счётчика {counter}",
                    Type = i
                };
                electricEnergyMeters.Add(electricMeter);
                var voltageTransformer = new VoltageTransformer()
                {
                    KTN = i / (double)count,
                    CheckingDate = DateTime.Now,
                    Number = $"Какой-то номер трансформатора напряжения {counter}",
                    Type = i
                };
                voltageTransformers.Add(voltageTransformer);
                var currentTransformer = new CurrentTransformer()
                {
                    KTT = i / (double)count,
                    CheckingDate = DateTime.Now,
                    Number = $"Какой-то номер трансформатора тока {counter}",
                    Type = i
                };
                currentTransformers.Add(currentTransformer);
            }

            _context.ElectricEnergyMeters.AddRange(electricEnergyMeters);
            _context.VoltageTransformers.AddRange(voltageTransformers);
            _context.CurrentTransformers.AddRange(currentTransformers);
            _context.SaveChanges();



            electricEnergyMeters = _context.ElectricEnergyMeters.ToList();
            voltageTransformers = _context.VoltageTransformers.ToList();
            currentTransformers = _context.CurrentTransformers.ToList();
            counter = 0;
            foreach (var consObject in consObjects)
            {
                for (int i = 0; i < count; i++)
                {
                    electricityMeasurementPoints.Add(new ElectricityMeasurementPoint()
                    {
                        Name = $"Какое-то название точки измерения электроэнергии {counter}",
                        ConsumptionObjectId = consObject.Id,
                        CurrentTransformerId = currentTransformers[counter].Id,
                        VoltageTransformerId = voltageTransformers[counter].Id,
                        ElectricEnergyMeterId = electricEnergyMeters[counter].Id
                    });
                    counter++;
                }
            }

            _context.ElectricityMeasurementPoints.AddRange(electricityMeasurementPoints);
            _context.SaveChanges();


            count = rand.Next(1, 10);
            var electricitySupplyPoints = new List<ElectricitySupplyPoint>();
            for (int i = 0; i < count; i++)
            {
                electricitySupplyPoints.Add(new ElectricitySupplyPoint()
                {
                    Name = $"Какое-то название точки поставки электроэнергии {i}",
                    MaxPower = 1000000 / (i + 1)
                });
            }

            _context.ElectricitySupplyPoints.AddRange(electricitySupplyPoints);
            _context.SaveChanges();

            count = rand.Next(1, 20);
            counter = 0;
            var calculationMeters = new List<CalculationMeter>();
            foreach (var supplyPoint in _context.ElectricitySupplyPoints)
            {
                for (int j = 0; j < electricityMeasurementPoints.Count; j++)
                {
                    var measurementPoint = electricityMeasurementPoints[j];
                    if (calculationMeters.Count < count)
                    {
                        calculationMeters.Add(new CalculationMeter()
                        {
                            StartDate = new DateTime(2018 + counter, 1 + j % 11, 1, 0, 0, 0, 10),
                            EndDate = new DateTime(2018 + counter, 2 + j % 11, 1, 0, 0, 0, 10),
                            ElectricityMeasurementPointId = measurementPoint.Id,
                            ElectricitySupplyPointId = supplyPoint.Id
                        });
                    }
                    else goto Exit;
                }
                counter++;
            }
        Exit:
            _context.CalculationMeters.AddRange(calculationMeters);
            _context.SaveChanges();
            return Ok();
        }
    }
}
