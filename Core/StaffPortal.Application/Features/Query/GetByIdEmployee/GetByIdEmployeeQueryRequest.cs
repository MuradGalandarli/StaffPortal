using MediatR;

namespace StaffPortal.Application.Features.Query.GetByIdEmployee
{
    public class GetByIdEmployeeQueryRequest:IRequest<GetByIdEmployeeQueryResponse>
    {
        public int Id { get; set; }
    }
}