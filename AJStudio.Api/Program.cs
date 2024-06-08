
using AJStudio.Business.ContactUs;
using AJStudio.Business.EmailServices;
using AJStudio.Business.PlaneVariety;
using AJStudio.Business.Suggested;
using AJStudio.Data.Context;
using AJStudio.Data.Repository.ContactUs;
using AJStudio.Data.Repository.PlaneVariety;
using AJStudio.Data.Repository.Suggested;
using Microsoft.EntityFrameworkCore;

namespace AJStudio.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //*AutoMapper Registration
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //*DBContext Registration
            builder.Services.AddDbContext<AJStudioContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbcs")));


            //*Manager Registration
            builder.Services.AddScoped<IContactUsManager, ContactUsManager>();
            builder.Services.AddScoped<IPlaneVarietyManager, PlaneVarietyManager>();
            builder.Services.AddScoped<ISuggestedManager, SuggestedManager>();


            //*Repository Registration
            builder.Services.AddScoped<IContactUsRepository, ContactUsRepository>();
            builder.Services.AddScoped<IPlaneVarietyRepository, PlaneVarietyRepository>();
            builder.Services.AddScoped<ISuggestedRepository, SuggestedRepository>();

            //*Email Sending Service Registration
            //*I consider each request as new for that i have used transiant services
            builder.Services.AddTransient<IEmailSender,EmailSender>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            //*Handle APIException Globally
            app.UseExceptionHandler("/api/ApiGlobalException");

            app.Run();
        }
    }
}
