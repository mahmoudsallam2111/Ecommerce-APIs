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



        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }
        public TEntity? GetByID(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
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

        public void Update(TEntity entity)
        {
        }
    }
}
