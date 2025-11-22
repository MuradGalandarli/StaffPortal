

using MediatR;
using StaffPortal.Application.Service;

namespace StaffPortal.Application.Features.Command.Employee.AddEmployee
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommandRequest, AddEmployeeCommandResponse>
    {
        private readonly IEmployeeService _employeeService;

        public AddEmployeeCommandHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<AddEmployeeCommandResponse> Handle(AddEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
           bool status = await _employeeService.AddEmployeeAsync(request.employee);
            return new()
            {
             Status = status,
            };
        }
    }
}
