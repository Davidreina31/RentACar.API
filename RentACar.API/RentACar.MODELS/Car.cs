using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.MODELS
{
    public class Car
    {
        [Key]
        public Guid Car_Id { get; set; }

        public string Type { get; set; }

        public long Km_Start { get; set; }

        public long Km_End { get; set; }

        [ForeignKey("Desktop")]
        public Guid Desktop_Id { get; set; }

        public Desktop Desktop { get; set; }
    }
}
