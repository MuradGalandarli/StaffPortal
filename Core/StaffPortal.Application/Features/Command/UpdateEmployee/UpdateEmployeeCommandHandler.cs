

using MediatR;
using StaffPortal.Application.Service;

namespace StaffPortal.Application.Features.Command.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommandRequest, UpdateEmployeeCommandResponse>
    {
        private readonly IEmployeeService _employeeService;

        public UpdateEmployeeCommandHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<UpdateEmployeeCommandResponse> Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            bool status = await _employeeService.UpdateEmployeeAsync(request.Employee);
            return new()
            {
                Status = status
            };

        }
    }
}
