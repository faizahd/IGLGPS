
using IGGWebAPI.Application.Interfaces;

using IGGWebAPI.Domain.Entities;
using IGGWebAPI.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;


namespace IGGWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GPSDeviceController : ControllerBase
    {
        private readonly IGPSDeviceRepository _gpsDeviceService;

        public GPSDeviceController(IGPSDeviceRepository gPSDeviceRepository)
        {

            _gpsDeviceService = gPSDeviceRepository;
        }

        [HttpGet("GetDevice")]
        public async Task<IActionResult> GetDeviceDetails(CancellationToken canceltoken)
        {
            var Result =await _gpsDeviceService.GetAllAsync(canceltoken);
            return Ok(Result);
        }
        // GET: api/GPSDevice/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var device = await _gpsDeviceService.GetByIdAsync(id, cancellationToken);

            if (device == null)
                return NotFound(new
                {
                    message = $"GPS device with ID {id} not found."
                });

            return Ok(device);
        }

        // POST: api/GPSDevice
        [HttpPost("Create")]
        public async Task<IActionResult> Create(
            [FromBody] GPSDevice request, CancellationToken cancellationToken)
        {
            var id = await _gpsDeviceService.CreateAsync(request, cancellationToken);

            return CreatedAtAction(
                nameof(GetById),
                new { id },
                new { id, message = "GPS device created successfully." });
        }

        // PUT: api/GPSDevice/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] GPSDevice request, CancellationToken cancellationToken)
        {
            var updated = await _gpsDeviceService.UpdateAsync( request, cancellationToken);

            if (!updated)
                return NotFound(new
                {
                    message = $"GPS device with ID {id} not found."
                });

            return NoContent();
        }

        // DELETE: api/GPSDevice/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var deleted = await _gpsDeviceService.DeleteAsync(id, cancellationToken);

            if (!deleted)
                return NotFound(new
                {
                    message = $"GPS device with ID {id} not found."
                });

            return NoContent();
        }
        //controller code of clean architecture pervious architecture
    }
}
