using Microsoft.Extensions.Options;
using StaffPortal.Application.Configuration;
using StaffPortal.Application.Dtos;
using StaffPortal.Application.Exceptions;
using StaffPortal.Application.Repositories.Employee;
using StaffPortal.Application.Service;
using StaffPortal.Domain.Entities;


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

        public async Task<bool> AddEmployeeAsync(EmployeeRequestDto employee)
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

        public async Task<EmployeeResponseDto> GetByIdEmployee(int id)
        {
            Employee employee = await  _employeeReadRepository.GetByIdAsync(id);
            if(employee == null)
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

    }
}
