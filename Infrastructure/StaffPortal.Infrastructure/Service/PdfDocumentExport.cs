using Microsoft.Extensions.Options;
using QuestPDF.Fluent;
using StaffPortal.Application.Configuration;
using StaffPortal.Application.Dtos;
using StaffPortal.Application.Exceptions;
using StaffPortal.Application.Service;


namespace StaffPortal.Infrastructure.Service
{
    public class PdfDocumentExport : IDocumentExport
    {
        private readonly IEmployeeFileService _employeeFileService;
        private readonly FileURL _fileURL;

        public PdfDocumentExport(IEmployeeFileService employeeFileService,IOptions<FileURL> options)
        {
            _employeeFileService = employeeFileService;
            _fileURL = options.Value;
        }

        public async Task<byte[]> GeneratePdfAsync(List<EmployeeRequestDto> employees)
        {
            string uploadFilePath = $"{_fileURL.EmployeeExportPath}/Employees_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}";
          
                bool status = await _employeeFileService.WriteEmployeeToFileList(employees, uploadFilePath);
            
          if (!status)
               return null;


            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(10);

                    // Header
                    page.Header()
                        .Text($"Employee list total count: {employees.Count()}")
                        .FontSize(10)
                        .Bold();


                    // Content
                    page.Content()
                        .Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(40); // ID
                                columns.RelativeColumn();   // FullName
                                columns.RelativeColumn();   // Position
                                columns.RelativeColumn();   // Department
                                columns.RelativeColumn();   // HireDate
                                columns.RelativeColumn();   // Email
                                columns.RelativeColumn();   // Phone
                                columns.RelativeColumn();   // Salary
                            });

                            // Header
                            table.Header(header =>
                            {
                                header.Cell().Text("ID").Bold();
                                header.Cell().Text("Full Name").Bold();
                                header.Cell().Text("Position").Bold();
                                header.Cell().Text("Department").Bold();
                                header.Cell().Text("Hire Date").Bold();
                                header.Cell().Text("Email").Bold();
                                header.Cell().Text("Phone").Bold();
                                header.Cell().Text("Salary").Bold();
                            });

                            // Rows
                            if (employees.Count == 0)
                            {
                                table.Cell().ColumnSpan(8)
                                     .AlignCenter()
                                     .Text("No employees found");
                            }
                            else
                            {
                                foreach (var emp in employees)
                                {
                                    table.Cell().Text(emp.EmployeeId);
                                    table.Cell().Text(emp.FullName);
                                    table.Cell().Text(emp.Position);
                                    table.Cell().Text(emp.Department);
                                    table.Cell().Text(emp.HireDate.ToString("yyyy-MM-dd"));
                                    table.Cell().Text(emp.Email ?? "-");
                                    table.Cell().Text(emp.Phone ?? "-");
                                    table.Cell().Text(emp.Salary?.ToString("F2") ?? "-");
                                }
                            }
                        });

                    // Footer
                    page.Footer()
                        .AlignCenter()
                        .Text($"Generated on: {DateTime.Now}");
                });
            });

            return document.GeneratePdf();
        }
    }
}


