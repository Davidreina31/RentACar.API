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
        private readonly IDesktopRepository _desktopRepository;

        public PackageRepository(ApplicationDataContext context, IDesktopRepository desktopRepository)
        {
            _context = context;
            _desktopRepository = desktopRepository;
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
            var packages = await _context.Packages.ToListAsync();
            var allDesktops = await _desktopRepository.GetAll();

            foreach (var package in packages)
            {
                foreach (var desktop in allDesktops)
                {
                    if(package.Desktop_Start_Id == desktop.Desktop_Id)
                    {
                        package.Desktop_Start = desktop;
                    }
                    if(package.Desktop_End_Id == desktop.Desktop_Id)
                    {
                        package.Desktop_End = desktop;
                    }
                }
            }

            return packages;
        }

        public async Task<Package> GetById(Guid id)
        {
            var result = await _context.Packages.Include(item =>item.Desktop_Start).Include(item => item.Desktop_End).FirstOrDefaultAsync(item => item.Package_Id == id);
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
