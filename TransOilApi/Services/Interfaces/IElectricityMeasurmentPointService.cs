using TransOilApi.DataBase.Models;
using TransOilApi.DTO;

namespace TransOilApi.Services.Interfaces
{
    /// <summary>
    /// Сервис работы с точкой измерения электроэнергии
    /// </summary>
    public interface IElectricityMeasurmentPointService
    {
        /// <summary>
        /// Добавляет новую точку измерения с указанием счётчика, трансформатора тока, трансформатора напряжения
        /// </summary>
        ElectricityMeasurementPoint CreateElectricityMeasurmentPoint(ElectricityMeasurmentPointInputDTO pointDTO);


        ElectricEnergyMeter CreateElectricityEnergyMeter(string number, int type, DateTime checkingDate);
        CurrentTransformer CreateCurrentTransformer(string number, int type, DateTime checkingDate, double ktt);
        VoltageTransformer CreateVoltageTransformer(string number, int type, DateTime checkingDate, double ktn);
    }
}
