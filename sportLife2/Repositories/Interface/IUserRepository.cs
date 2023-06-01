using sportLife2.DbModel;
using sportLife2.DTOs;

namespace sportLife2.Repositories.Interface
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        bool UserControl(string email);
        Task<List<RolDTO>> GetTypeUser(GetUserRequest request);

    }
}
