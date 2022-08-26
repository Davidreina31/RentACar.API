using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentACar.BLL.Interfaces.Managers;
using RentACar.DAL.Interfaces.Repositories;
using RentACar.MODELS;

namespace RentACar.BLL.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _repo;

        public UserManager(IUserRepository repository)
        {
            _repo = repository;
        }

        public async Task<User> Add(User ItemToAdd)
        {
            var allUsers = await GetAll();

            foreach (var item in allUsers)
            {
                if(item.Sub == ItemToAdd.Sub)
                {
                    throw new Exception("User already in db");
                }
            }
            return await _repo.Add(ItemToAdd);
        }

        public async Task<User> Delete(Guid id)
        {
            return await _repo.Delete(id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _repo.GetById(id);
        }

        public async Task<User> GetUserBySub(string sub)
        {
            return await _repo.GetUserBySub(sub);
        }

        public async Task<User> Update(User ItemToUpdate)
        {
            return await _repo.Update(ItemToUpdate);
        }
    }
}
