using StaffPortal.Application.Dtos;

namespace StaffPortal.Application.Features.Query.Employee.SearchEmployee
{
    public class SearchEmployeeQueryResponse
    {
        public List<EmployeeResponseDto> EmployeeResponseDto { get; set; }
        public int TotalCount { get; set; }
    }
}