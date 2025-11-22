using StaffPortal.Persistence;
using StaffPortal.Infrastructure;
using StaffPortal.Application;
using StaffPortal.Application.Configuration;
using StaffPortal.Api.Middlewares;

namespace StaffPortal.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddPersistenceService();
            builder.Services.AddInfrastructureService();
            builder.Services.AddApplicationService();
            builder.Services.Configure<FileURL>(builder.Configuration.GetSection("FileURL"));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
