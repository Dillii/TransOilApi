using TransOilApi.DataBase.Models;

namespace TransOilApi.Services.Interfaces
{
    /// <summary>
    /// Сервис работы с Объектом потребления
    /// </summary>
    public interface IConsumptionObjectService
    {
        /// <summary>
        /// Получение всех расчётных приборов учёта за период времени 
        /// </summary>
        /// <param name="startDate">Начало периода</param>
        /// <param name="endDate">Конец периода</param>
        /// <returns></returns>
        public IEnumerable<CalculationMeter> GetCalculationMetersInPeriod(DateTime startDate, DateTime endDate);


        /// <summary>
        /// Получение всех счетчиков электрической энергии с закончившимся сроком проверки у указанного объекта потребления
        /// </summary>
        /// <param name="consumptionObjectName">Объект потребления</param>
        /// <returns></returns>
        public IEnumerable<ElectricEnergyMeter> GetAllOverdueElectricEnergyMeters(string consumptionObjectName);
        /// <summary>
        /// Получение всех трансформаторов тока с закончившимся сроком проверки у указанного объекта потребления
        /// </summary>
        /// <param name="consumptionObjectName">Объект потребления</param>
        /// <returns></returns>
        public IEnumerable<CurrentTransformer> GetAllOverdueCurrentTransformers(string consumptionObjectName);
        /// <summary>
        /// Получение всех трансформаторов напряжения с закончившимся сроком проверки у указанного объекта потребления
        /// </summary>
        /// <param name="consumptionObjectName">Объект потребления</param>
        /// <returns></returns>
        public IEnumerable<VoltageTransformer> GetAllOverdueVoltageTransformers(string consumptionObjectName);
    }
}
