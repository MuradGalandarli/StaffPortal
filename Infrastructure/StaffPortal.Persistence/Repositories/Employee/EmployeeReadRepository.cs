using Microsoft.EntityFrameworkCore;
using StaffPortal.Application.Repositories.Employee;
using StaffPortal.Domain.Entities;

namespace StaffPortal.Persistence.Repositories.Employee
{
    public class EmployeeReadRepository : ReadRepository<Domain.Entities.Employee>, IEmployeeReadRepository
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeReadRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }

        public async Task<List<VwEmployeesForExport>> GetAllEmployeesForExport()
        {
           return await _appDbContext.VwEmployeesForExports.AsNoTracking().ToListAsync();
        }

        public async Task<List<Domain.Entities.Employee>> SearchEmployeeAsync(string term)
        {
               return await _appDbContext.Employees
                .FromSqlInterpolated($"EXEC sp_SearchEmployees @term={term}")
                .ToListAsync();
        }
    }
}
