

using StaffPortal.Application.Dtos;
using StaffPortal.Domain.Entities;

namespace StaffPortal.Application.Service
{
    public interface IEmployeeService
    {
        public Task<(List<VwEmployeesForExport> Employees,int TotalCOunt)> GetAllEmployeesForExport();
        public Task<bool> AddEmployeeAsync(EmployeeDto employee);
    }
}
