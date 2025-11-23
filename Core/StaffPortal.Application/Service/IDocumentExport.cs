
using StaffPortal.Application.Dtos;

namespace StaffPortal.Application.Service
{
    public interface IDocumentExport
    {
        Task<byte[]> GeneratePdfAsync(List<EmployeeRequestDto> employees);
    }
}
