
using StaffPortal.Domain.Entities;

namespace StaffPortal.Application.Repositories.Employee
{
    public interface IEmployeeReadRepository:IReadRepository<Domain.Entities.Employee>
    {
       public Task<List<VwEmployeesForExport>> GetAllEmployeesForExport();
    }
}
