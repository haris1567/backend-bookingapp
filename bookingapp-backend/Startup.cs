using bookingapp_backend.Models;
using bookingapp_backend.Repository;
using bookingapp_backend.Repository.Implementations;
using bookingapp_backend.Repository.Interfaces;
using bookingapp_backend.Services.Implementations;
using bookingapp_backend.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookingapp_backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Registered Services
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IInstructorRepository, InstructorRepository>();
            services.AddScoped<ILabRepository, LabRepository>();

            services.AddScoped<ILoginService, LoginService>();

            services.Configure<MailSetting>(Configuration.GetSection("MailSettings"));
            services.AddScoped<IEmailService, EmailService>();
       


            services.AddDbContext<DBContext>(o=> o.UseMySQL(Configuration.GetConnectionString("Default")));
            services.AddControllers();


            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Swagger UI for BookingApp",
                    Description = "Testing Endpoints for BookingApp with Swagger UI",
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
