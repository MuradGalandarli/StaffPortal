using MediatR;

namespace StaffPortal.Application.Features.Query.Employee.SearchEmployee
{
    public class SearchEmployeeQueryRequest:IRequest<SearchEmployeeQueryResponse>
    {
        public string Term { get; set; }
        public string Sort { get; set; }

    }
}