using Microsoft.Extensions.DependencyInjection;
using StaffPortal.Application.Repositories.Employee;
using StaffPortal.Application.Service;
using StaffPortal.Persistence.Repositories.Employee;
using StaffPortal.Persistence.Service;

namespace StaffPortal.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddSingleton<AppDbContext>();
            services.AddScoped<IEmployeeWriteRepository, EmployeeWriteRepository>();
            services.AddScoped<IEmployeeReadRepository, EmployeeReadRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
           
        }
    }   
}
