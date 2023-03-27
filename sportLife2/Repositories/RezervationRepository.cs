using Microsoft.EntityFrameworkCore;
using sportLife2.DbModel;
using sportLife2.Properties.Models;
using sportLife2.Repositories.Interface;

namespace sportLife2.Repositories
{
    public class RezervationRepository : GenericRepository<Rezervation>, IRezervationRepository
    {
        public RezervationRepository(DataBaseContext context) : base(context)
        {
           
        }

        public Rezervation GetUserId(int UserId)
        {
            var data = _context.Set<Rezervation>().AsNoTracking().FirstOrDefault(x => x.UserId == UserId);
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

      
    }
}
