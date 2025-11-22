using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StaffPortal.Application.Configuration;
using StaffPortal.Application.Dtos;
using StaffPortal.Application.Exceptions;
using StaffPortal.Application.Repositories.Employee;
using StaffPortal.Application.Service;
using StaffPortal.Domain.Entities;
using System.Numerics;


namespace StaffPortal.Persistence.Service
{

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeReadRepository _employeeReadRepository;
        private readonly IEmployeeWriteRepository _employeeWriteRepository;
        private readonly IEmployeeFileService _employeeFileService;
        private readonly FileURL _fileURL;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(IEmployeeReadRepository employeeReadRepository, IEmployeeFileService employeeFileService, IOptions<FileURL> options, IEmployeeWriteRepository employeeWriteRepository, ILogger<EmployeeService> logger)
        {
            _employeeReadRepository = employeeReadRepository;
            _employeeFileService = employeeFileService;
            _fileURL = options.Value;
            _employeeWriteRepository = employeeWriteRepository;
            _logger = logger;
        }
        private string GenerateFilePath()
        {
            string fileName = $"Employee_{Guid.NewGuid()}.txt";
            return $"{_fileURL.EmployeeUploadPath}/{fileName}";
        }

        public async Task<bool> AddEmployeeAsync(EmployeeRequestDto employee)
        {
            //string fileName = $"Employee_{Guid.NewGuid()}.txt";
            //string filePath = $"{_fileURL.EmployeeUploadPath}/{fileName}";
            string filePath = GenerateFilePath();
            bool status = await _employeeFileService.WriteEmployeeToFile(employee, filePath);
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
            //_logger.LogWarning("Test");
            List<VwEmployeesForExport> employees = await _employeeReadRepository.GetAllEmployeesForExport();
            int totalCount = employees.Count();
            return (employees, totalCount);
        }

        public async Task<bool> DeleteEmployeeByIdAsync(int id)
        {
            Employee employee = await _employeeReadRepository.GetByIdAsync(id);
            if (employee != null)
            {
                bool isDeleted = _employeeFileService.FileDelete(employee.FilePath);
                if (!isDeleted)
                    throw new NotFoundException($"Employee with path {employee.FilePath} not found");
                bool status = _employeeWriteRepository.Delete(id);
                if (!status)
                    throw new NotFoundException($"Employee with id {id} not found");
                else await _employeeWriteRepository.SaveAsync();
                return status;
            }
            return false;

        }

        public async Task<EmployeeResponseDto> GetByIdEmployeeAsync(int id)
        {
            Employee employee = await _employeeReadRepository.GetByIdAsync(id);
            if (employee == null)
                throw new NotFoundException($"Employee with id {id} not found");
            return new()
            {
                Department = employee.Department,
                Email = employee.Email,
                EmployeeId = employee.EmployeeId,
                FullName = employee.FullName,
                HireDate = employee.HireDate,
                Phone = employee.Phone,
                Position = employee.Position,
                Salary = employee.Salary
            };
        }

        private async Task<byte[]> ReadFileAsBytesAsync(string path)
        {
            byte[] fileData = await File.ReadAllBytesAsync(path);
            return fileData;
        }

        public async Task<bool> UpdateEmployeeAsync(EmployeeRequestDto employee)
        {
            bool status = false;
            Employee data = await _employeeReadRepository.GetByIdAsync(employee.EmployeeId);
            if (data != null)
            {
                 status = _employeeFileService.FileDelete(data.FilePath);
                if (status)
                {
                    string filePath = GenerateFilePath();
                    await _employeeFileService.WriteEmployeeToFile(employee, filePath);
                    data.FilePath = filePath;
                    data.Department = employee.Department;
                    data.Email = employee.Email;
                    data.EmployeeId = employee.EmployeeId;
                    data.FullName = employee.FullName;
                    data.HireDate = employee.HireDate;
                    data.Phone = employee.Phone;
                    data.Position = employee.Position;
                    data.Salary = employee.Salary;
                    data.FileBlob = await ReadFileAsBytesAsync(filePath);
                    await _employeeWriteRepository.SaveAsync();
                    await _employeeFileService.WriteEmployeeToFile(employee, filePath);
                }
            }
            return status;
        }
    }
}
