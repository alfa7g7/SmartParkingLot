using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartParkingLot.Services; 
[TestClass]
public class ParkingLotServiceTests
{
    private IParkingLotService? _service;
    private IParkingSpotRepository? _repository;

    [TestInitialize]
    public void Setup()
    {
        _repository = new ParkingSpotRepository();
        _service = new ParkingLotService(_repository);
    }

    [TestMethod]
    public void AddParkingSpot_ShouldIncreaseCount()
    {
        // Arrange
        var initialCount = _service?.GetAllParkingSpots().Count() ?? 0;

        // Act
        _service?.AddParkingSpot();

        // Assert
        Assert.AreEqual(initialCount + 1, _service?.GetAllParkingSpots().Count());
    }

    [TestMethod]
    public void OccupyParkingSpot_ShouldMarkAsOccupied()
    {
        // Arrange
        _service?.AddParkingSpot();
        var spot = _service?.GetAllParkingSpots().First();

        // Act
        _service?.OccupyParkingSpot(spot?.Id ?? Guid.Empty, "05be5a66-992c-439e-b5c9-5b0e2d29a887");

        // Assert
        var updatedSpot = _service?.GetAllParkingSpots().First(s => s.Id == spot?.Id);
        Assert.IsNotNull(updatedSpot);
        Assert.IsTrue(updatedSpot?.IsOccupied ?? false);
    }

    // Agrega más pruebas para otros escenarios
}

internal class TestMethodAttribute : Attribute
{
}

internal class TestInitializeAttribute : Attribute
{
}

internal class TestClassAttribute : Attribute
{
}