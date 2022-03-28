using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentACar.BLL.Interfaces.Managers;
using RentACar.DAL.Interfaces.Repositories;
using RentACar.MODELS;

namespace RentACar.BLL.Managers
{
    public class PackageManager : IPackageManager
    {
        private readonly IPackageRepository _currentRepository;

        public PackageManager(IPackageRepository repository)
        {
            _currentRepository = repository;
        }

        public async Task<Package> Add(Package ItemToAdd)
        {
            return await _currentRepository.Add(ItemToAdd);
        }

        public async Task<Package> Delete(Guid id)
        {
            return await _currentRepository.Delete(id);
        }

        public async Task<IEnumerable<Package>> GetAll()
        {
            return await _currentRepository.GetAll();
        }

        public async Task<Package> GetById(Guid id)
        {
            return await _currentRepository.GetById(id);
        }

        public async Task<Package> Update(Package ItemToUpdate)
        {
            return await _currentRepository.Update(ItemToUpdate);
        }
    }
}
