using System;
namespace RentACar.ERRORS
{
    public class CarIsOnATripException : Exception
    {
        public CarIsOnATripException()
        {
        }

        public CarIsOnATripException(string message) : base(message)
        {

        }
    }
}
