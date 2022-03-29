using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.BLL.Interfaces.Managers
{
    public interface IBaseManager <T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(Guid id);

        Task<T> Add(T ItemToAdd);

        Task<T> Update(T ItemToUpdate);

        Task<T> Delete(Guid id);
    }
}
