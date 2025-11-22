using MediatR;
using StaffPortal.Application.Dtos;

namespace StaffPortal.Application.Features.Command.Employee.AddEmployee
{
    public class AddEmployeeCommandRequest:IRequest<AddEmployeeCommandResponse>
    {
        public EmployeeRequestDto employee { get; set; }
    }
}