using DocManagementSystem.DTOModel.BookingManagement;

namespace DocManagementSystem.IRepositories
{
    public interface IBookingManagementRepository
    {
        public Task<int> DeleteBooking(int id);
        public Task<GetBookingDTO> GetBooking(int id);
        public Task<List<GetBookingDTO>> GetBookings();
        public Task<int> EditBooking(int id, EditBookingRequestDTO booking);
        public Task<int> CreateBooking(CreateBookingRequestDTO booking);
    }
}
