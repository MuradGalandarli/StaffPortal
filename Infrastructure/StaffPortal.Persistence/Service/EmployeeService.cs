using StaffPortal.Application.Repositories.Employee;
using StaffPortal.Application.Service;
using StaffPortal.Domain.Entities;

namespace StaffPortal.Persistence.Service
{
    
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeReadRepository _employeeReadRepository;

        public EmployeeService(IEmployeeReadRepository employeeReadRepository)
        {
            _employeeReadRepository = employeeReadRepository;
        }

        public async Task<(List<VwEmployeesForExport> Employees, int TotalCOunt)> GetAllEmployeesForExport()
        {
           List<VwEmployeesForExport> employees = await _employeeReadRepository.GetAllEmployeesForExport();
           int totalCount = employees.Count();
            return (employees, totalCount);

        }
    }
}
