using MediatR;
using StaffPortal.Application.Dtos;

namespace StaffPortal.Application.Features.Command.UpdateEmployee
{
    public class UpdateEmployeeCommandRequest:IRequest<UpdateEmployeeCommandResponse>
    {
        public EmployeeRequestDto Employee { get; set; }
    }
}