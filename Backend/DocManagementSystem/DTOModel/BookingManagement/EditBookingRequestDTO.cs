using System.ComponentModel.DataAnnotations;

namespace DocManagementSystem.DTOModel.BookingManagement
{
    public record EditBookingRequestDTO
    {
        public int BookingId { get; set; }
        [Required]
        public required string GeneratedReferenceNumber { get; set; }
        [Required]
        public int DockId { get; set; }
        [Required]
        [MaxLength(150)]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string LicensePlate { get; set; } = string.Empty;
        [Required]
        public int DirectionId { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; } = DateTime.Now;
    }
}
