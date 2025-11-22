

using StaffPortal.Application.Dtos;
using StaffPortal.Application.Service;
using StaffPortal.Domain.Entities;

namespace StaffPortal.Infrastructure.Service
{
    public class EmployeeFileService : IEmployeeFileService
    {
        public async Task<bool> WriteEmployeeToFile(EmployeeDto employee, string path, string fileName)
        {
            try { 
           
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string fullPath = Path.Combine(path, fileName);

            string content = $"FullName: {employee.FullName}\n" +
                             $"Position: {employee.Position}\n" +
                             $"Department: {employee.Department}\n" +
                             $"Email: {employee.Email}\n" +
                             $"Phone: {employee.Phone}\n" +
                             $"Salary: {employee.Salary}\n" +
                             $"CreatedAt: {DateTime.Now}"+
                             $"HireDate: {employee.HireDate}";

            await File.WriteAllTextAsync(fullPath, content);

                return true;
                }
             catch (Exception ex)
    {
                Console.WriteLine($"Fayla yazılmadı: {ex.Message}");
                return false;
            }
        }
}
}
