
using Microsoft.Extensions.DependencyInjection;
using StaffPortal.Application.Service;
using StaffPortal.Infrastructure.Service;

namespace StaffPortal.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static void AddInfrastructureService(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeFileService, EmployeeFileService>();
        }
    }
}
