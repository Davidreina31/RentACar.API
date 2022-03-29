using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentACar.BLL.Interfaces.Managers;
using RentACar.DAL.Interfaces.Repositories;
using RentACar.MODELS;

namespace RentACar.BLL.Managers
{
    public class DesktopManager : IDesktopManager
    {
        private readonly IDesktopRepository _currentRepository;

        public DesktopManager(IDesktopRepository repository)
        {
            _currentRepository = repository;
        }

        public Task<Desktop> Add(Desktop ItemToAdd)
        {
            return _currentRepository.Add(ItemToAdd);
        }

        public Task<Desktop> Delete(Guid id)
        {
            return _currentRepository.Delete(id);
        }

        public Task<IEnumerable<Desktop>> GetAll()
        {
            return _currentRepository.GetAll();
        }

        public Task<Desktop> GetById(Guid id)
        {
            return _currentRepository.GetById(id);
        }

        public Task<Desktop> Update(Desktop ItemToUpdate)
        {
            return _currentRepository.Update(ItemToUpdate);
        }
    }
}
