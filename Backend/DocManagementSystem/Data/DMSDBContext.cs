using DocManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocManagementSystem.Data
{
    public class DMSDBContext : DbContext
    {
        public DMSDBContext(DbContextOptions<DMSDBContext> options):base(options)
        {
        }
        public DbSet<DockEntity> Docks { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }


    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seedTimestamp = new DateTime(2026, 11, 7);
            base.OnModelCreating(modelBuilder);

            var createdDate = new DateTime(2026, 11, 7);

            modelBuilder.Entity<DockEntity>().HasData(
                new DockEntity
                {
                    DockId = 1,
                    Name = "North Dock A",
                    TypeId = 1,
                    IsActive = true,
                    CreatedAt = createdDate,
                    LastUpdatedAt = createdDate
                },
                new DockEntity
                {
                    DockId = 2,
                    Name = "South Dock B",
                    TypeId = 1,
                    IsActive = true,
                    CreatedAt = createdDate,
                    LastUpdatedAt = createdDate
                }
            );

            modelBuilder.Entity<BookingEntity>().HasData(
            new BookingEntity
            {
                BookingId = 1,
                GeneratedReferenceNumber = "BKG-2026-001",
                DockId = 1,
                CompanyName = "DHL Express",
                LicensePlate = "GJ-01-AA-1234",
                DirectionId = 1,
                StatusId = 1,
                StartTime = seedTimestamp.AddHours(-6),
                EndTime = seedTimestamp.AddHours(-4),
                CreatedAt = seedTimestamp,
                LastUpdatedAt = seedTimestamp
            },
            new BookingEntity
            {
                BookingId = 2,
                GeneratedReferenceNumber = "BKG-2026-002",
                DockId = 1,
                CompanyName = "FedEx Ground",
                LicensePlate = "MH-02-BB-5678",
                DirectionId = 1,
                StatusId = 1,
                StartTime = seedTimestamp.AddHours(-4),
                EndTime = seedTimestamp.AddHours(-2),
                CreatedAt = seedTimestamp,
                LastUpdatedAt = seedTimestamp
            },
            new BookingEntity
            {
                BookingId = 3,
                GeneratedReferenceNumber = "BKG-2026-003",
                DockId = 1,
                CompanyName = "Amazon Logistics",
                LicensePlate = "DL-03-CC-9012",
                DirectionId = 2,
                StatusId = 2,
                StartTime = seedTimestamp.AddMinutes(-45),
                EndTime = seedTimestamp.AddHours(1),
                CreatedAt = seedTimestamp,
                LastUpdatedAt = seedTimestamp
            },
            new BookingEntity
            {
                BookingId = 4,
                GeneratedReferenceNumber = "BKG-2026-004",
                DockId = 3,
                CompanyName = "BlueDart Cargo",
                LicensePlate = "KA-04-DD-3456",
                DirectionId = 1,
                StatusId = 3,
                StartTime = seedTimestamp.AddMinutes(-15),
                EndTime = seedTimestamp.AddHours(2),
                CreatedAt = seedTimestamp,
                LastUpdatedAt = seedTimestamp
            },
            new BookingEntity
            {
                BookingId = 5,
                GeneratedReferenceNumber = "BKG-2026-005",
                DockId = 2,
                CompanyName = "Flipkart Fulfilment",
                LicensePlate = "HR-05-EE-7890",
                DirectionId = 2,
                StatusId = 4,
                StartTime = seedTimestamp.AddMinutes(10),
                EndTime = seedTimestamp.AddHours(3),
                CreatedAt = seedTimestamp,
                LastUpdatedAt = seedTimestamp
            },
            new BookingEntity
            {
                BookingId = 6,
                GeneratedReferenceNumber = "BKG-2026-006",
                DockId = 1,
                CompanyName = "Maersk Supply",
                LicensePlate = "UP-16-FF-4321",
                DirectionId = 1,
                StatusId = 3,
                StartTime = seedTimestamp.AddMinutes(30),
                EndTime = seedTimestamp.AddHours(2),
                CreatedAt = seedTimestamp,
                LastUpdatedAt = seedTimestamp
            },
            new BookingEntity
            {
                BookingId = 7,
                GeneratedReferenceNumber = "BKG-2026-007",
                DockId = 3,
                CompanyName = "Delhivery Ltd",
                LicensePlate = "TS-07-GG-8765",
                DirectionId = 1,
                StatusId = 3,
                StartTime = seedTimestamp.AddHours(3),
                EndTime = seedTimestamp.AddHours(5),
                CreatedAt = seedTimestamp,
                LastUpdatedAt = seedTimestamp
            },
            new BookingEntity
            {
                BookingId = 8,
                GeneratedReferenceNumber = "BKG-2026-008",
                DockId = 2,
                CompanyName = "Safexpress",
                LicensePlate = "WB-08-HH-2109",
                DirectionId = 2,
                StatusId = 3,
                StartTime = seedTimestamp.AddHours(5),
                EndTime = seedTimestamp.AddHours(7),
                CreatedAt = seedTimestamp,
                LastUpdatedAt = seedTimestamp
            },
            new BookingEntity
            {
                BookingId = 9,
                GeneratedReferenceNumber = "BKG-2026-009",
                DockId = 1,
                CompanyName = "Gati Cargo",
                LicensePlate = "TN-09-JJ-6543",
                DirectionId = 1,
                StatusId = 2,
                StartTime = seedTimestamp.AddDays(1),
                EndTime = seedTimestamp.AddDays(1).AddHours(2),
                CreatedAt = seedTimestamp,
                LastUpdatedAt = seedTimestamp
            },
            new BookingEntity
            {
                BookingId = 10,
                GeneratedReferenceNumber = "BKG-2026-010",
                DockId = 2,
                CompanyName = "VRL Logistics",
                LicensePlate = "KA-25-KK-0011",
                DirectionId = 2,
                StatusId = 1,
                StartTime = seedTimestamp.AddDays(1).AddHours(3),
                EndTime = seedTimestamp.AddDays(1).AddHours(5),
                CreatedAt = seedTimestamp,
                LastUpdatedAt = seedTimestamp
            }
        );
        }
    }
}

