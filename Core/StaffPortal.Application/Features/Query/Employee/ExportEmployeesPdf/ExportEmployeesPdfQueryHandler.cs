

using MediatR;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using StaffPortal.Application.Service;
using StaffPortal.Domain.Entities;

namespace StaffPortal.Application.Features.Query.Employee.ExportEmployeesPdf
{
    public class ExportEmployeesPdfQueryHandler : IRequestHandler<ExportEmployeesPdfQueryRequest, byte[]>
    {
        private readonly IDocumentExport _documentExport;

        public ExportEmployeesPdfQueryHandler(IDocumentExport documentExport)
        {
            _documentExport = documentExport;
        }

        public async Task<byte[]> Handle(ExportEmployeesPdfQueryRequest request, CancellationToken cancellationToken)
        {
            var document = await _documentExport.GeneratePdfAsync(request.EmployeeRequestDtos);
            return document;
              
        }
    }
}
