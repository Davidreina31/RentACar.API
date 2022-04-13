using System;
namespace RentACar.ERRORS
{
    public class CityAlreadyExistsException : Exception
    {
        public CityAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
