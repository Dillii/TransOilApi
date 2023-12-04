# TransOilApi
Work
Не забудте поменять путь к базе данных на свой.
Первым делом вызовите метод TestController - http://localhost:8050/api/TestData
после этого можно использовать остальные - 
http://localhost:8050/api/ConsumtionObject/CalculationMeters/5-5-2018/9-30-2018
http://localhost:8050/api/ConsumtionObject/AllOverdueElectricEnergyMeters/Какое-то название объекта потребления 1
http://localhost:8050/api/ElectricityMeasurmentPoint

Пример объекта:
{
    "PointName": "Test2",
    "EnergyMeter" :{
        "Number": "omg GOGO1",
        "Type" : 1,
        "CheckingDate" : "2018-05-05"
    },
    "CurrentTransformer" : {
        "Number": "we will rock you1",
        "Type" : 1,
        "CheckingDate" : "2018-05-05",
        "KTT": "0.235"
    },
    "VoltageTransformer" : {
        "Number": "we cant rock you1",
        "Type" : 1,
        "CheckingDate" : "2018-05-05",
        "KTN": "1.2335"
    }

}
