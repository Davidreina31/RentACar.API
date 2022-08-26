using System;
using System.Threading.Tasks;
using RentACar.MODELS;

namespace RentACar.DAL.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserBySub(string sub);
    }
}
