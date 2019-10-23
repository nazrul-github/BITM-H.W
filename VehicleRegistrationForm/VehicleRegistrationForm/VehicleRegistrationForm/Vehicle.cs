using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleRegistrationForm
{
    public class Vehicle
    {
        public Vehicle(int registrationNumber)
        {
            RegistrationNumber = registrationNumber;
        }

        public Vehicle(string manufacturer, string modelYear, string color, string insuranceNumber, string ownerName, string registrationCity)
        {
            Manufacturer = manufacturer;
            ModelYear = modelYear;
            Color = color;
            InsuranceNumber = insuranceNumber;
            OwnerName = ownerName;
            RegistrationCity = registrationCity;
        }

        public Vehicle(string manufacturer, string modelYear, string color, string insuranceNumber, string ownerName,
            string registrationCity, int registrationNumber) : this(registrationNumber)
        {
        }

        public string Manufacturer { get; set; }
        public string ModelYear { get; set; }
        public string Color { get; set; }
        public string InsuranceNumber { get; set; }
        public string OwnerName { get; set; }
        public string RegistrationCity { get; set; }
        public int RegistrationNumber { get; set; }
    }
}