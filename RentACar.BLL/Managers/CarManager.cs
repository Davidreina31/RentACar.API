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

        public CarManager(ICarRepository repository, ITripRepository tripRepository)
        {
            _currentReporitory = repository;
            _tripRepository = tripRepository;
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

        public async Task<bool> IsCarOnATrip(Guid id, DateTime dateStart, DateTime dateEnd)
        {
            var car = await _currentReporitory.GetById(id);
            var trips = await _tripRepository.GetAll();

            foreach (var trip in trips)
            {
                if(trip.Car_Id == id)
                {
                    if((dateStart > trip.Date_Start && dateStart < trip.Date_End) || (dateEnd > trip.Date_Start && dateEnd < trip.Date_End))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
