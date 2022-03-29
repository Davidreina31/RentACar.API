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

        public CarManager(ICarRepository repository)
        {
            _currentReporitory = repository;
        }

        public Task<Car> Add(Car ItemToAdd)
        {
            return _currentReporitory.Add(ItemToAdd);
        }

        public Task<Car> Delete(Guid id)
        {
            return _currentReporitory.Delete(id);
        }

        public Task<IEnumerable<Car>> GetAll()
        {
            return _currentReporitory.GetAll();
        }

        public Task<Car> GetById(Guid id)
        {
            return _currentReporitory.GetById(id);
        }

        public Task<Car> Update(Car ItemToUpdate)
        {
            return _currentReporitory.Update(ItemToUpdate);
        }
    }
}
