using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.MODELS
{
    public class Trip
    {
        [Key]
        public Guid Trip_Id { get; set; }

        public DateTime Date_Start { get; set; }

        public DateTime Date_End { get; set; }

        public bool IsPackage { get; set; }

        [ForeignKey("Car")]
        public Guid Car_Id { get; set; }

        public Car Car { get; set; }

        [ForeignKey("Desktop")]
        public Guid Desktop_Id_Start { get; set; }

        public Desktop Desktop_Start { get; set; }

        [ForeignKey("Desktop")]
        public Guid Desktop_Id_End { get; set; }

        public Desktop Desktop_End { get; set; }
    }
}
