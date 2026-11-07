using DocManagementSystem.Common.Enum;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace DocManagementSystem.Entities
{
    public class BookingEntity
    {
        [Key]
        public int BookingId { get; set; }
        [Required]
        [MaxLength(100)]
        public string GeneratedReferenceNumber { get; set; }
        [Required]
        public int DockId { get; set; }
        [Required]
        [MaxLength(150)]
        public string CompanyName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LicensePlate { get; set; }
        [Required]
        public int DirectionId { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; } = DateTime.Now;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastUpdatedAt { get; set; }= DateTime.Now;
    }
}
