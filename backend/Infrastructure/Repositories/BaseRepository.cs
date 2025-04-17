using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Application.DTOs;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        protected DbSet<T> DbSet => _dbContext.Set<T>();

        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }
       
        public async Task<PaginationDTO<T>> GetPaginatedData(int pageNumber, int pageSize)
        {
            var query = _dbContext.Set<T>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking();

            var data = await query.ToListAsync();
            var totalCount = await _dbContext.Set<T>().CountAsync();

            return new PaginationDTO<T>(data, totalCount);
        }

        public async Task<T> GetById<Tid>(Tid id)
        {
            var data = await _dbContext.Set<T>().FindAsync(id);
            if (data == null)
                throw new Exception("No data found");
            return data;
        }


        public async Task<T> Create(T model)
        {
            await _dbContext.Set<T>().AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task Update(T model)
        {
            _dbContext.Set<T>().Update(model);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(T model)
        {
            _dbContext.Set<T>().Remove(model);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangeAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}