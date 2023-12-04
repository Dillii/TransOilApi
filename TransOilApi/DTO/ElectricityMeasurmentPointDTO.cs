using Microsoft.AspNetCore.Mvc;

namespace TransOilApi.DTO
{




    /// <summary>
    /// 
    /// </summary>
    /// <param name="PointName">Наименование</param>
    /// <param name="EnergyMeter">счётчик электрической энергии</param>
    /// <param name="CurrentTransformer">трансформатор тока</param>
    /// <param name="VoltageTransformer">трансформатора напряжения</param>
    public record ElectricityMeasurmentPointInputDTO(string PointName, ElectricEnergyMeterDTO EnergyMeter, CurrentTransformerDTO CurrentTransformer, VoltageTransformerDTO VoltageTransformer);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id">Ключ</param>
    /// <param name="PointName">Наименование</param>
    /// <param name="EnergyMeterId">идентификатор счётчика электрической энергии</param>
    /// <param name="CurrentTransformerId">идентификатор трансформатора тока</param>
    /// <param name="VoltageTransformerId">идентификатор трансформатора напряжения</param>
    public record ElectricityMeasurmentPointOutputDTO(long Id, string PointName, long EnergyMeterId, long CurrentTransformerId, long VoltageTransformerId);
}
