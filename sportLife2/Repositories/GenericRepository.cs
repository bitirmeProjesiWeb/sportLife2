using sportLife2.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using sportLife2.DbModel;
using sportLife2.Properties.Models;

namespace sportLife2.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DataBaseContext _context;
        public GenericRepository(DataBaseContext context)

        {
            _context = context;
           

        }
        public virtual bool Create(TEntity entity)
        {
            try
            {
                entity.CreatedDate = DateTime.UtcNow;
                entity.UpdatedDate = DateTime.UtcNow;
                _context.Add<TEntity>(entity);
                entity.IsActive = true;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Başarılı değil", ex.Message);
                var error = ex.Message;
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                var entity = GetById(id);
                entity.IsActive = false;
                _context.Set<TEntity>().Update(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Silme Başarılı değil", ex.Message);
                return false;
            }

        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().Where(x => x.IsActive).ToList();


        }

        public TEntity GetById(int id)
        {
            var data = _context.Set<TEntity>().AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (data == null)
            {
                return null;
            }
            else if (data.IsActive == true)
            {
                return data;
            }
            else
            {
                return null;
            }


        }

        public bool Update(TEntity entity)
        {
            try
            {
                entity.UpdatedDate = DateTime.UtcNow;
                var data = _context.Set<TEntity>().AsNoTracking().FirstOrDefault(x => x.Id == entity.Id);
                _context.Set<TEntity>().Update(entity);
                entity.CreatedDate = data.CreatedDate;
                entity.IsActive = true;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Güncelleme Başarılı değil", ex.Message);
                return false;
            }
        }
    }
}
