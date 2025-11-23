using MediatR;

namespace StaffPortal.Application.Features.Query.Employee.GetByIdEmployee
{
    public class GetByIdEmployeeQueryRequest : IRequest<GetByIdEmployeeQueryResponse>
    {
        public int Id { get; set; }
    }
}