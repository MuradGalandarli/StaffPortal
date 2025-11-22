
using MediatR;
using StaffPortal.Application.Service;

namespace StaffPortal.Application.Features.Command.Employee.DeleteEmployeeById
{
    public class DeleteEmployeeByIdQueryHandler : IRequestHandler<DeleteEmployeeByIdQueryRequest, DeleteEmployeeByIdQueryResponse>
    {
        private readonly IEmployeeService _employeeService;

        public DeleteEmployeeByIdQueryHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<DeleteEmployeeByIdQueryResponse> Handle(DeleteEmployeeByIdQueryRequest request, CancellationToken cancellationToken)
        {
            bool status = await _employeeService.DeleteEmployeeByIdAsync(request.Id); 
            return new()
            {
                Status = status
            };

        }
    }
}
