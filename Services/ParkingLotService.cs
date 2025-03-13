namespace SmartParkingLot.Services
{
    public class ParkingLotService : IParkingLotService
    {
        private readonly IParkingSpotRepository _repository;
        private readonly List<IoTDevice> _registeredDevices;

        public ParkingLotService(IParkingSpotRepository repository)
        {
            _repository = repository;
            _registeredDevices = new List<IoTDevice>
            {
                new IoTDevice { DeviceId = "device-123" },
                new IoTDevice { DeviceId = "device-456" },
                new IoTDevice { DeviceId = "05be5a66-992c-439e-b5c9-5b0e2d29a887" } // Ensure this device is registered
            };
        }

        public IEnumerable<ParkingSpotDto> GetAllParkingSpots()
            => _repository.GetAll().Select(p => new ParkingSpotDto { Id = p.Id, IsOccupied = p.IsOccupied });

        public void OccupyParkingSpot(Guid id, string deviceId)
        {
            var spot = _repository.GetById(id) ?? throw new Exception("Parking spot not found.");
            if (spot.IsOccupied)
                throw new Exception("Parking spot is already occupied.");
            if (!_registeredDevices.Any(d => d.DeviceId == deviceId))
                throw new Exception("Unregistered IoT device.");

            spot.IsOccupied = true;
            spot.OccupiedByDeviceId = deviceId;
            _repository.Update(spot);
        }

        public void FreeParkingSpot(Guid id, string deviceId)
        {
            var spot = _repository.GetById(id) ?? throw new Exception("Parking spot not found.");
            if (!spot.IsOccupied)
                throw new Exception("Parking spot is already free.");
            if (spot.OccupiedByDeviceId != deviceId)
                throw new Exception("Unauthorized IoT device.");

            spot.IsOccupied = false;
            spot.OccupiedByDeviceId = null;
            _repository.Update(spot);
        }

        public void AddParkingSpot()
            => _repository.Add(new ParkingSpot { Id = Guid.NewGuid(), IsOccupied = false });

        public void RemoveParkingSpot(Guid id)
            => _repository.Remove(id);
    }
}
