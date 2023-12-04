namespace TransOilApi.DTO
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Number">Номер</param>
    /// <param name="Type">Тип счётчика</param>
    /// <param name="CheckingDate">Дата проверки</param>
    public record ElectricEnergyMeterDTO(long Id, string Number, int Type, DateTime CheckingDate)
    {
    }
}
