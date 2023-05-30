using sportLife2.DbModel;
using sportLife2.DTOs;

namespace sportLife2.Repositories.Interface
{
   
        public interface IGenericRepository<TEntity> where TEntity : BaseEntity
        {
            List<TEntity> GetAll();
            TEntity GetById(int id);
            bool Create(TEntity entity);
            bool Update(TEntity entity);
            bool Delete(int id);    
         }
    
}
