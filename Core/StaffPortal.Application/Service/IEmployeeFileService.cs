using StaffPortal.Application.Dtos;

namespace StaffPortal.Application.Service
{
    public interface IEmployeeFileService
    {
        public Task<bool> WriteEmployeeToFile(EmployeeRequestDto employee, string filePath);
        public bool FileDelete(string path);
    }
}
