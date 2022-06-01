using bookingapp_backend.DTOs;
using bookingapp_backend.Models;
using bookingapp_backend.Repository;
using bookingapp_backend.Repository.Interfaces;
using bookingapp_backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Constants;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bookingapp_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        private readonly ILogger<BookingController> _logger;
        private readonly IBookingRepository _bookingRepository;
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;

        public BookingController(ILogger<BookingController> logger , IBookingRepository bookingRepository,IEmailService emailService,IUserRepository userRepository)
        {
            _logger = logger;
            _bookingRepository = bookingRepository;
            _userRepository = userRepository;
            _emailService = emailService;

        }

        // GET: api/<BookingController>
        [HttpGet]
        public async Task<IEnumerable<Booking>> GetBookings()
        {
            return await _bookingRepository.Get();
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetSingleBooking(int id)
        {
            return await _bookingRepository.Get(id);
        }

        // POST api/<BookingController>
        [HttpPost]
        public async Task<ActionResult<Booking>> Post([FromBody] BookingEvent booking)
        {
            // Confirm provided user exists
            var user =  _userRepository.CheckUser(booking.uid, booking.email);

            if (user == null)
            {
                return BadRequest("The provided user information does not belong to any user");
            }
        
            var newBooking = await _bookingRepository.Create(
                new Booking { StartTime = booking.start, EndTime = booking.end, Title = booking.title, UserId = user.Id, LabId = booking.labId });

            var email = _emailService.CreateEmail(booking.email, BookingConstants.BookingCreated, newBooking);

            try
            {
                await _emailService.SendEmailAsync(email);

            }
            catch(Exception ex)
            {
                Console.WriteLine($"EXCEPTION {ex}");
            }
          

            return CreatedAtAction(nameof(GetSingleBooking), new { id = newBooking.Id }, newBooking);
        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> Put(int id, [FromBody] Booking booking)
        {
            if (id != booking.Id)
            {
                return BadRequest();
            }
            await _bookingRepository.Update(booking);

            return NoContent();
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            var bookingToDelete = await _bookingRepository.Get(id);

            if(bookingToDelete == null)
            {
                return NotFound();
            }

            await _bookingRepository.Delete(id);

            return NoContent();
        }
    }
}
