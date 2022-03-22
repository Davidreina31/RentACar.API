using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.MODELS
{
    public class Package
    {
        [Key]
        public Guid Package_Id { get; set; }

        public double Price { get; set; }

        public double Km_Limit { get; set; }

        [ForeignKey("Desktop")]
        public Guid Desktop_Start_Id { get; set; }

        public Desktop Desktop_Start { get; set; }

        [ForeignKey("Desktop")]
        public Guid Desktop_End_Id { get; set; }

        public Desktop Desktop_End { get; set; }
    }
}
