using API.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Usuarios.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly MyDBContext context;

        public Repository(MyDBContext context)
        {
            this.context = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return context.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

    }
}
