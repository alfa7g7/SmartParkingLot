using Microsoft.AspNetCore.Mvc;
using SmartParkingLot.Services;
using System;

namespace SmartParkingLot.Controllers
{
    [ApiController]
    [Route("api/parking-spots")]
    public class ParkingSpotsController : ControllerBase
    {
        private readonly IParkingLotService _service;

        public ParkingSpotsController(IParkingLotService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAllParkingSpots());

        [HttpPost("{id}/occupy/{deviceId}")]
        public IActionResult Occupy(Guid id, string deviceId)
        {
            try
            {
                _service.OccupyParkingSpot(id, deviceId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/free/{deviceId}")]
        public IActionResult Free(Guid id, string deviceId)
        {
            try
            {
                _service.FreeParkingSpot(id, deviceId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Add()
        {
            _service.AddParkingSpot();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            try
            {
                _service.RemoveParkingSpot(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
