using System;
namespace RentACar.ERRORS
{
    public class KmEndLowerThanKmStartException : Exception
    {
        public KmEndLowerThanKmStartException()
        {
        }

        public KmEndLowerThanKmStartException(string message) : base(message)
        {

        }
    }
}
