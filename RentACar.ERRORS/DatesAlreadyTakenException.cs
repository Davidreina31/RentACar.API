using System;
namespace RentACar.ERRORS
{
    public class DatesAlreadyTakenException : Exception
    {
        public DatesAlreadyTakenException()
        {
        }

        public DatesAlreadyTakenException(string message) : base(message)
        {
            
        }
    }
}
