public class ParkingSpot
{
    public Guid Id { get; set; }
    public bool IsOccupied { get; set; }
    public string? OccupiedByDeviceId { get; set; }
}