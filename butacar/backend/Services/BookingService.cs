using System;
using System.Linq;
using System.Transactions;
using CinemaBookingSystem.Models;
using CinemaBookingSystem.Repositories;

namespace CinemaBookingSystem.Services
{
    public class BookingService
    {
        private readonly CinemaBookingDbContext _context;

        public BookingService(CinemaBookingDbContext context)
        {
            _context = context;
        }

        public void DisableSeatAndCancelBooking(int seatId, int bookingId)
        {
            using (var transaction = new TransactionScope())
            {
                var booking = _context.Bookings.Find(bookingId);
                var seat = _context.Seats.Find(seatId);

                if (booking != null && seat != null)
                {
                    seat.Status = false;
                    booking.Status = false;
                    _context.SaveChanges();
                    transaction.Complete();
                }
                else
                {
                    throw new Exception("Booking or Seat not found");
                }
            }
        }

        public void CancelBillboardAndBookings(int billboardId)
        {
            using (var transaction = new TransactionScope())
            {
                var billboard = _context.Billboards.Find(billboardId);

                if (billboard == null || billboard.Date < DateTime.Now)
                {
                    throw new Exception("Cannot cancel past showings");
                }

                var bookings = _context.Bookings.Where(b => b.BillboardId == billboardId).ToList();
                foreach (var booking in bookings)
                {
                    booking.Status = false;
                    var seat = _context.Seats.Find(booking.SeatId);
                    if (seat != null) seat.Status = true;
                }

                _context.SaveChanges();
                transaction.Complete();
            }
        }
    }
}
