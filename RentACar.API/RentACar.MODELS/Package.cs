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

        public long Km_Limit { get; set; }

        [ForeignKey("Desktop")]
        public Guid Desktop_Id_Start { get; set; }

        public Desktop Desktop_Start { get; set; }

        [ForeignKey("Desktop")]
        public Guid Desktop_Id_End { get; set; }

        public Desktop Desktop_End { get; set; }

    }
}
