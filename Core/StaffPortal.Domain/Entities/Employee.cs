

namespace StaffPortal.Domain.Entities;

public partial class Employee:BaseEntity
{
    public string FullName { get; set; } = null!;

    public string Position { get; set; } = null!;

    public string Department { get; set; } = null!;

    public DateOnly HireDate { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public decimal? Salary { get; set; }

    public byte[]? FileBlob { get; set; }

    public string? FilePath { get; set; }

    public DateTime CreatedAt { get; set; }
}
