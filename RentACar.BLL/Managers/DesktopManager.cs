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

        public async Task<Desktop> Add(Desktop ItemToAdd)
        {
            return await _currentRepository.Add(ItemToAdd);
        }

        public async Task<Desktop> Delete(Guid id)
        {
            return await _currentRepository.Delete(id);
        }

        public async Task<IEnumerable<Desktop>> GetAll()
        {
            return await _currentRepository.GetAll();
        }

        public async Task<Desktop> GetById(Guid id)
        {
            return await _currentRepository.GetById(id);
        }

        public async Task<Desktop> Update(Desktop ItemToUpdate)
        {
            return await _currentRepository.Update(ItemToUpdate);
        }
    }
}
