using Microsoft.AspNetCore.Mvc;
using sportLife2.DbModel;
using sportLife2.DTOs;

namespace sportLife2.Repositories.Interface
{
    public interface IPitchRepository : IGenericRepository<Pitch>
    {
        Pitch GetAdminId(int AdminId);
        Task<List<TypePitchDTO>> GetType(GetTypeRequest request);
    }

}
