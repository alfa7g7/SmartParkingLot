namespace SmartParkingLot.Services
{
    public interface IParkingLotService
    {
        IEnumerable<ParkingSpotDto> GetAllParkingSpots();
        void OccupyParkingSpot(Guid id, string deviceId);
        void FreeParkingSpot(Guid id, string deviceId);
        void AddParkingSpot();
        void RemoveParkingSpot(Guid id);
    }
}
