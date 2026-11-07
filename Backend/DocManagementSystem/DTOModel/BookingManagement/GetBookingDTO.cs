namespace DocManagementSystem.DTOModel.BookingManagement
{
    public record GetBookingDTO
    {
        public int BookingId { get; set; }
        public string GeneratedReferenceNumber { get; set; } = string.Empty;
        public int DockId { get; set; }
        public string CompanyName { get; set; }= string.Empty;
        public string LicensePlate { get; set; }=string.Empty;
        public int DirectionId { get; set; }
        public int StatusId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; } = DateTime.Now;
    }
}
