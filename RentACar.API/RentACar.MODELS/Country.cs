using System;
using System.ComponentModel.DataAnnotations;

namespace RentACar.MODELS
{
    public class Country
    {
        [Key]
        public Guid Country_Id { get; set; }

        public string Country_Name { get; set; }

        public double Km_Price { get; set; }
    }
}
