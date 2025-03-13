public interface IParkingSpotRepository
{
    IEnumerable<ParkingSpot> GetAll();
    ParkingSpot? GetById(Guid id);
    void Add(ParkingSpot parkingSpot);
    void Update(ParkingSpot parkingSpot);
    void Remove(Guid id);
}