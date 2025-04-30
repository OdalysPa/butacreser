using Microsoft.EntityFrameworkCore;
using CinemaBookingSystem.Models;

namespace CinemaBookingSystem.Repositories
{
    public class CinemaBookingDbContext : DbContext
    {
        public DbSet<BillboardEntity> Billboards { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<MovieEntity> Movies { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<SeatEntity> Seats { get; set; }

        public CinemaBookingDbContext(DbContextOptions<CinemaBookingDbContext> options) : base(options)
        {
        }
    }
}
