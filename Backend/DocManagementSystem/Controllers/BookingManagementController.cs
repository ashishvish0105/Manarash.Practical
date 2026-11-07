using DocManagementSystem.Comman;
using DocManagementSystem.DTOModel.BookingManagement;
using DocManagementSystem.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DocManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingManagementController : ControllerBase
    {
        private readonly IBookingManagementRepository _bookingManagementRepository;

        public BookingManagementController(IBookingManagementRepository bookingManagementRepository)
        {
            _bookingManagementRepository = bookingManagementRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReturnResponse>>> GetBookings()
        {
            var result = await _bookingManagementRepository.GetBookings();
            return Ok(new ReturnResponse(StatusCodes.Status200OK, "Get successfully bookings.", result));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnResponse>> GetBooking(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid booking ID");
            }
            var booking = await _bookingManagementRepository.GetBooking(id);

            if (booking == null)
            {
                return NotFound($"Booking with ID {id} not found.");
            }
            return Ok(new ReturnResponse(StatusCodes.Status200OK, "Get booking successfully.", booking));
        }

        [HttpPost]
        public async Task<ActionResult<ReturnResponse>> CreateBooking([FromBody] CreateBookingRequestDTO request)
        {
            if (request == null)
            {
                return BadRequest("Invalid booking request payload.");
            }

            var result = await _bookingManagementRepository.CreateBooking(request);
            return Ok(new ReturnResponse(StatusCodes.Status201Created, "Booking created successfully.", result));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReturnResponse>> EditBooking(int id, [FromBody] EditBookingRequestDTO request)
        {
            if (request == null)
            {
                return BadRequest("Invalid edit request payload.");
            }

            var result = await _bookingManagementRepository.EditBooking(id, request);
            if (result == 0)
            {
                return NotFound($"Booking with ID {id}");
            }

            return Ok(new ReturnResponse(StatusCodes.Status200OK, "Booking updated successfully.", result));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ReturnResponse>> DeleteBooking(int id)
        {
            var result = await _bookingManagementRepository.DeleteBooking(id);
            if (result == 0)
            {
                return NotFound($"Booking ID {id} not found.");
            }

            return Ok(new ReturnResponse(StatusCodes.Status200OK, "Booking deleted successfully.", result));
        }
    }
}
