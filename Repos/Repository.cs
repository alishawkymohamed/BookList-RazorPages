using Context.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repos
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BookListContext context;

        public Repository(BookListContext context)
        {
            this.context = context;
        }


        public Task<T> GetById(int id) => context.Set<T>().FindAsync(id).AsTask();

        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
            => context.Set<T>().FirstOrDefaultAsync(predicate);

        public async Task Add(T entity)
        {
            // await Context.AddAsync(entity);
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            // In case AsNoTracking is used
            context.Entry(entity).State = EntityState.Modified;
            return context.SaveChangesAsync();
        }

        public Task Remove(T entity)
        {
            context.Set<T>().Remove(entity);
            return context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().Where(predicate).ToListAsync();
        }

        public Task<int> CountAll() => context.Set<T>().CountAsync();

        public Task<int> CountWhere(Expression<Func<T, bool>> predicate)
            => context.Set<T>().CountAsync(predicate);
    }
}
