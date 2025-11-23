
using StaffPortal.Application.Dtos;
using StaffPortal.Application.Service;
using StaffPortal.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StaffPortal.Infrastructure.Service
{
    public class EmployeeFileService : IEmployeeFileService
    {
        public bool FileDelete(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            else
                return false;
        }

        public async Task<bool> WriteEmployeeToFile(EmployeeRequestDto employee, string filePath)
        {
            try
            {
                string[] path = filePath.Split('/');

                if (!Directory.Exists(path[0]))
                    Directory.CreateDirectory(path[0]);

                //string fullPath = Path.Combine(path, fileName);

                string content = $"FullName: {employee.FullName}\n" +
                                 $"Position: {employee.Position}\n" +
                                 $"Department: {employee.Department}\n" +
                                 $"Email: {employee.Email}\n" +
                                 $"Phone: {employee.Phone}\n" +
                                 $"Salary: {employee.Salary}\n" +
                                 $"CreatedAt: {DateTime.Now}" +
                                 $"HireDate: {employee.HireDate}";

                await File.WriteAllTextAsync(filePath, content);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fayla yazılmadı: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> WriteEmployeeToFileList(List<EmployeeRequestDto> employees, string filePath)
        {
            try
            {
                string? directory = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                var lines = employees.Select(e =>
                    $"{e.EmployeeId} | {e.FullName} | {e.Position} | {e.Department} | {e.HireDate} | {e.Email} | {e.Phone} | {e.Salary}"
                ).ToList();

                await File.WriteAllLinesAsync(filePath, lines); // async yaz
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
