using System;
namespace RentACar.ERRORS
{
    public class DatesBeforeTodayException : Exception
    {
        public DatesBeforeTodayException()
        {
        }

        public DatesBeforeTodayException(string message) : base(message)
        {

        }
    }
}
