using System.Data;
using TransOilApi.DataBase.Interfaces;
using TransOilApi.DataBase.Models;
using TransOilApi.DTO;
using TransOilApi.Services.Interfaces;

namespace TransOilApi.Services.Classes
{
    /// <summary>
    /// Сервис работы с точкой измерения электроэнергии
    /// </summary>
    public class ElectricityMeasurmentPointService : IElectricityMeasurmentPointService
    {
        private readonly IElectricityMeasurementPointContext _context;

        public ElectricityMeasurmentPointService(IElectricityMeasurementPointContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Добавляет новую точку измерения с указанием счётчика, трансформатора тока, трансформатора напряжения
        /// </summary>
        /// <param name="pointDTO">Data transfer object</param>
        public ElectricityMeasurementPoint CreateElectricityMeasurmentPoint(ElectricityMeasurmentPointInputDTO pointDTO)
        {
            if (_context.ElectricityMeasurementPoints.Any(a => a.Name == pointDTO.PointName)) throw new ArgumentException($"Точка измерения электроэнергии с Name = {pointDTO.PointName} уже существует!");


            var electricEnergyMeter = new ElectricEnergyMeter()
            {
                CheckingDate = pointDTO.EnergyMeter.CheckingDate,
                Number = pointDTO.EnergyMeter.Number,
                Type = pointDTO.EnergyMeter.Type
            };
            _context.ElectricEnergyMeters.Add(electricEnergyMeter);
            var currentTransformer = new CurrentTransformer()
            {
                CheckingDate = pointDTO.CurrentTransformer.CheckingDate,
                Number = pointDTO.CurrentTransformer.Number,
                Type = pointDTO.CurrentTransformer.Type,
                KTT = pointDTO.CurrentTransformer.KTT
            };
            _context.CurrentTransformers.Add(currentTransformer);
            var voltageTransformer = new VoltageTransformer()
            {
                CheckingDate = pointDTO.VoltageTransformer.CheckingDate,
                Number = pointDTO.VoltageTransformer.Number,
                Type = pointDTO.VoltageTransformer.Type,
                KTN = pointDTO.VoltageTransformer.KTN
            };
            _context.VoltageTransformers.Add(voltageTransformer);
            _context.SaveChanges();
            var newMeasurmentPoint = new ElectricityMeasurementPoint()
            {
                Name = pointDTO.PointName,
                ElectricEnergyMeter = electricEnergyMeter,
                CurrentTransformer = currentTransformer,
                VoltageTransformer = voltageTransformer
            };
            _context.ElectricityMeasurementPoints.Add(newMeasurmentPoint);
            _context.SaveChanges(); // если надо будет добавлять пачками, то это не годится
            return newMeasurmentPoint;
        }




        public ElectricEnergyMeter CreateElectricityEnergyMeter(string number, int type, DateTime checkingDate)
        {
            if (_context.ElectricEnergyMeters.Any(a => a.Number == number)) throw new ArgumentException($"Счётчик электроэнергии с Id = {number} уже существует!");
            var newItem = new ElectricEnergyMeter()
            {
                Number = number,
                Type = type,
                CheckingDate = checkingDate
            };
            _context.ElectricEnergyMeters.Add(newItem);
            _context.SaveChanges();
            return newItem;
        }

        public CurrentTransformer CreateCurrentTransformer(string number, int type, DateTime checkingDate, double ktt)
        {
            if (_context.CurrentTransformers.Any(a => a.Number == number)) throw new ArgumentException($"Трансформатор тока с Id = {number} уже существует!");
            var newItem = new CurrentTransformer()
            {
                Number = number,
                Type = type,
                CheckingDate = checkingDate,
                KTT = ktt
            };
            _context.CurrentTransformers.Add(newItem);
            _context.SaveChanges();
            return newItem;
        }

        public VoltageTransformer CreateVoltageTransformer(string number, int type, DateTime checkingDate, double ktn)
        {
            if (_context.VoltageTransformers.Any(a => a.Number == number)) throw new ArgumentException($"Трансформатор напряжения с Id = {number} уже существует!");
            var newItem = new VoltageTransformer()
            {
                Number = number,
                Type = type,
                CheckingDate = checkingDate,
                KTN = ktn
            };
            _context.VoltageTransformers.Add(newItem);
            _context.SaveChanges();
            return newItem;
        }
    }
}
