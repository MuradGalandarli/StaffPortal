using MediatR;
using Microsoft.AspNetCore.Mvc;
using StaffPortal.Application.Features.Command.Employee.AddEmployee;
using StaffPortal.Application.Features.Command.Employee.DeleteEmployeeById;
using StaffPortal.Application.Features.Command.UpdateEmployee;
using StaffPortal.Application.Features.Query.Employee.ExportEmployeesPdf;
using StaffPortal.Application.Features.Query.Employee.GetAllEmployeesForExport;
using StaffPortal.Application.Features.Query.Employee.GetByIdEmployee;
using StaffPortal.Application.Features.Query.Employee.SearchEmployee;

namespace StraffPortal.UI.Controllers
{
    public class EmployeeController : Controller
    {
       
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {   
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee(string sort = "asc")
        {
            var request = new GetAllEmployeesForExportQueryRequest { Sort = sort };
            var response = await _mediator.Send(request);
            return Json(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdEmployee(int id)
        {
            var request = new GetByIdEmployeeQueryRequest { Id = id };
            var response = await _mediator.Send(request);
            return Json(response);
        }
            
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Json(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Json(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var request = new DeleteEmployeeByIdQueryRequest { Id = id };
            var response = await _mediator.Send(request);
            return Json(response);
        }

        [HttpGet]
        public async Task<IActionResult> SearchEmployee(string term, string sort = "asc")
        {
            var request = new SearchEmployeeQueryRequest { Term = term, Sort = sort };
            var response = await _mediator.Send(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<IActionResult> ExportPdf([FromBody] ExportEmployeesPdfQueryRequest request)
        {
            var pdfBytes = await _mediator.Send(request);
            var fileName = $"Employees_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            return File(pdfBytes, "application/pdf", fileName); 
        }
    
    }
}
