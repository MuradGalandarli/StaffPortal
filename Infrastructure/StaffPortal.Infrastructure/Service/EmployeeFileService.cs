
using StaffPortal.Application.Dtos;
using StaffPortal.Application.Service;

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
            try {
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
                             $"CreatedAt: {DateTime.Now}"+
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

        
    }
}
