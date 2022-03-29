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

        public Task<Package> Add(Package ItemToAdd)
        {
            return _currentRepository.Add(ItemToAdd);
        }

        public Task<Package> Delete(Guid id)
        {
            return _currentRepository.Delete(id);
        }

        public Task<IEnumerable<Package>> GetAll()
        {
            return _currentRepository.GetAll();
        }

        public Task<Package> GetById(Guid id)
        {
            return _currentRepository.GetById(id);
        }

        public Task<Package> Update(Package ItemToUpdate)
        {
            return _currentRepository.Update(ItemToUpdate);
        }
    }
}
