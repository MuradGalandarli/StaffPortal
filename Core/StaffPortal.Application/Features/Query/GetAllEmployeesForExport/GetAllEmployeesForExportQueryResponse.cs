using StaffPortal.Application.Dtos;
using StaffPortal.Domain.Entities;

namespace StaffPortal.Application.Features.Query.GetAllEmployeesForExport
{
    public class GetAllEmployeesForExportQueryResponse
    {
        public List<VwEmployeesForExport> Employee { get; set; }
        public int TotalCount { get; set; }
    }
}