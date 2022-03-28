using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentACar.BLL.Interfaces.Managers;
using RentACar.DAL.Interfaces.Repositories;
using RentACar.MODELS;

namespace RentACar.BLL.Managers
{
    public class TripManager : ITripManager
    {
        private readonly ITripRepository _currentRepository;

        public TripManager(ITripRepository repository)
        {
            _currentRepository = repository;
        }

        public async Task<Trip> Add(Trip ItemToAdd)
        {
            return await _currentRepository.Add(ItemToAdd);
        }

        public async Task<Trip> Delete(Guid id)
        {
            return await _currentRepository.Delete(id);
        }

        public async Task<IEnumerable<Trip>> GetAll()
        {
            return await _currentRepository.GetAll();
        }

        public async Task<Trip> GetById(Guid id)
        {
            return await _currentRepository.GetById(id);
        }

        public async Task<Trip> Update(Trip ItemToUpdate)
        {
            return await _currentRepository.Update(ItemToUpdate);
        }
    }
}
