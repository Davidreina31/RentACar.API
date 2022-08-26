using System;
using System.Threading.Tasks;
using RentACar.MODELS;

namespace RentACar.BLL.Interfaces.Managers
{
    public interface IUserManager : IBaseManager<User>
    {
        Task<User> GetUserBySub(string sub);
    }
}
