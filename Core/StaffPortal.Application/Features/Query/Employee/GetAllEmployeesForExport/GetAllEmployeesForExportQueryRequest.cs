using MediatR;

namespace StaffPortal.Application.Features.Query.Employee.GetAllEmployeesForExport
{
    public class GetAllEmployeesForExportQueryRequest : IRequest<GetAllEmployeesForExportQueryResponse>
    {
        public string Sort { get; set; }
    }
}