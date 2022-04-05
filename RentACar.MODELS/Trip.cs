using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.MODELS
{
    public class Trip
    {
        [Key]
        public Guid Trip_Id { get; set; }

        public string Client_FirstName { get; set; }

        public string Client_LastName { get; set; }

        public string Client_Email { get; set; }

        public DateTime Date_Start { get; set; }

        public DateTime Date_End { get; set; }

        public bool IsPackage { get; set; }

        public double Price { get; set; }

        public double Discount { get; set; }

        public double Penalty { get; set; }

        public bool IsTripDone { get; set; }

        [ForeignKey("Car")]
        public Guid Car_Id { get; set; }

        public Car Car { get; set; }

        [ForeignKey("Desktop")]
        public Guid Desktop_Start_Id { get; set; }

        public Desktop Desktop_Start { get; set; }

        [ForeignKey("Desktop")]
        public Guid? Desktop_End_Id { get; set; }

        public Desktop? Desktop_End { get; set; }

        [ForeignKey("Package")]
        public Guid? Package_Id { get; set; }

        public Package? Package { get; set; }
    }
}
