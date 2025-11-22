using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StaffPortal.Application.Features.Query.GetAllEmployeesForExport;

namespace StaffPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("get-all-employee")]
        public async Task<IActionResult> GetAllEmployee()
        {
            GetAllEmployeesForExportQueryResponse getAllEmployeesForExportQueryResponse = await _mediator.Send(new GetAllEmployeesForExportQueryRequest());
            return Ok(getAllEmployeesForExportQueryResponse);
        }
    }
}
