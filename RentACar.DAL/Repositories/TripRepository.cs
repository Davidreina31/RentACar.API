using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentACar.DAL.Data;
using RentACar.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using RentACar.MODELS;

namespace RentACar.DAL.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly ApplicationDataContext _context;

        public TripRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<Trip> Add(Trip ItemToAdd)
        {
            _context.Trips.Add(ItemToAdd);
            await _context.SaveChangesAsync();

            return ItemToAdd;
        }

        public async Task<Trip> Delete(Guid id)
        {
            var result = await _context.Trips.FirstOrDefaultAsync(item => item.Trip_Id == id);
            _context.Trips.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<IEnumerable<Trip>> GetAll()
        {
            return await _context.Trips.ToListAsync();
        }

        public async Task<Trip> GetById(Guid id)
        {
            var result = await _context.Trips.FirstOrDefaultAsync(item => item.Trip_Id == id);

            return result;
        }

        public async Task<Trip> Update(Trip ItemToUpdate)
        {
            var result = await _context.Trips.FirstOrDefaultAsync(item => item.Trip_Id == ItemToUpdate.Trip_Id);
            _context.Trips.Update(ItemToUpdate);
            await _context.SaveChangesAsync();

            return ItemToUpdate;
        }
    }
}
