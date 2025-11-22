

using StaffPortal.Application.Repositories;
using StaffPortal.Application.Repositories.Employee;

namespace StaffPortal.Persistence.Repositories.Employee
{
    public class EmployeeWriteRepository : WriteRepository<Domain.Entities.Employee> ,IEmployeeWriteRepository
    {
        public EmployeeWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
