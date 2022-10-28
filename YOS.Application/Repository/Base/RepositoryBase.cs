using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using YOS.Domain.Context;

namespace YOS.Application.Repository.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AppDbContext context { get; set; }

        protected RepositoryBase(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<T> FindAll()
        {
           return context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression).AsNoTracking();
        }

        public async void Create(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            context.Update(entity);
        }

        public void Delete(T entity)
        {
            context.Remove(entity);
        }
    }
}
