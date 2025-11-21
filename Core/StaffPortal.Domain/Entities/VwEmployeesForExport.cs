using System;
using System.Collections.Generic;

namespace StaffPortal.Domain.Entities;

public partial class VwEmployeesForExport
{
    public int EmployeeId { get; set; }

    public string FullName { get; set; } = null!;

    public string Position { get; set; } = null!;

    public string Department { get; set; } = null!;

    public DateOnly HireDate { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public decimal? Salary { get; set; }
}
