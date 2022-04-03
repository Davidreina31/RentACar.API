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

        public async Task<Country> Add(Country ItemToAdd)
        {
            return await _currentRepository.Add(ItemToAdd);
        }

        public async Task<Country> Delete(Guid id)
        {
            return await _currentRepository.Delete(id);
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            return await _currentRepository.GetAll();
        }

        public async Task<Country> GetById(Guid id)
        {
            return await _currentRepository.GetById(id);
        }

        public async Task<Country> Update(Country ItemToUpdate)
        {
            return await _currentRepository.Update(ItemToUpdate);
        }
    }
}
