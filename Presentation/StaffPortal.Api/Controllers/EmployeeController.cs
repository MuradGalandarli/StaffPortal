using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StaffPortal.Application.Features.Command.Employee.AddEmployee;
using StaffPortal.Application.Features.Query.Employee.GetAllEmployeesForExport;
using StaffPortal.Application.Features.Query.GetByIdEmployee;

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
        [HttpPost("add-employee")]
        public async Task<IActionResult> AddEmployee(AddEmployeeCommandRequest addEmployeeCommandRequest)
        {
            AddEmployeeCommandResponse addEmployeeCommandResponse = await _mediator.Send(addEmployeeCommandRequest);
            return Ok(addEmployeeCommandResponse);
        }
        [HttpGet("get-by-id-employee")]
        public async Task<IActionResult> GetByIdEmployee([FromQuery] int Id)
        {
            GetByIdEmployeeQueryRequest getByIdEmployeeQueryRequest = new() { Id = Id };
            GetByIdEmployeeQueryResponse getByIdEmployeeQueryResponse = await _mediator.Send(getByIdEmployeeQueryRequest);
            return Ok(getByIdEmployeeQueryResponse);
        }

    }
}
