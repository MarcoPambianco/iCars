using System;
using System.Data;
using iCars.Models.ValueTypes;

namespace iCars.ViewModels
{
    public class CarViewModel
    {
        public string strTarga { get; set; }
        public Produttore strMarca { get; set; }
        public string strModello { get; set; }
        public int Kilometri { get; set; }
        public string strImagePath { get; set; }

        public static CarViewModel FromDataRow(DataRow dtr)
        {
            CarViewModel car = new CarViewModel {
                strTarga = Convert.ToString(dtr["paTarga"]),
                strMarca = Enum.Parse<Produttore>(Convert.ToString(dtr["paMarca"])),
                strModello = Convert.ToString(dtr["paModello"]),
                strImagePath = Convert.ToString(dtr["paImagePath"])
            };

            return car;
        }
    }
}