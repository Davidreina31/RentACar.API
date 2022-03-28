using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentACar.DAL.Data;
using RentACar.DAL.Interfaces.Repositories;
using RentACar.MODELS;

namespace RentACar.DAL.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDataContext _context;

        public CountryRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<Country> Add(Country ItemToAdd)
        {
            _context.Countries.Add(ItemToAdd);
            await _context.SaveChangesAsync();

            return ItemToAdd;
        }

        public async Task<Country> Delete(Guid id)
        {
            var result = await _context.Countries.FirstOrDefaultAsync(item => item.Country_Id == id);
            _context.Countries.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> GetById(Guid id)
        {
            var result = await _context.Countries.FirstOrDefaultAsync(item => item.Country_Id == id);

            return result;
        }

        public async Task<Country> Update(Country ItemToUpdate)
        {
            var result = await _context.Countries.FirstOrDefaultAsync(item => item.Country_Id == ItemToUpdate.Country_Id);
            _context.Countries.Update(ItemToUpdate);
            await _context.SaveChangesAsync();

            return ItemToUpdate;
        }
    }
}
