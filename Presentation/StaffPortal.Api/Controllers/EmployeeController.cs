using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StaffPortal.Application.Features.Command.Employee.AddEmployee;
using StaffPortal.Application.Features.Command.Employee.DeleteEmployeeById;
using StaffPortal.Application.Features.Command.UpdateEmployee;
using StaffPortal.Application.Features.Query.Employee.ExportEmployeesPdf;
using StaffPortal.Application.Features.Query.Employee.GetAllEmployeesForExport;
using StaffPortal.Application.Features.Query.Employee.GetByIdEmployee;
using StaffPortal.Application.Features.Query.Employee.SearchEmployee;

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
        public async Task<IActionResult> GetAllEmployee([FromQuery] string sort = "asc")
        {
            GetAllEmployeesForExportQueryRequest getAllEmployeesForExportQueryRequest = new() { Sort = sort };
            GetAllEmployeesForExportQueryResponse getAllEmployeesForExportQueryResponse = await _mediator.Send(getAllEmployeesForExportQueryRequest);
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
        [HttpDelete("get-delete-by-id")]
        public async Task<IActionResult> GetDeleteById([FromQuery] int id)
        {
            DeleteEmployeeByIdQueryRequest deleteByIdEmployeeQueryRequest = new() { Id = id };
            DeleteEmployeeByIdQueryResponse deleteEmployeeByIdQueryResponse = await _mediator.Send(deleteByIdEmployeeQueryRequest);
            return Ok(deleteEmployeeByIdQueryResponse);
        }
        [HttpPut("update-employee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommandRequest updateEmployeeCommandRequest)
        {
            UpdateEmployeeCommandResponse updateEmployeeCommandResponse = await _mediator.Send(updateEmployeeCommandRequest);
            return Ok(updateEmployeeCommandResponse);
        }
        [HttpGet("search-employee")]
        public async Task<IActionResult> SearchEmployee([FromQuery] string term, [FromQuery] string sort = "asc")
        {
            SearchEmployeeQueryRequest searchEmployeeQueryRequest = new() { Term = term, Sort = sort };
            SearchEmployeeQueryResponse searchEmployeeQueryResponse = await _mediator.Send(searchEmployeeQueryRequest);
            return Ok(searchEmployeeQueryResponse);
        }
        [HttpPost("export-pdf")]
        public async Task<IActionResult> ExportPdf([FromBody] ExportEmployeesPdfQueryRequest exportEmployeesPdfQueryRequest)
        {
            var exportEmployeesPdfQueryResponse = await _mediator.Send(exportEmployeesPdfQueryRequest);
            return File(exportEmployeesPdfQueryResponse, "application/pdf", $"Employees.pdf");
        }
    }
}
