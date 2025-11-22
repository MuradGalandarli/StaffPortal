using Microsoft.Extensions.Options;
using StaffPortal.Application.Configuration;
using StaffPortal.Application.Dtos;
using StaffPortal.Application.Repositories.Employee;
using StaffPortal.Application.Service;
using StaffPortal.Domain.Entities;
using StaffPortal.Persistence.Repositories.Employee;
using System.Numerics;

namespace StaffPortal.Persistence.Service
{
    
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeReadRepository _employeeReadRepository;
        private readonly IEmployeeWriteRepository _employeeWriteRepository;
        private readonly IEmployeeFileService _employeeFileService;
        private readonly FileURL _fileURL;

        public EmployeeService(IEmployeeReadRepository employeeReadRepository, IEmployeeFileService employeeFileService, IOptions<FileURL> options, IEmployeeWriteRepository employeeWriteRepository)
        {
            _employeeReadRepository = employeeReadRepository;
            _employeeFileService = employeeFileService;
            _fileURL = options.Value;
            _employeeWriteRepository = employeeWriteRepository;
        }

        public async Task<bool> AddEmployeeAsync(EmployeeDto employee)
        {
            string fileName = $"Employee_{Guid.NewGuid()}.txt";
            string filePath = $"{_fileURL.EmployeeUploadPath}/{fileName}";
            bool status = await _employeeFileService.WriteEmployeeToFile(employee, _fileURL.EmployeeUploadPath, fileName);
            if (status)
            {
              bool _status = await _employeeWriteRepository.AddAsync(new()
                {
                    CreatedAt = DateTime.UtcNow,
                    Department = employee.Department,
                    Email = employee.Email,
                    FilePath = filePath,
                    FullName = employee.FullName,
                    HireDate = employee.HireDate,
                    Phone = employee.Phone,
                    Position = employee.Position,
                    Salary = employee.Salary,
                    FileBlob = await ReadFileAsBytesAsync(filePath)
                });
                if (_status)
                {
                    await _employeeWriteRepository.SaveAsync();
                return _status;
                }
            }
            return false;   
        }

        public async Task<(List<VwEmployeesForExport> Employees, int TotalCOunt)> GetAllEmployeesForExport()
        {
           List<VwEmployeesForExport> employees = await _employeeReadRepository.GetAllEmployeesForExport();
           int totalCount = employees.Count();
            return (employees, totalCount);
        }
        private async Task<byte[]> ReadFileAsBytesAsync(string path)
        {
            byte[] fileData = await File.ReadAllBytesAsync(path);
            return fileData;
        }

    }
}
