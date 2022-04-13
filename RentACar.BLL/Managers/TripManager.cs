using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentACar.BLL.Interfaces.Managers;
using RentACar.DAL.Interfaces.Repositories;
using RentACar.MODELS;
using RentACar.ERRORS;

namespace RentACar.BLL.Managers
{
    public class TripManager : ITripManager
    {
        private readonly ITripRepository _currentRepository;
        private readonly IPackageRepository _packageRepository;
        private readonly IDesktopRepository _desktopRepository;
        private readonly ICarManager _carManager;

        public TripManager(ITripRepository repository, IPackageRepository packageRepository, ICarManager carManager, IDesktopRepository desktopRepository)
        {
            _currentRepository = repository;
            _packageRepository = packageRepository;
            _desktopRepository = desktopRepository;
            _carManager = carManager;
        }

        public async Task<Trip> Add(Trip ItemToAdd)
        {
            ItemToAdd.Date_Start = ItemToAdd.Date_Start.AddDays(1);
            ItemToAdd.Date_End = ItemToAdd.Date_End.AddDays(1);

            var numberOfDays = ItemToAdd.Date_End - ItemToAdd.Date_Start;

            if(ItemToAdd.Date_Start < DateTime.Today)
            {
                throw new DatesBeforeTodayException("Les dates sélectionnées sont déjà passées.");
            }

            if (!await _carManager.IsCarOnATrip(ItemToAdd.Car_Id, ItemToAdd.Date_Start, ItemToAdd.Date_End))
            {
                var car = await _carManager.GetById(ItemToAdd.Car_Id);
                ItemToAdd.Car = car;

                var desktopStart = await _desktopRepository.GetById(ItemToAdd.Desktop_Start_Id);
                ItemToAdd.Desktop_Start = desktopStart;

                var allPackages = await _packageRepository.GetAll();

                foreach (var item in allPackages)
                {
                    if (ItemToAdd.Desktop_Start_Id == item.Desktop_Start_Id && ItemToAdd.Desktop_End_Id == item.Desktop_End_Id)
                    {
                        ItemToAdd.IsPackage = true;
                        ItemToAdd.Package_Id = item.Package_Id;
                        ItemToAdd.Package = item;
                    }
                }

                #region disount and penalty
                var diffOfDates = ItemToAdd.Date_Start - DateTime.Today;

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
                if (diffOfDates.Days >= 28)
                {
                    ItemToAdd.Discount = 0.20;
                }

                if (ItemToAdd.Desktop_End_Id == null)
                {
                    ItemToAdd.Penalty = 0.10;
                }

                if(ItemToAdd.Desktop_End_Id != null)
                {
                    ItemToAdd.Discount += 0.05;
                }
                #endregion

                if(ItemToAdd.Date_Start.Month >= 6 && ItemToAdd.Date_Start.Month <= 9)
                {
                    if(ItemToAdd.Date_End.Month >= 6 && ItemToAdd.Date_End.Month <= 9)
                    {
                        ItemToAdd.Car.Price = ItemToAdd.Car.Price / 3;
                    }
                }

                if (ItemToAdd.IsPackage)
                {
                    ItemToAdd.Price += (ItemToAdd.Car.Price * numberOfDays.Days) + ItemToAdd.Package.Price
                        - (ItemToAdd.Package.Price * ItemToAdd.Discount) + (ItemToAdd.Package.Price * ItemToAdd.Penalty);
                }

                if (!ItemToAdd.IsPackage)
                {
                    ItemToAdd.Price += (ItemToAdd.Car.Price * numberOfDays.Days) - (ItemToAdd.Car.Price * ItemToAdd.Discount) + (ItemToAdd.Car.Price * ItemToAdd.Penalty);
                }

                return await _currentRepository.Add(ItemToAdd);
            }

            return ItemToAdd;
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

        public async Task<Trip> FinishTrip(Trip ItemToUpdate)
        {
            if(ItemToUpdate.Car.Km_End <= ItemToUpdate.Car.Km_Start)
            {
                throw new KmEndLowerThanKmStartException("Le kilométrage actuel de la voiture ne peut pas être " +
                    "plus petit que son kilométrage de base.");
            }

            var desktopStart = await _desktopRepository.GetById(ItemToUpdate.Desktop_Start_Id);
            ItemToUpdate.Desktop_Start = desktopStart;

            if (ItemToUpdate.IsPackage)
            {
                var package = await _packageRepository.GetById(ItemToUpdate.Package_Id ?? Guid.Empty);
                ItemToUpdate.Package = package;

                if (ItemToUpdate.Car.Km_End - ItemToUpdate.Car.Km_Start > ItemToUpdate.Package.Km_Limit)
                {
                    double kmDone = (double)(ItemToUpdate.Car.Km_End - ItemToUpdate.Car.Km_Start);
                    double kmAboveLimit = kmDone - ItemToUpdate.Package.Km_Limit;

                    ItemToUpdate.Price += ItemToUpdate.Desktop_Start.Country.Km_Price * kmAboveLimit;
                }
            }

            if (!ItemToUpdate.IsPackage)
            {
                double kmDone = (double)(ItemToUpdate.Car.Km_End - ItemToUpdate.Car.Km_Start);
                double priceAfterKm = ItemToUpdate.Desktop_Start.Country.Km_Price * kmDone;

                ItemToUpdate.Price += priceAfterKm;
            }

            ItemToUpdate.IsTripDone = true;

            ItemToUpdate.Car.Km_End = null;

            return await _currentRepository.Update(ItemToUpdate);
        }

        public Task<Trip> Update(Trip ItemToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
