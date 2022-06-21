using bookingapp_backend.Models;
using bookingapp_backend.Repository.Interfaces;
using bookingapp_backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Constants;

namespace bookingapp_backend.Services.Implementations
{
    public class BookingService : IBookingService
    {

        IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;

        }
        public DateTime[] CreateBookingSlots()
        {
            throw new NotImplementedException();
        }

        public async Task<string?> IsValidBooking(Booking currentBooking)
        {

            if (currentBooking.StartTime > currentBooking.EndTime)
            {
                return "StartTime cannot be greater than EndTime";
            }

            if (currentBooking.StartTime < DateTime.UtcNow)
            {
                return "A booking in the past cannot be created!";
            }

            var bookingHours = currentBooking.EndTime.Hour - currentBooking.StartTime.Hour;

            if (bookingHours > BookingConstants.BookingLimit)
            {
                return $"A booking can only be created with a maximum of {BookingConstants.BookingLimit} hours.";
            }

            var allBookings = await _bookingRepository.Get(currentBooking.StartTime);

            var currentUserBookings = allBookings.Where(booking => booking.Uid == currentBooking.Uid);

            var totalHours = bookingHours;

            currentUserBookings.ToList().ForEach(booking => totalHours += ((int)(booking.EndTime - booking.StartTime).TotalHours));

            if (totalHours > BookingConstants.BookingLimit)
            {
                return $"You have exceeded the total number of allowed Booking Hours ({BookingConstants.BookingLimit} hours)";
            }

            var bookingLimitReached = currentUserBookings.ToList().Count >= BookingConstants.BookingLimit;

            if (bookingLimitReached)
            {
                return "Maximum Booking Limit Reached for Today!";
            }

            var isBookingOverlapping = allBookings.ToList().Any(booking => IsBookingOverlapped(currentBooking.StartTime, currentBooking.EndTime, booking.StartTime, booking.EndTime));

            if (isBookingOverlapping)
            {
                return $"Booking with Range {currentBooking.StartTime.ToLocalTime()} - {currentBooking.EndTime.ToLocalTime()} overlaps with existing Booking.";
            }
         
            return null;

        }

        private bool IsBookingOverlapped(DateTime StartTimeFirst, DateTime EndTimeFirst, DateTime StartTimeSecond, DateTime EndTimeSecond)
        {
            return (StartTimeFirst < EndTimeSecond) && (StartTimeSecond < EndTimeFirst);
        }
    }
}
