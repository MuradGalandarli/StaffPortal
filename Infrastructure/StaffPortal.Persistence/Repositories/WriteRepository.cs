using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using StaffPortal.Application.Repositories;
using StaffPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffPortal.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public WriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRange(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public bool Delete(int id)
        {
            var data = Table.FirstOrDefault(x => x.EmployeeId == id);
            if (data != null)
            {
                EntityEntry entityEntry = Table.Remove(data);
                return entityEntry.State == EntityState.Deleted;
            }
            return false;
        }

        public bool DeleteRange(List<T> id)
        {
            Table.RemoveRange(id);
            return true;
        }

        public async Task<int> SaveAsync()
        {
            int count = await _context.SaveChangesAsync();
            return count;
        }

        public bool Update(T t)
        {
            EntityEntry entityEntry = Table.Update(t);
            return entityEntry.State == EntityState.Modified;
        }
    
    }
}
