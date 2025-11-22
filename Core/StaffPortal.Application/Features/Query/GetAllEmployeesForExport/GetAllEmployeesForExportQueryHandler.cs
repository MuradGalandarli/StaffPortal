

using MediatR;
using StaffPortal.Application.Service;
using StaffPortal.Domain.Entities;

namespace StaffPortal.Application.Features.Query.GetAllEmployeesForExport
{
    public class GetAllEmployeesForExportQueryHandler : IRequestHandler<GetAllEmployeesForExportQueryRequest, GetAllEmployeesForExportQueryResponse>
    {
        private readonly IEmployeeService _employeeService;

        public GetAllEmployeesForExportQueryHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<GetAllEmployeesForExportQueryResponse> Handle(GetAllEmployeesForExportQueryRequest request, CancellationToken cancellationToken)
        {
           (List<VwEmployeesForExport>,int) employess = await _employeeService.GetAllEmployeesForExport();
            return new()
            {
                Employee = employess.Item1,
                TotalCount = employess.Item2
            };

        }
    }
}
