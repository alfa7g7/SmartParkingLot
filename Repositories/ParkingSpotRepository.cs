public class ParkingSpotRepository : IParkingSpotRepository
{
    private readonly List<ParkingSpot> _parkingSpots = new();

    public IEnumerable<ParkingSpot> GetAll() => _parkingSpots;

    public ParkingSpot? GetById(Guid id) => _parkingSpots.FirstOrDefault(p => p.Id == id);

    public void Add(ParkingSpot parkingSpot) => _parkingSpots.Add(parkingSpot);

    public void Update(ParkingSpot parkingSpot)
    {
        var index = _parkingSpots.FindIndex(p => p.Id == parkingSpot.Id);
        if (index != -1)
            _parkingSpots[index] = parkingSpot;
    }

    public void Remove(Guid id) => _parkingSpots.RemoveAll(p => p.Id == id);
}
