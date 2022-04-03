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
            await IsCarOnATrip();
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

        public async Task<bool> IsCarOnATrip()
        {
            var cars = await _currentReporitory.GetAll();
            var trips = await _tripRepository.GetAll();

            foreach (var car in cars)
            {
                foreach (var trip in trips)
                {
                    if(trip.Car_Id == car.Car_Id && DateTime.Now > trip.Date_Start && DateTime.Now < trip.Date_End)
                    {
                        car.IsAvailable = false;
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
