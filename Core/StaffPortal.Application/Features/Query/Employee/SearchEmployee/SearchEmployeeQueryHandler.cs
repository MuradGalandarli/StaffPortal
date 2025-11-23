

using MediatR;
using StaffPortal.Application.Dtos;
using StaffPortal.Application.Service;

namespace StaffPortal.Application.Features.Query.Employee.SearchEmployee
{
    public class SearchEmployeeQueryHandler : IRequestHandler<SearchEmployeeQueryRequest, SearchEmployeeQueryResponse>
    {
        private readonly IEmployeeService _employeeService;

        public SearchEmployeeQueryHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<SearchEmployeeQueryResponse> Handle(SearchEmployeeQueryRequest request, CancellationToken cancellationToken)
        {
           (List<EmployeeResponseDto>,int) employess = await _employeeService.SearchEmployeeAsync(request.Term,request.Sort);
            return new()
            {
                EmployeeResponseDto = employess.Item1,
                TotalCount = employess.Item2
            };
        }
    }
}
