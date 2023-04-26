using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly EcommerceDB context;

        public GenericRepository(EcommerceDB Context)
        {
            context = Context;
        }



        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }
        public async Task<TEntity?> GetByID(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task Add(TEntity entity)
        {
             await context.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
             context.Set<TEntity>().Remove(entity);
        }

      
        public void SaveChange()
        {
            //context.Set<TEntity>().SavedChanges();
            context.SaveChanges();
        }

        public  void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
        }
    }
}
