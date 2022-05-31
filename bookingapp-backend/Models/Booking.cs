using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bookingapp_backend.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }
        public int UserId { get; set; }

        public int LabId { get; set; }

        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
