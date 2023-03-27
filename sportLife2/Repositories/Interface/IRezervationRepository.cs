using sportLife2.DbModel;
using System;

namespace sportLife2.Repositories.Interface
{
    public interface IRezervationRepository : IGenericRepository<Rezervation>
    {
        Rezervation GetUserId(int UserId);

    }
}
