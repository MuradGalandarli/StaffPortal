

using Microsoft.EntityFrameworkCore;
using StaffPortal.Domain.Entities;


namespace StaffPortal.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        public DbSet<T> Table { get; }
    }
}
