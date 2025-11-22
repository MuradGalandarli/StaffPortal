using StaffPortal.Persistence;
using StaffPortal.Infrastructure;
using StaffPortal.Application;
using System.Runtime;
using StaffPortal.Application.Configuration;
using StraffPortal.UI.Middlewares;
using Serilog;

namespace StraffPortal.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddPersistenceService();
            builder.Services.AddInfrastructureService();
            builder.Services.AddApplicationService();
            builder.Services.Configure<FileURL>(builder.Configuration.GetSection("FileURL"));
            var app = builder.Build();
            Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

            builder.Host.UseSerilog();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
