using DocManagementSystem.Data;
using DocManagementSystem.DTOModel.BookingManagement;
using DocManagementSystem.Entities;
using DocManagementSystem.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DocManagementSystem.Repositories
{
    public class BookingManagementRepository : IBookingManagementRepository
    {
        private readonly DMSDBContext _dbContext;

        public BookingManagementRepository(DMSDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateBooking(CreateBookingRequestDTO booking)
        {
            var entity = new BookingEntity
            {
                GeneratedReferenceNumber = booking.GeneratedReferenceNumber,
                DockId = booking.DockId,
                CompanyName = booking.CompanyName,
                LicensePlate = booking.LicensePlate,
                DirectionId = booking.DirectionId,
                StartTime = booking.StartTime,
                StatusId= booking.StatusId,
                EndTime = booking.EndTime,
                CreatedAt = DateTime.Now
            };
            _dbContext.Bookings.Add(entity);
           return await _dbContext.SaveChangesAsync();

        }
        public async Task<int> EditBooking(int id, EditBookingRequestDTO booking)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be greater than zero" + nameof(booking));
            }

            var Booking = await _dbContext.Bookings.FindAsync(id);

            if (Booking == null)
            {
                throw new Exception("Booking not found");
            }

            Booking.GeneratedReferenceNumber = booking.GeneratedReferenceNumber;
            Booking.DockId = booking.DockId;
            Booking.CompanyName = booking.CompanyName;
            Booking.LicensePlate = booking.LicensePlate;
            Booking.DirectionId = booking.DirectionId;
            Booking.StartTime = booking.StartTime;
            Booking.EndTime = booking.EndTime;
            Booking.StatusId = booking.StatusId;
            Booking.LastUpdatedAt = DateTime.Now;
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<GetBookingDTO> GetBooking(int id)
        {
            var Booking = await _dbContext.Bookings.FindAsync(id);

            if (Booking == null)
            {
                return null;
            }

            return new GetBookingDTO
            {
                BookingId = Booking.BookingId,
                GeneratedReferenceNumber = Booking.GeneratedReferenceNumber,
                DockId = Booking.DockId,
                CompanyName = Booking.CompanyName,
                LicensePlate = Booking.LicensePlate,
                DirectionId = Booking.DirectionId,
                StartTime = Booking.StartTime,
                StatusId = Booking.StatusId,
                EndTime = Booking.EndTime
            };
        }
        public async Task<List<GetBookingDTO>> GetBookings()
        {
            var bookings = await _dbContext.Bookings.ToListAsync();
            return bookings.Select(b => new GetBookingDTO
            {
                BookingId = b.BookingId,
                GeneratedReferenceNumber = b.GeneratedReferenceNumber,
                DockId = b.DockId,
                CompanyName = b.CompanyName,
                LicensePlate = b.LicensePlate,
                DirectionId = b.DirectionId,
                StartTime = b.StartTime,
                StatusId = b.StatusId,
                EndTime = b.EndTime
            }).ToList();
        }
        public async Task<int> DeleteBooking(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be greater than zero" + nameof(id));
            }

            var Booking = await _dbContext.Bookings.FindAsync(id);

            if (Booking == null)
            {
                throw new Exception("Booking not found");
            }

            _dbContext.Bookings.Remove(Booking);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
