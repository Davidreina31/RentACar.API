using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentACar.BLL.Interfaces.Managers;
using RentACar.DAL.Interfaces.Repositories;
using RentACar.MODELS;

namespace RentACar.BLL.Managers
{
    public class CarManager : ICarManager
    {
        private readonly ICarRepository _currentRepository;

        public CarManager(ICarRepository repository)
        {
            _currentRepository = repository;
        }

        public async Task<Car> Add(Car ItemToAdd)
        {
            return await _currentRepository.Add(ItemToAdd);
        }

        public async Task<Car> Delete(Guid id)
        {
            return await _currentRepository.Delete(id);
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _currentRepository.GetAll();
        }

        public async Task<Car> GetById(Guid id)
        {
            return await _currentRepository.GetById(id);
        }

        public async Task<Car> Update(Car ItemToUpdate)
        {
            return await _currentRepository.Update(ItemToUpdate);
        }
    }
}
