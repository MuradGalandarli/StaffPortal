using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace StaffPortal.Application
{
    public static class ApplicationServiceRegistration
    {
       public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ApplicationServiceRegistration));
           
        }
    }
}
