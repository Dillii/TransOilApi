using Microsoft.EntityFrameworkCore;
using TransOilApi.DataBase.Interfaces;
using TransOilApi.DataBase.Models;
using TransOilApi.Services.Interfaces;

namespace TransOilApi.Services.Classes
{
    /// <summary>
    /// Сервис работы с Объектом потребления
    /// </summary>
    public class ConsumptionObjectService : IConsumptionObjectService
    {
        private readonly IConsumptionObjectContext _context;
        public ConsumptionObjectService(IConsumptionObjectContext consumptionObjectContext) 
        {
            _context = consumptionObjectContext;
        }


        /// <summary>
        /// Получение всех расчётных приборов учёта за период времени 
        /// </summary>
        /// <param name="startDate">Начало периода</param>
        /// <param name="endDate">Конец периода</param>
        /// <returns></returns>
        public IEnumerable<CalculationMeter> GetCalculationMetersInPeriod(DateTime startDate, DateTime endDate)
        {
            if(startDate >= endDate) { throw new ArgumentException("дата чала не может быть больше или равна дате конца!!"); }
            //TODO - вопрос - пересечение интервалов считается или нужно чтобы был полность внутри? Беру за базу пересечение - т е должен попасть хотябы кусок интервала
            return _context.CalculationMeters.Where(a => a.StartDate < endDate && a.EndDate > startDate); 
        }



        /// <summary>
        /// Получение всех счетчиков электрической энергии с закончившимся сроком проверки у указанного объекта потребления
        /// </summary>
        /// <param name="consumptionObjectName">Объект потребления</param>
        /// <returns></returns>
        public IEnumerable<ElectricEnergyMeter> GetAllOverdueElectricEnergyMeters(string consumptionObjectName)
        {
            var consObject = GetConsumptionObject(consumptionObjectName);
            var electricEnergyMeters = consObject.ElectricityMeasurementPoints.Select(a => a.ElectricEnergyMeterId);
            return _context.ElectricEnergyMeters.Where(a => electricEnergyMeters.Contains(a.Id)).Where(b => b.CheckingDate <= DateTime.Now);
        }
        /// <summary>
        /// Получение всех трансформаторов тока с закончившимся сроком проверки у указанного объекта потребления
        /// </summary>
        /// <param name="consumptionObject">Объект потребления</param>
        /// <returns></returns>
        public IEnumerable<CurrentTransformer> GetAllOverdueCurrentTransformers(string consumptionObjectName)
        {
            var consObject = GetConsumptionObject(consumptionObjectName);
            var currentTransformers = consObject.ElectricityMeasurementPoints.Select(a => a.CurrentTransformerId);
            return _context.CurrentTransformers.Where(a => currentTransformers.Contains(a.Id)).Where(b => b.CheckingDate <= DateTime.Now); // тут не уверен в точности условия - день неделя месяц и тд.
        }
        /// <summary>
        /// Получение всех трансформаторов напряжения с закончившимся сроком проверки у указанного объекта потребления
        /// </summary>
        /// <param name="consumptionObject">Объект потребления</param>
        /// <returns></returns>
        public IEnumerable<VoltageTransformer> GetAllOverdueVoltageTransformers(string consumptionObjectName)
        {
            var consObject = GetConsumptionObject(consumptionObjectName);
            var voltageTransformers = consObject.ElectricityMeasurementPoints.Select(a => a.VoltageTransformerId);
            return _context.VoltageTransformers.Where(a => voltageTransformers.Contains(a.Id)).Where(b => b.CheckingDate <= DateTime.Now);
        }

        private ConsumptionObject GetConsumptionObject(string consumptionObjectName)
        {
            var consObject = _context.ConsumptionObjects.Include(b => b.ElectricityMeasurementPoints).FirstOrDefault(a => a.ObjectName == consumptionObjectName);
            if (consObject == null) { throw new Exception($"Объект потребления с наименованием = {consumptionObjectName}  Не найден!"); }
            return consObject;
        }

    }
}
