﻿using DomainLayer.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace InfrastructureLayer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task DeleteAsync(object id)
        {
            T entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                var deletedAtProperty = typeof(T).GetProperty("DeletedAt");
                if (deletedAtProperty != null && deletedAtProperty.PropertyType == typeof(DateTime?))
                {
                    deletedAtProperty.SetValue(entity, DateTime.UtcNow);
                    _context.Entry(entity).State = EntityState.Modified;
                }
                else
                {
                    _context.Remove(entity);
                }
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var query = _dbSet.AsQueryable();

            if (typeof(T).GetProperty("DeletedAt") != null)
            {
                query = query.Where(entity => EF.Property<DateTime?>(entity, "DeletedAt") == null);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            var query = _dbSet.AsQueryable();
            var property = typeof(T).GetProperty("DeletedAt");
            if (property != null)
            {
                query = query.Where(entity => EF.Property<DateTime?>(entity, "DeletedAt") == null);

            }
            return await query
                  .Where(entity => EF.Property<int>(entity, "Id") == (int)id)
                  .FirstOrDefaultAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}