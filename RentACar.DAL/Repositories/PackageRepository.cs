using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentACar.DAL.Data;
using RentACar.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using RentACar.MODELS;

namespace RentACar.DAL.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        private readonly ApplicationDataContext _context;

        public PackageRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<Package> Add(Package ItemToAdd)
        {
            _context.Packages.Add(ItemToAdd);
            await _context.SaveChangesAsync();

            return ItemToAdd;
        }

        public async Task<Package> Delete(Guid id)
        {
            var result = await _context.Packages.FirstOrDefaultAsync(item => item.Package_Id == id);
            _context.Packages.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<IEnumerable<Package>> GetAll()
        {
            return await _context.Packages.ToListAsync();
        }

        public async Task<Package> GetById(Guid id)
        {
            var result = await _context.Packages.FirstOrDefaultAsync(item => item.Package_Id == id);

            return result;
        }

        public async Task<Package> Update(Package ItemToUpdate)
        {
            var result = await _context.Packages.FirstOrDefaultAsync(item => item.Package_Id == ItemToUpdate.Package_Id);
            _context.Packages.Update(ItemToUpdate);
            await _context.SaveChangesAsync();

            return ItemToUpdate;
        }
    }
}
