using System;
using System.IO;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Парковка.Code.Data;
using Парковка.Code.Domain;

[TestFixture]
public class DatabaseTests
{
    public class ParkingTests
    {
        [Test]
        public static void TestParkingIsInstanceOfParkingClass()
        {
            Parking parking = new Parking();

            Assert.That(parking is Parking);
        }
    }

    [Test]
    [TestCase(null)]
    [TestCase("")]
    public void GetParkingData_НеверныйПутьКБазеДанных_ГенерируетИсключение(string dbPath)
    {
        // Упорядочить (Arrange)
        string[] args = { dbPath };

        // Действовать и Утверждать (Act and Assert)
        Assert.Throws<ArgumentNullException>(() => Database.GetParkingData(args));
    }

    [Test]
    [TestCase("10")]
    [TestCase("100")]
    public void ValidateDataBase_ВалидноеКоличествоМест_ВозвращаетОжидаемоеЗначение(string freeSpacesFromDB)
    {
        // Упорядочить (Arrange)
        // Дополнительные настройки не требуются

        // Действовать (Act)
        var result = Database.ValidateDataBase(freeSpacesFromDB);

        // Утверждать (Assert)
        Assert.Equals(int.Parse(freeSpacesFromDB), result);
    }

    [Test]
    [TestCase("invalid")]
    [TestCase("abc")]
    public void ValidateDataBase_НеверноеКоличествоМест_ГенерируетИсключение(string freeSpacesFromDB)
    {
        // Упорядочить (Arrange)
        // Дополнительные настройки не требуются

        // Действовать и Утверждать (Act and Assert)
        Assert.Throws<Exception>(() => Database.ValidateDataBase(freeSpacesFromDB));
    }
}