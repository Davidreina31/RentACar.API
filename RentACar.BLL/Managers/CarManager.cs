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
        private readonly ICarRepository _currentReporitory;
        private readonly ITripRepository _tripRepository;

        public CarManager(ICarRepository repository)
        {
            _currentReporitory = repository;
        }

        public async Task<Car> Add(Car ItemToAdd)
        {
            return await _currentReporitory.Add(ItemToAdd);
        }

        public async Task<Car> Delete(Guid id)
        {
            return await _currentReporitory.Delete(id);
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _currentReporitory.GetAll();
        }

        public async Task<Car> GetById(Guid id)
        {
            return await _currentReporitory.GetById(id);
        }

        public async Task<Car> Update(Car ItemToUpdate)
        {
            return await _currentReporitory.Update(ItemToUpdate);
        }

        public async Task<bool> IsCarOnATrip(Guid id)
        {
            var car = await _currentReporitory.GetById(id);

            if (car.IsAvailable)
            {
                return false;
            }

            else
            {
                return true;
            }
        }
    }
}
