

namespace StaffPortal.Application.Dtos
{
    public class EmployeeRequestDto
    {
        public string FullName { get; set; } = null!;

        public string Position { get; set; } = null!;

        public string Department { get; set; } = null!;

        public DateOnly HireDate { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public decimal? Salary { get; set; }

       
    }

}

