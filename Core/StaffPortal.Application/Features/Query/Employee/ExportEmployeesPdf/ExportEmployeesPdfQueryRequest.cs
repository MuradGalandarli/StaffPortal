using MediatR;
using StaffPortal.Application.Dtos;

namespace StaffPortal.Application.Features.Query.Employee.ExportEmployeesPdf
{
    public class ExportEmployeesPdfQueryRequest : IRequest<byte[]>
    {
        public List<EmployeeRequestDto> EmployeeRequestDtos { get; set; }
    }
}