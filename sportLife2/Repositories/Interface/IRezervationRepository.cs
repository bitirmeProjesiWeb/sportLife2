using sportLife2.DbModel;
using sportLife2.DTOs;
using System;

namespace sportLife2.Repositories.Interface
{
    public interface IRezervationRepository : IGenericRepository<Rezervation>
    {
        Rezervation GetUserId(int UserId);
        Task<List<GetDateRezervationDTO>> GetDateRezervation(DateRezervationDTO request);
        Rezervation GetRezervationsByUserId(int userId);
        Rezervation GetRezervationsByPitchId(int pitchId);

    }
}
