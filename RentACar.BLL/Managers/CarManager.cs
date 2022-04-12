using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentACar.BLL.Interfaces.Managers;
using RentACar.DAL.Interfaces.Repositories;
using RentACar.MODELS;
using System.Linq;
using RentACar.ERRORS;

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
            dateStart = dateStart.AddDays(1);
            dateEnd = dateEnd.AddDays(1);
            var car = await _currentReporitory.GetById(id);
            var trips = await _tripRepository.GetAll();

            foreach (var trip in trips)
            {
                if (trip.Car_Id == id)
                {
                    if ((dateStart >= trip.Date_Start && dateStart <= trip.Date_End) || (dateEnd >= trip.Date_Start && dateEnd <= trip.Date_End))
                    {
                        throw new DatesAlreadyTakenException("La voiture est déjà prise à ces dates là. Cette voiture est réservée du " +
                            trip.Date_Start.ToShortDateString() + " au " + trip.Date_End.ToShortDateString() + ".");
                    }
                }
            }

            return false;
        }

        public async Task<IEnumerable<Car>> GetAllCarsForDesktop(Guid id)
        {
            var allCars = await _currentReporitory.GetAll();

            return allCars.Where(item => item.Desktop_Id == id);
        }
    }
}
