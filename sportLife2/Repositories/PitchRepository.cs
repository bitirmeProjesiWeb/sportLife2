using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sportLife2.DbModel;
using sportLife2.DTOs;
using sportLife2.Properties.Models;
using sportLife2.Repositories.Interface;


namespace sportLife2.Repositories
{
    public class PitchRepository : GenericRepository<Pitch>, IPitchRepository
    {
        private readonly IMapper _mapper;

        public PitchRepository(DataBaseContext context) : base(context)
        {

        }
        public Pitch GetAdminId(int AdminId)
        {
            var data = _context.Set<Pitch>().AsNoTracking().FirstOrDefault(x => x.AdminId == AdminId);
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
        public async Task<List<TypePitchDTO>> GetType(GetTypeRequest request)
        {
            var data = await (from Pitches in _context.Pitches
                              where Pitches.County == request.County && Pitches.Type == request.Type
                              select  new TypePitchDTO()).ToListAsync();

            return data; 
        }
    }
}
