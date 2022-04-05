using System;
using System.Threading.Tasks;
using RentACar.MODELS;

namespace RentACar.BLL.Interfaces.Managers
{
    public interface ITripManager : IBaseManager<Trip>
    {
        Task<Trip> FinishTrip(Trip ItemToUpdate);
    }
}
