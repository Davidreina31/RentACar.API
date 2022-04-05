using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentACar.DAL.Data;
using RentACar.DAL.Interfaces.Repositories;
using RentACar.MODELS;

namespace RentACar.DAL.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDataContext _context;

        public CarRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<Car> Add(Car ItemToAdd)
        {
            _context.Cars.Add(ItemToAdd);
            await _context.SaveChangesAsync();

            return ItemToAdd;
        }

        public async Task<Car> Delete(Guid id)
        {
            var result = await _context.Cars.FirstOrDefaultAsync(item => item.Car_Id == id);
            _context.Cars.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> GetById(Guid id)
        {
            var result = await _context.Cars.FirstOrDefaultAsync(item => item.Car_Id == id);
            return result;
        }

        public async Task<Car> Update(Car ItemToUpdate)
        {
            var result = await _context.Cars.FirstOrDefaultAsync(item => item.Car_Id == ItemToUpdate.Car_Id);
            _context.Cars.Update(ItemToUpdate);
            await _context.SaveChangesAsync();

            return ItemToUpdate;
        }
    }
}
