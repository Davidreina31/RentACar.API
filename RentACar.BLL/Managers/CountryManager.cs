using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentACar.BLL.Interfaces.Managers;
using RentACar.DAL.Interfaces.Repositories;
using RentACar.MODELS;

namespace RentACar.BLL.Managers
{
    public class CountryManager : ICountryManager
    {
        private readonly ICountryRepository _currentRepository;

        public CountryManager(ICountryRepository repository)
        {
            _currentRepository = repository;
        }

        public Task<Country> Add(Country ItemToAdd)
        {
            return _currentRepository.Add(ItemToAdd);
        }

        public Task<Country> Delete(Guid id)
        {
            return _currentRepository.Delete(id);
        }

        public Task<IEnumerable<Country>> GetAll()
        {
            return _currentRepository.GetAll();
        }

        public Task<Country> GetById(Guid id)
        {
            return _currentRepository.GetById(id);
        }

        public Task<Country> Update(Country ItemToUpdate)
        {
            return _currentRepository.Update(ItemToUpdate);
        }
    }
}
