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
        private readonly IPackageRepository _packageRepository;

        public TripManager(ITripRepository repository, IPackageRepository packageRepository)
        {
            _currentRepository = repository;
            _packageRepository = packageRepository;
        }

        public async Task<Trip> Add(Trip ItemToAdd)
        {
            var allPackages = await _packageRepository.GetAll();

            foreach (var item in allPackages)
            {
                if (ItemToAdd.Desktop_Start_Id == item.Desktop_Start_Id && ItemToAdd.Desktop_End_Id == item.Desktop_End_Id)
                {
                    ItemToAdd.IsPackage = true;
                    ItemToAdd.Package_Id = item.Package_Id;
                }
            }

            #region disount and penalty
            var diffOfDates = DateTime.Now - ItemToAdd.Date_Start;

            if (diffOfDates.Days >= 7 && diffOfDates.Days < 14)
            {
                ItemToAdd.Discount = 0.05;
            }

            if (diffOfDates.Days >= 14 && diffOfDates.Days < 21)
            {
                ItemToAdd.Discount = 0.10;
            }
            if (diffOfDates.Days >= 21 && diffOfDates.Days < 28)
            {
                ItemToAdd.Discount = 0.15;
            }
            if (diffOfDates.Days >= 28 && diffOfDates.Days < 35)
            {
                ItemToAdd.Discount = 0.20;
            }

            if (ItemToAdd.Desktop_End_Id == null)
            {
                ItemToAdd.Penalty = 0.10;
            }
            #endregion

            if (ItemToAdd.IsPackage)
            {
                ItemToAdd.Price = ItemToAdd.Car.Price + ItemToAdd.Package.Price
                    - (ItemToAdd.Package.Price * ItemToAdd.Discount) + (ItemToAdd.Package.Price * ItemToAdd.Penalty);
            }

            if (!ItemToAdd.IsPackage)
            {
                var kmDone = ItemToAdd.Car.Km_End - ItemToAdd.Car.Km_Start;
                var priceAfterKm = ItemToAdd.Desktop_Start.Country.Km_Price * kmDone;

                ItemToAdd.Price = (double)(ItemToAdd.Car.Price + priceAfterKm - (priceAfterKm * ItemToAdd.Discount)
                    + (priceAfterKm * ItemToAdd.Penalty));
            }

            return await _currentRepository.Add(ItemToAdd);
        }

        public Task<Trip> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Trip>> GetAll()
        {
            return await _currentRepository.GetAll();
        }

        public async Task<Trip> GetById(Guid id)
        {
            return await _currentRepository.GetById(id);
        }

        public Task<Trip> Update(Trip ItemToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
