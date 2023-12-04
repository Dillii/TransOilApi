namespace TransOilApi.DTO
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Number">Номер</param>
    /// <param name="Type">Тип счётчика</param>
    /// <param name="CheckingDate">Дата проверки</param>
    /// <param name="KTN">Коэффициент трансформации</param>
    public record VoltageTransformerDTO(long Id, string Number, int Type, DateTime CheckingDate, double KTN)
    {
    }
}
