using MediatR;

namespace StaffPortal.Application.Features.Command.Employee.DeleteEmployeeById
{
    public class DeleteEmployeeByIdQueryRequest:IRequest<DeleteEmployeeByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}