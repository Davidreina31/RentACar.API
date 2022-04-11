using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentACar.MODELS;

namespace RentACar.BLL.Interfaces.Managers
{
    public interface ICarManager : IBaseManager<Car>
    {
        Task<bool> IsCarOnATrip(Guid id, DateTime dateStart, DateTime dateEnd);

        Task<IEnumerable<Car>> GetAllCarsForDesktop(Guid id);
    }
}
