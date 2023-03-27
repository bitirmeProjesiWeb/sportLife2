using sportLife2.DbModel;
using sportLife2.Properties.Models;
using sportLife2.Repositories.Interface;
using System;

namespace sportLife2.Repositories
{
    public class SessionRepository : GenericRepository<Session>, ISessionRepository
    {
        public SessionRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
