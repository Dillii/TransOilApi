namespace TransOilApi.DTO
{

    public record CalculationMeterOutputDTO(long Id, DateTime StartDate, DateTime EndDate, long? ElectricityMeasurementPointId, long? ElectricitySupplyPointId)
    {
    }
}
