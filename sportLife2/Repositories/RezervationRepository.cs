using Microsoft.EntityFrameworkCore;
using sportLife2.DbModel;
using sportLife2.DTOs;
using sportLife2.Properties.Models;
using sportLife2.Repositories.Interface;

namespace sportLife2.Repositories
{
    public class RezervationRepository : GenericRepository<Rezervation>, IRezervationRepository
    {
        public RezervationRepository(DataBaseContext context) : base(context)
        {
           
        }

        public async Task<List<GetDateRezervationDTO>> GetDateRezervation(DateRezervationDTO request)
        {
            var data = await (from Rezervation in _context.Rezervations
                              where Rezervation.Date == request.Date && Rezervation.PitchId == request.PitchId
                              select new GetDateRezervationDTO()
                              {
                                  SessionId= Rezervation.SessionId,
                              }

                              ).ToListAsync();

            return data;
        }

        public Rezervation GetRezervationsByUserId(int userId)
        {
            var data = _context.Set<Rezervation>().AsNoTracking().FirstOrDefault(x => x.UserId == userId);
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

        public Rezervation GetRezervationsByPitchId(int pitchId)
        {
            var data = _context.Set<Rezervation>().AsNoTracking().FirstOrDefault(x => x.PitchId == pitchId);
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
