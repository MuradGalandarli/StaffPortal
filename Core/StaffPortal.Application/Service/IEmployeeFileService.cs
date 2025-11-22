
using StaffPortal.Application.Dtos;

namespace StaffPortal.Application.Service
{
    public interface IEmployeeFileService
    {
        public Task<bool> WriteEmployeeToFile(EmployeeDto employee, string path,string fileName);
    }
}
