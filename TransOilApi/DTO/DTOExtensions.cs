using TransOilApi.DataBase.Models;

namespace TransOilApi.DTO
{
    public static class DTOExtensions
    {
        public static ElectricityMeasurmentPointOutputDTO ToOutputDTO(this ElectricityMeasurementPoint point)
        {
            return new ElectricityMeasurmentPointOutputDTO(point.Id.Value, point.Name, point.ElectricEnergyMeterId.Value, point.CurrentTransformerId.Value, point.VoltageTransformerId.Value);
        }

        public static IEnumerable<CalculationMeterOutputDTO> ToOutputDTOs(this IEnumerable<CalculationMeter> calculationMeters)
        {
            foreach (CalculationMeter outputMeter in calculationMeters)
                yield return new CalculationMeterOutputDTO(outputMeter.Id.Value, outputMeter.StartDate.Value, outputMeter.EndDate.Value, outputMeter.ElectricityMeasurementPointId, outputMeter.ElectricitySupplyPointId);
        }



        public static IEnumerable<ElectricEnergyMeterDTO> ToOutputDTOs(this IEnumerable<ElectricEnergyMeter> electricEnergyMeters)
        {
            foreach (ElectricEnergyMeter electricEnergyMeter in electricEnergyMeters)
                yield return new ElectricEnergyMeterDTO(electricEnergyMeter.Id.Value, electricEnergyMeter.Number, electricEnergyMeter.Type, electricEnergyMeter.CheckingDate);
        }

        public static IEnumerable<CurrentTransformerDTO> ToOutputDTOs(this IEnumerable<CurrentTransformer> currentTransformers)
        {
            foreach (CurrentTransformer currentTransformer in currentTransformers)
                yield return new CurrentTransformerDTO(currentTransformer.Id.Value, currentTransformer.Number, currentTransformer.Type, currentTransformer.CheckingDate, currentTransformer.KTT);
        }

        public static IEnumerable<VoltageTransformerDTO> ToOutputDTOs(this IEnumerable<VoltageTransformer> voltageTransformers)
        {
            foreach (VoltageTransformer voltageTransformer in voltageTransformers)
                yield return new VoltageTransformerDTO(voltageTransformer.Id.Value, voltageTransformer.Number, voltageTransformer.Type, voltageTransformer.CheckingDate, voltageTransformer.KTN);
        }
    }
}
