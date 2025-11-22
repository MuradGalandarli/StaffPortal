

using StaffPortal.Domain.Entities;

namespace StaffPortal.Application.Repositories
{
    public interface IWriteRepository<T>:IRepository<T>where T : BaseEntity
    {
        public Task<bool> AddAsync(T model);
        public Task<bool> AddRange(List<T> datas);
        public bool Update(T t);
        public bool Delete(int id);
        public bool DeleteRange(List<T> id);
        Task<int> SaveAsync();
    }
}
