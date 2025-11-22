using MediatR;
using StaffPortal.Application.Dtos;
using StaffPortal.Application.Service;

namespace StaffPortal.Application.Features.Query.GetByIdEmployee
{
    public class GetByIdEmployeeQueryHandler : IRequestHandler<GetByIdEmployeeQueryRequest, GetByIdEmployeeQueryResponse>
    {
        private readonly IEmployeeService _employeeService;

        public GetByIdEmployeeQueryHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<GetByIdEmployeeQueryResponse> Handle(GetByIdEmployeeQueryRequest request, CancellationToken cancellationToken)
        {
            EmployeeResponseDto employeeResponseDto = await _employeeService.GetByIdEmployeeAsync(request.Id);
            return new()
            {
                employee = employeeResponseDto,
            };
        }
    }
}
