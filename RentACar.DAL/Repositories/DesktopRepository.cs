using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentACar.DAL.Data;
using RentACar.DAL.Interfaces.Repositories;
using RentACar.MODELS;

namespace RentACar.DAL.Repositories
{
    public class DesktopRepository : IDesktopRepository
    {
        private readonly ApplicationDataContext _context;

        public DesktopRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<Desktop> Add(Desktop ItemToAdd)
        {
            _context.Desktops.Add(ItemToAdd);
            await _context.SaveChangesAsync();

            return ItemToAdd;
        }

        public async Task<Desktop> Delete(Guid id)
        {
            var result = await _context.Desktops.FirstOrDefaultAsync(item => item.Desktop_Id == id);
            _context.Desktops.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<IEnumerable<Desktop>> GetAll()
        {
            var desktopList = await _context.Desktops.Include(item => item.Cars).ToListAsync();

            return desktopList;
        }

        public async Task<Desktop> GetById(Guid id)
        {
            var result = await _context.Desktops.FirstOrDefaultAsync(item => item.Desktop_Id == id);

            return result;
        }

        public async Task<Desktop> Update(Desktop ItemToUpdate)
        {
            var result = await _context.Desktops.FirstOrDefaultAsync(item => item.Desktop_Id == ItemToUpdate.Desktop_Id);
            _context.Desktops.Update(ItemToUpdate);
            await _context.SaveChangesAsync();

            return ItemToUpdate;
        }
    }
}
