using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentACar.DAL.Data;
using RentACar.DAL.Interfaces.Repositories;
using RentACar.MODELS;

namespace RentACar.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDataContext _context;

        public UserRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User ItemToAdd)
        {
            _context.Users.Add(ItemToAdd);
            await _context.SaveChangesAsync();

            return ItemToAdd;
        }

        public async Task<User> Delete(Guid id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(item => item.Id == id);
            _context.Users.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
           return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(item => item.Id == id);
            return result;
        }

        public async Task<User> GetUserBySub(string sub)
        {
            var result = await _context.Users.FirstOrDefaultAsync(item => item.Sub == sub);

            return result;
        }

        public async Task<User> Update(User ItemToUpdate)
        {
            var result = await _context.Users.FirstOrDefaultAsync(item => item.Id == ItemToUpdate.Id);
            _context.Users.Update(ItemToUpdate);
            await _context.SaveChangesAsync();

            return ItemToUpdate;
        }
    }
}
