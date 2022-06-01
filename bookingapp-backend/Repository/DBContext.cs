using bookingapp_backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookingapp_backend.Repository
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                        .HasDiscriminator<Role>(u => u.Role)
                        .HasValue<User>(Role.Student)
                        .HasValue<Instructor>(Role.Instructor);

            modelBuilder.Entity<Lab>().HasData(
                new Lab
                {
                    Id = 1,
                    LabId = "ccna",
                    Name = "CCNA",
                    Details = "CCNA Lab Remote",
                    DateAdded = DateTime.Now,
                    DateUpdated = DateTime.Now
                },
                new Lab
                {
                    Id = 2,
                    LabId = "cisco",
                    Name = "CISCO",
                    Details = "CISCO Official Lab",
                    DateAdded = DateTime.Now,
                    DateUpdated = DateTime.Now
                });
            // Add custom properties for different tables
        }

       public DbSet<Booking> Bookings { get; set; }
       public DbSet<User> Users { get; set; }

       public DbSet<Instructor> Instructors { get; set; }
       public DbSet<Email> Emails { get; set; }

       public DbSet<Lab> Labs { get; set; }
    }
}
