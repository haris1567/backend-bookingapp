using bookingapp_backend.Models;
using bookingapp_backend.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookingapp_backend.Repository.Implementations
{
    public class BookingRepository : IBookingRepository
    {
        public readonly DBContext dbContext;

        public BookingRepository(DBContext context)
        {
            dbContext = context;
        }

        public async Task<Booking> Create(Booking booking)
        {
            booking.DateAdded = DateTime.Now;
            booking.DateUpdated = booking.DateAdded;

            dbContext.Bookings.Add(booking);
            await dbContext.SaveChangesAsync();
            return booking;
        }

        public async Task Delete(int id)
        {
            var bookingToDelete = await dbContext.Bookings.FindAsync(id);
            dbContext.Bookings.Remove(bookingToDelete);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Booking>> Get()
        {
            return await dbContext.Bookings.ToListAsync();
        }

        public async Task<Booking> Get(int id)
        {
            return await dbContext.Bookings.FindAsync(id);
        }

        public async Task<IEnumerable<Booking>> Get(DateTime date)
        {
            return await dbContext.Bookings.Where(booking => booking.StartTime >= date.AddHours(-24) && booking.StartTime <= date).ToListAsync();
        }
        public async Task Update(Booking booking)
        {
            booking.DateUpdated = DateTime.Now;
            dbContext.Entry(booking).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
