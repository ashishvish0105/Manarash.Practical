using System.ComponentModel.DataAnnotations;

namespace DocManagementSystem.DTOModel.BookingManagement
{
    public record CreateBookingRequestDTO
    {
        public required string GeneratedReferenceNumber { get; set; }
        public int DockId { get; set; }
        public required string CompanyName { get; set; }
        public required string LicensePlate { get; set; }
        public int DirectionId { get; set; }
        public int StatusId { get; set; } = 0;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; } = DateTime.Now;
    }
}
