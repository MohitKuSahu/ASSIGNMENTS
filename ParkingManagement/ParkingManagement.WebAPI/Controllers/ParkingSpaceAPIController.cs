using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingManagement.BL;
using ParkingManagement.Utils;
using ParkingManagement.Models;

namespace ParkingManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingSpaceAPIController : ControllerBase
    {
        private readonly IBL _BAL;
        private readonly ILog _Log;

        public ParkingSpaceAPIController(IBL BAL, ILog Log)
        {
            _BAL = BAL;
            _Log = Log;
        }

        [HttpGet]
        public async Task<ActionResult<List<ParkingSpaceModel>>> GetParkingSpace()
        {
            try
            {
                var data = await _BAL.ListParkingSpaceAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _Log.AddException(ex);
                return NotFound();
            }

        }


        [HttpGet("{ParkingZoneId}")]
        public async Task<ActionResult<List<ParkingSpaceModel>>> ListParkingSpaceById(int ParkingZoneId)
        {
            try
            {
                var data = await _BAL.ListParkingSpaceByIdAsync(ParkingZoneId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _Log.AddException(ex);
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<ParkingSpaceModel>> AddParkingSpace(ParkingSpaceModel model)
        {
            try
            {
                bool success = await _BAL.AddParkingSpaceAsync(model);
                if (success)
                {
                    return Ok(new { success = true });
                }
                else
                {
                    return Ok(new { success = false });
                }
            }
            catch (Exception ex)
            {
                _Log.AddException(ex);
                return BadRequest(ex);
            }
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<ParkingSpaceModel>> DeleteParkingSpace(int Id)
        {
            try
            {
                var data = await _BAL.DeleteParkingSpaceAsync(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _Log.AddException(ex);
                return BadRequest(ex);
            }
        }

    }
}
