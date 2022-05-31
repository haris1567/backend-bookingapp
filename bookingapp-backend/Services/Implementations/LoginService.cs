using bookingapp_backend.Models;
using bookingapp_backend.Repository;
using bookingapp_backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookingapp_backend.Services.Implementations
{
    public class LoginService : ILoginService
    {

        public readonly DBContext dbContext;

        public LoginService(DBContext context)
        {
            dbContext = context;
        }

        public async Task<Instructor> CheckLogin(string Uid, string password)
        {
           string convertedPassword = ConvertPassword(password);
            var instructorInDb = await dbContext.Instructors.FirstOrDefaultAsync(i => i.Uid == Uid);
            return password == instructorInDb.Password ? instructorInDb : null;
        }

        public string ConvertPassword(string password)
        {
            throw new NotImplementedException();
        }
    }
}
