using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.MODELS
{
    public class Desktop
    {
        [Key]
        public Guid Desktop_Id { get; set; }

        public string City { get; set; }

        public string ImageUrl { get; set; }

        [ForeignKey("Country")]
        public Guid Country_Id { get; set; }

        public Country Country { get; set; }

        public IEnumerable<Car> Cars { get; set; }
    }
}
